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
    public class GetSalesOfficerBasedOnAreaHeadController : ApiController
    {
        #region VariableDeclaration
        CommonDAL commonDAL = null;
        #endregion

        #region HTTPMethods

        public HttpResponseMessage Post(FormDataCollection areaHead)
        {
            try
            {
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = areaHead.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                SalesOfficer getSalesOfficers = JsonConvert.DeserializeObject<SalesOfficer>(str);

                commonDAL = new CommonDAL();
                var salesOfficers = commonDAL.GetSalesOfficerBasedOnAreaHead(getSalesOfficers);
                message = Request.CreateResponse(HttpStatusCode.OK, salesOfficers);
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
