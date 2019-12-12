﻿using System;
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
    public class ProductPriceConfigurationController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
       
        /// <summary>
        /// To get all product price configurations.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var productPriceConfigurations = adminDAL.GetProductPriceConfiguration();
                var message = Request.CreateResponse(HttpStatusCode.OK, productPriceConfigurations);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
       
        /// <summary>
        /// To add product price configuration.
        /// </summary>
        /// <param name="productPriceConfiguration"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection productPriceConfiguration)
        {
            try
            {
                bool isSuccess = false;
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = productPriceConfiguration.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                ProductPriceConfiguration addProductPriceConfiguration = JsonConvert.DeserializeObject<ProductPriceConfiguration>(str);

                adminDAL = new AdminDAL();
                isSuccess = adminDAL.AddProductPriceConfiguration(addProductPriceConfiguration);
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
