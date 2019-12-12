using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GHCLDataAccessLayer;

namespace GHCLWebApiService.Controllers
{
    public class MonthlyReportCardZoneController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        /// <summary>
        /// To get Monthly Report Card Zone.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get(int Year, int Month)
        {
            try
            {
                adminDAL = new AdminDAL();
                var monthlyReportCradZoneReport = adminDAL.GetMonthlyReportCardZoneReports(Year,Month);
                var message = Request.CreateResponse(HttpStatusCode.OK, monthlyReportCradZoneReport);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        #endregion
    }
}
