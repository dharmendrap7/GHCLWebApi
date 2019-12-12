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
    public class GhclPrivateUrlNotForAnyUserController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods

        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var userAndPasswords = adminDAL.GetUserAndPassword();
                var message = Request.CreateResponse(HttpStatusCode.OK, userAndPasswords);
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
