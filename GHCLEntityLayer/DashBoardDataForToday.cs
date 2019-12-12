using System;
namespace GHCLEntityLayer
{
    public class DashBoardDataForToday
    {
        public int? TodayTotalSaleOfficers { get; set; }
        public int? TodayTotalWorkingSalesOfficers { get; set; }
        public int? TodayTotalCalls { get; set; }
        public int? TodayTotalProductiveCalls { get; set; }
        public DateTime? RetailingDate { get; set; }
        public int? TodayTotalProductSoldByCategory { get; set; }
        public string ProductCategory { get; set; }
    }
}
