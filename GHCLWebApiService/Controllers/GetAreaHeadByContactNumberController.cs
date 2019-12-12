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
    public class GetAreaHeadByContactNumberController : ApiController
    {
        #region VariableDeclaration
        CommonDAL commonDAL = null;
        #endregion

        #region HTTPMethods

        public HttpResponseMessage Post(FormDataCollection areaHeadContactNumber)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = areaHeadContactNumber.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                AreaHeadByContactNumber selectedAreaHead = JsonConvert.DeserializeObject<AreaHeadByContactNumber>(str);

                commonDAL = new CommonDAL();
                var areaHeadDetails = commonDAL.GetAreaHeadByContactNumber(selectedAreaHead);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, areaHeadDetails);
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
