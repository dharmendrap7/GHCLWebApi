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
    public class GetProductBasedOnSKUCodeController : ApiController
    {
        #region VariableDeclaration
        CommonDAL commonDAL = null;
        #endregion

        #region HTTPMethods

        public HttpResponseMessage Post(FormDataCollection product)
        {
            try
            {               
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = product.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                Product getproduct = JsonConvert.DeserializeObject<Product>(str);

                commonDAL = new CommonDAL();
                var ProductId = commonDAL.GetProductIdBasedOnSKUCode(getproduct);
                message = Request.CreateResponse(HttpStatusCode.OK, ProductId);
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
