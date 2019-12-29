using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GHCLDataAccessLayer;

namespace GHCLWebApiService.Controllers
{
    public class MonthlyReportCardAreaHeadController : ApiController
    {

        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        /// <summary>
        /// To get Monthly Report Card Area Head.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get(int Month)
        {
            try
            {
                adminDAL = new AdminDAL();
                var monthlyReportCardAreaHeadReport = adminDAL.GetMonthlyReportCardAreaHeadReports(Month);
                var message = Request.CreateResponse(HttpStatusCode.OK, monthlyReportCardAreaHeadReport);
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
