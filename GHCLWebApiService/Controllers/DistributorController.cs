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
    public class DistributorController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods
        /// <summary>
        /// To get all distributors.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var distributors = adminDAL.GetDistributors();
                var message = Request.CreateResponse(HttpStatusCode.OK, distributors);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
        /// <summary>
        /// To add and update distributor.
        /// </summary>
        /// <param name="distributor"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection distributor)
        {
            try
            {
                bool isSuccess = false;
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = distributor.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                Distributor addDistributor = JsonConvert.DeserializeObject<Distributor>(str);

                adminDAL = new AdminDAL();
                isSuccess = adminDAL.AddDistributor(addDistributor);
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
