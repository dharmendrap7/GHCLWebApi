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
    public class GetDashboardDataForTotalValueController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        public HttpResponseMessage Post(FormDataCollection dashboardTotalValue)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = dashboardTotalValue.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                DashboardTotalValue selectedZoneAreaHead = JsonConvert.DeserializeObject<DashboardTotalValue>(str);

                adminDAL = new AdminDAL();
                var dashboardTotals = adminDAL.GetDashBoardTotalValues(selectedZoneAreaHead);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, dashboardTotals);
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
