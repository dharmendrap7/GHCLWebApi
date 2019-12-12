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
    public class StatesController : ApiController
    {
        // GET: States
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion


        #region HTTPMethods

        /// <summary>
        /// To get all States
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var states = adminDAL.GetStates();
                var message = Request.CreateResponse(HttpStatusCode.OK, states);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /// <summary>
        /// To add and update a state.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection state)
        {
            try
            {
                bool isSuccess = false;
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = state.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                States addstate = JsonConvert.DeserializeObject<States>(str);

                adminDAL = new AdminDAL();
                isSuccess = adminDAL.AddState(addstate);
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