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
    public class GetTownByHeadQuaterController : ApiController
    {
        #region VariableDeclaration
        CommonDAL commonDAL = null;
        #endregion

        #region HTTPMethods
        /// <summary>
        /// To get all towns based on head quater.
        /// </summary>
        /// <param name="zone"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection zone)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = zone.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                Town selectedHeadQuater = JsonConvert.DeserializeObject<Town>(str);

                commonDAL = new CommonDAL();
                var allTowns = commonDAL.GetTownsBasedOnHeadQuater(selectedHeadQuater);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, allTowns);
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
