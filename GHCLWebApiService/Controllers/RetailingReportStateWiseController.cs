using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GHCLDataAccessLayer;

namespace GHCLWebApiService.Controllers
{
    public class RetailingReportStateWiseController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        /// <summary>
        /// To get Retailing Report Zone Wise.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var retailingReportStateWiseReport = adminDAL.GetRetailingReportStateWiseReports();
                var message = Request.CreateResponse(HttpStatusCode.OK, retailingReportStateWiseReport);
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
