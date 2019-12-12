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
    public class SalesOfficerController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods

        /// <summary>
        /// To get all sales officers.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var salesOfficers = adminDAL.GetSalesOfficers();
                var message = Request.CreateResponse(HttpStatusCode.OK, salesOfficers);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
       
        /// <summary>
        /// To add sales officer.
        /// </summary>
        /// <param name="salesOfficer"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection salesOfficer)
        {
            try
            {
                bool isSuccess = false;
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = salesOfficer.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                SalesOfficer addSalesOfficer = JsonConvert.DeserializeObject<SalesOfficer>(str);

                adminDAL = new AdminDAL();
                isSuccess = adminDAL.AddSalesOfficer(addSalesOfficer);
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
