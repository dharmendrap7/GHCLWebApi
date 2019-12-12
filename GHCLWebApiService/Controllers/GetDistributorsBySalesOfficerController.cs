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
    public class GetDistributorsBySalesOfficerController : ApiController
    {
        #region VariableDeclaration
        CommonDAL commonDAL = null;
        #endregion

        #region HTTPMethods

        public HttpResponseMessage Post(FormDataCollection salesOfficer)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = salesOfficer.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                DailySalesReporting selectedSalesOfficer = JsonConvert.DeserializeObject<DailySalesReporting>(str);

                commonDAL = new CommonDAL();
                var distributors = commonDAL.GetDistributorsBasedOnSalesOfficer(selectedSalesOfficer);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, distributors);
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
