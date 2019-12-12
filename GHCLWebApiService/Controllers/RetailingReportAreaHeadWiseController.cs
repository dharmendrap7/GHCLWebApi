using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GHCLDataAccessLayer;

namespace GHCLWebApiService.Controllers
{
    public class RetailingReportAreaHeadWiseController : ApiController
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
                var retailingReportAreaHeadWiseReport = adminDAL.GetRetailingReportAreaHeadWiseReports();
                var message = Request.CreateResponse(HttpStatusCode.OK, retailingReportAreaHeadWiseReport);
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
