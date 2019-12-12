using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using GHCLEntityLayer;
using GHCLDataAccessLayer;

namespace GHCLWebApiService.Controllers
{
    public class GetAreaHeadNameBasedOnHeadQuaterController : ApiController
    {
        #region VariableDeclaration
        CommonDAL commonDAL = null;
        #endregion

        #region HTTPMethods

        /// <summary>
        /// To get area head name based on selected head quater.
        /// </summary>
        /// <param name="headquater"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection headquater)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = headquater.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                SalesOfficer selectedHeadQuater = JsonConvert.DeserializeObject<SalesOfficer>(str);

                commonDAL = new CommonDAL();
                var areaHead = commonDAL.GetAreaHeadNameBasedOnHeadQuater(selectedHeadQuater);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, areaHead);
                return responseMessage;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        #endregion
    }
}
