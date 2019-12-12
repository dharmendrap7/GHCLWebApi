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
    public class GetZonalHeadByContactNumberController : ApiController
    {
        #region VariableDeclaration
        CommonDAL commonDAL = null;
        #endregion

        #region HTTPMethods

        public HttpResponseMessage Post(FormDataCollection zonalHeadContactNumber)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = zonalHeadContactNumber.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                ZonalHeadByContactNumber selectedZonalHead = JsonConvert.DeserializeObject<ZonalHeadByContactNumber>(str);

                commonDAL = new CommonDAL();
                var zonalHeadDetails = commonDAL.GetZonalHeadByContactNumber(selectedZonalHead);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, zonalHeadDetails);
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
