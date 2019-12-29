using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GHCLDataAccessLayer;

namespace GHCLWebApiService.Controllers
{
    public class MonthlyReportCardSOController : ApiController
    {

        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        /// <summary>
        /// To get Monthly Report Card SO.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get(int Month)
        {
            try
            {
                adminDAL = new AdminDAL();
                var monthlyReportCardSOReport = adminDAL.GetMonthlyReportCardSOReports(Month);
                var message = Request.CreateResponse(HttpStatusCode.OK, monthlyReportCardSOReport);
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
