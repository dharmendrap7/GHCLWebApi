using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GHCLDataAccessLayer;

namespace GHCLWebApiService.Controllers
{
    public class RetailingReportSOWiseController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        /// <summary>
        /// To get Retailing Report SalesOfficer Wise.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var retailingReportSOWiseReport = adminDAL.GetRetailingReportSOWiseReports();
                var message = Request.CreateResponse(HttpStatusCode.OK, retailingReportSOWiseReport);
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
