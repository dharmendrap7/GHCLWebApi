using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GHCLDataAccessLayer;

namespace GHCLWebApiService.Controllers
{
    public class RetailingReportDistributorWiseController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        /// <summary>
        /// To get Retailing Report Distributor Wise.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var retailingReportDBWiseReport = adminDAL.GetRetailingReportDBWiseReports();
                var message = Request.CreateResponse(HttpStatusCode.OK, retailingReportDBWiseReport);
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
