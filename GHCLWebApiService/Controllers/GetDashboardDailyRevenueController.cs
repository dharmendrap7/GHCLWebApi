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
    public class GetDashboardDailyRevenueController : ApiController
    {
        #region VariableDeclaration
        CommonDAL commonDAL = null;
        #endregion

        #region HTTPMethods

        //public HttpResponseMessage Get()
        //{
        //    try
        //    {
        //        commonDAL = new CommonDAL();
        //        var dashboardData = commonDAL.GetDailyRevenueDashBoardData();
        //        var message = Request.CreateResponse(HttpStatusCode.OK, dashboardData);
        //        return message;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        public HttpResponseMessage Post(FormDataCollection dailyrevenuefilter)
        {
            try
            {
                HttpResponseMessage responseMessage;
                IEnumerator<KeyValuePair<string, string>> k = dailyrevenuefilter.GetEnumerator();
                k.MoveNext();
                KeyValuePair<string, string> c = k.Current;
                string str = c.Key;
                ZoneWiseAreaHeadSalesOfficer dailyrevenue = JsonConvert.DeserializeObject<ZoneWiseAreaHeadSalesOfficer>(str);

                commonDAL = new CommonDAL();
                var dashboardData = commonDAL.GetDailyRevenueDashBoardData(dailyrevenue);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, dashboardData);
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
