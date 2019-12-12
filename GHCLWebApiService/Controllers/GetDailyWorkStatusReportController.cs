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
    public class GetDailyWorkStatusReportController : ApiController
    {
        #region VariableDeclaration
        AdminDAL adminDAL = null;
        #endregion

        #region HTTPMethods

        public HttpResponseMessage Post(FormDataCollection dailyWorkStatus)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = dailyWorkStatus.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                DailyWorkStatusData selectedDate = JsonConvert.DeserializeObject<DailyWorkStatusData>(str);

                adminDAL = new AdminDAL();
                var dailyWorkStatusDatas = adminDAL.GetDailyWorkStatusReport(selectedDate);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, dailyWorkStatusDatas);
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
