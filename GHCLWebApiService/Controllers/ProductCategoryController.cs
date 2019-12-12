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
    public class ProductCategoryController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods

        /// <summary>
        /// To get all product categories.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var productCategories = adminDAL.GetProductCategories();
                var message = Request.CreateResponse(HttpStatusCode.OK, productCategories);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
          
        /// <summary>
        /// To add product category.
        /// </summary>
        /// <param name="productCategory"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection productCategory)
        {
            try
            {
                bool isSuccess = false;
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = productCategory.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                ProductCategories addProductCategory = JsonConvert.DeserializeObject<ProductCategories>(str);

                adminDAL = new AdminDAL();
                isSuccess = adminDAL.AddProductCategory(addProductCategory);
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
