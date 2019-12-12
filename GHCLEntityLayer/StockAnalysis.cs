using System;

namespace GHCLEntityLayer
{
    public class StockAnalysis
    {
        public int? ProductId { get; set; }
        public int? ZoneId { get; set; }
        public int? DistributorId { get; set; }
        public int? AreaHeadId { get; set; }
        public DateTime? ClosingReportDate { get; set; }
        public int? ClosingStockQuantity { get; set; }
        public DateTime? BillingReportDate { get; set; }
        public int? BillingStockQuantity { get; set; }
        public string CreatedBy { get; set; }
    }
}
