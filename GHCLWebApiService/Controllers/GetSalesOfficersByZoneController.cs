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
    public class GetSalesOfficersByZoneController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods

        public HttpResponseMessage Post(FormDataCollection zone)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = zone.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                ZoneWiseAreaHeadSalesOfficer selectedZone = JsonConvert.DeserializeObject<ZoneWiseAreaHeadSalesOfficer>(str);

                adminDAL = new AdminDAL();
                var salesOfficers = adminDAL.GetSalesOfficersByZone(selectedZone);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, salesOfficers);
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
