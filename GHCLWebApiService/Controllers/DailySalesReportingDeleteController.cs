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
    public class DailySalesReportingDeleteController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        public HttpResponseMessage Post(FormDataCollection dailySalesReport)
        {
            try
            {
                bool isSuccess = false;
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = dailySalesReport.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                DailySalesReporting deleteDailySalesReport = JsonConvert.DeserializeObject<DailySalesReporting>(str);

                adminDAL = new AdminDAL();
                isSuccess = adminDAL.DeleteDailySalesReport(deleteDailySalesReport);
                if (isSuccess)
                {
                    message = Request.CreateResponse(HttpStatusCode.OK);
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
