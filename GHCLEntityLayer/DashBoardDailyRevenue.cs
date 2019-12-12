using System;

namespace GHCLEntityLayer
{
    public class DashBoardDailyRevenue
    {
        public DateTime RetailingDate { get; set; }
        public string ProductSKUCode { get; set; }
        public decimal ProductPrice { get; set; }
        public int TotalProductSold { get; set; }
        public decimal DailyRevenue { get; set; }
    }
}
