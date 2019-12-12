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
    public class ZoneController : ApiController
    {
        // GET: Zone
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods

        /// <summary>
        /// To get all zones
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            try
            {
                adminDAL = new AdminDAL();
                var zones = adminDAL.GetZones();
                var message = Request.CreateResponse(HttpStatusCode.OK, zones);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

       /// <summary>
       /// To add and update a zone.
       /// </summary>
       /// <param name="zone"></param>
       /// <returns></returns>
        public HttpResponseMessage Post(FormDataCollection zone)
        {
            try
            {
                bool isSuccess = false;
                var message = new HttpResponseMessage();
                IEnumerator<KeyValuePair<string, string>> k = zone.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                Zone addzone = JsonConvert.DeserializeObject<Zone>(str);

                adminDAL = new AdminDAL();
                isSuccess = adminDAL.AddZone(addzone);
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