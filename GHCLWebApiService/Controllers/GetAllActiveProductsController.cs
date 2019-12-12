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
    public class GetAllActiveProductsController : ApiController
    {
        #region VariableDeclaration
        CommonDAL commonDAL = null;
        #endregion

        #region HTTPMethods
        public HttpResponseMessage Get()
        {
            try
            {
                commonDAL = new CommonDAL();
                var activeProducts = commonDAL.GetAllActiveProducts();
                var message = Request.CreateResponse(HttpStatusCode.OK, activeProducts);
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
