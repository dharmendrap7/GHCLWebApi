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
    public class GetProductSkuWiseTotalPriceController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        public HttpResponseMessage Post(FormDataCollection sKUProductData)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = sKUProductData.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                SKUProductWisePerformance selectedZoneAreaHead = JsonConvert.DeserializeObject<SKUProductWisePerformance>(str);

                adminDAL = new AdminDAL();
                var skuProductWiseTotals = adminDAL.GetSkuProductWiseTotalValues(selectedZoneAreaHead);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, skuProductWiseTotals);
                return responseMessage;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        #endregion
    }
}
