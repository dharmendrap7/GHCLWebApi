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
    public class DailySalesRetailingController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        /// <summary>
        /// To get daily sales report.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var dailySalesReport = adminDAL.GetDailySalesReports();
                var message = Request.CreateResponse(HttpStatusCode.OK, dailySalesReport);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// To add daily Sales Reporting.
        /// </summary>
        /// <param name="dailySalesReport"></param>
        /// <returns></returns>
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
                DailySalesReporting addDailySalesReport = JsonConvert.DeserializeObject<DailySalesReporting>(str);
                
                adminDAL = new AdminDAL();
                isSuccess = adminDAL.AddDailySalesReport(addDailySalesReport);
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
