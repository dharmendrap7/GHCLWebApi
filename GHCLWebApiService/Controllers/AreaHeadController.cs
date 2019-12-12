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
    public class AreaHeadController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods

        /// <summary>
        /// To get all area heads.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var areaHeads = adminDAL.GetAreaHeads();
                var message = Request.CreateResponse(HttpStatusCode.OK, areaHeads);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        /// <summary>
        /// To add area head
        /// </summary>
        /// <param name="areaHead"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection areaHead)
        {
            try
            {
                bool isSuccess = false;
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = areaHead.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                AreaHead addAreaHead = JsonConvert.DeserializeObject<AreaHead>(str);

                adminDAL = new AdminDAL();
                isSuccess = adminDAL.AddAreaHead(addAreaHead);
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
