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
    public class GetSKUProductCategoryWiseTotalValueController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        public HttpResponseMessage Post(FormDataCollection sKUProductCategoryWise)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = sKUProductCategoryWise.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                SKUProductCategoryWiseTotal selectedZoneAreaHead = JsonConvert.DeserializeObject<SKUProductCategoryWiseTotal>(str);

                adminDAL = new AdminDAL();
                var skuCategoryWiseTotals = adminDAL.GetSkuProductCategoryWiseTotalValues(selectedZoneAreaHead);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, skuCategoryWiseTotals);
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
