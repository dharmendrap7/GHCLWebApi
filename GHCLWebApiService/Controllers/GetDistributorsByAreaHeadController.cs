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
    public class GetDistributorsByAreaHeadController : ApiController
    {
        #region VariableDeclaration
        CommonDAL commonDAL = null;
        #endregion

        #region HTTPMethods

        /// <summary>
        /// Get all distributors based on area head.
        /// </summary>
        /// <param name="areaHead"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection areaHead)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = areaHead.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                Distributor selectedAreaHead = JsonConvert.DeserializeObject<Distributor>(str);

                commonDAL = new CommonDAL();
                var distributors = commonDAL.GetDistributorsBasedOnAreaHead(selectedAreaHead);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, distributors);
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
