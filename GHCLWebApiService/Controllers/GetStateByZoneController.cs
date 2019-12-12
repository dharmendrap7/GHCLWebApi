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
    public class GetStateByZoneController : ApiController
    {
        #region VariableDeclaration
        CommonDAL commonDAL = null;
        #endregion

        #region HTTPMethods
        /// <summary>
        /// To get all states based on the selected zone.
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
                HeadQuater selectedzone = JsonConvert.DeserializeObject<HeadQuater>(str);

                commonDAL = new CommonDAL();
                var allStates = commonDAL.GetStatesBasedOnZone(selectedzone);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, allStates);
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
