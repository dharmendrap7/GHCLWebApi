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
    public class DashboardAverageMonthlyCallsController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        public HttpResponseMessage Post(FormDataCollection zoneWiseAreaHeadSalesOfficer)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = zoneWiseAreaHeadSalesOfficer.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                ZoneWiseAreaHeadSalesOfficer selectedMonthZone = JsonConvert.DeserializeObject<ZoneWiseAreaHeadSalesOfficer>(str);

                adminDAL = new AdminDAL();
                var averageTotals = adminDAL.GetDashBoardDataForAvgMonthlyCalls(selectedMonthZone);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, averageTotals);
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
