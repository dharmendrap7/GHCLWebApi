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
    public class ProductController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        
        /// <summary>
        /// To get all products.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var products = adminDAL.GetProducts();
                var message = Request.CreateResponse(HttpStatusCode.OK, products);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
      
        /// <summary>
        /// To add update product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection product)
        {
            try
            {
                bool isSuccess = false;
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = product.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                Product addproduct = JsonConvert.DeserializeObject<Product>(str);

                adminDAL = new AdminDAL();
                isSuccess = adminDAL.AddProduct(addproduct);
                if (isSuccess)
                {
                    message = Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                {
                    message = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
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
