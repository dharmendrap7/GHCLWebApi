using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GHCLEntityLayer;
using GHCLDataAccessLayer;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace GHCLWebApiService.Controllers
{
    public class RetailingReportZoneWiseController : ApiController
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
                var retailingReportZoneWiseReport = adminDAL.GetRetailingReportZoneWiseReports();
                var message = Request.CreateResponse(HttpStatusCode.OK, retailingReportZoneWiseReport);
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
