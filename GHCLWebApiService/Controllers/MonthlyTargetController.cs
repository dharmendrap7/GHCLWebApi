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
    public class MonthlyTargetController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods

        /// <summary>
        /// To get monthly targets.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var monthlyTargets = adminDAL.GetMonthlyTargets();
                var message = Request.CreateResponse(HttpStatusCode.OK, monthlyTargets);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// To add update monthly target.
        /// </summary>
        /// <param name="monthlyTarget"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection monthlyTarget)
        {
            try
            {
                bool isSuccess = false;
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = monthlyTarget.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                MonthlyTarget addMonthlyTarget = JsonConvert.DeserializeObject<MonthlyTarget>(str);

                adminDAL = new AdminDAL();
                isSuccess = adminDAL.AddMonthlyTarget(addMonthlyTarget);
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
