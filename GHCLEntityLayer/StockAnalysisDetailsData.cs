namespace GHCLEntityLayer
{
    public class StockAnalysisDetailsData
    {
        public int? MonthId { get; set; }
        public int? ZoneId { get; set; }
        public int? AreaHeadId { get; set; }
        public int? DistributorId { get; set; }
        public string ProductWeightDescription { get; set; }
        public int? OpeningStock { get; set; }
        public int? BillingStock { get; set; }
        public int? ClosingStock { get; set; }
        public int? ReportedRetailingStock { get; set; }
        public int? ActualRetailingStock { get; set; }
        public int? OverReportStock { get; set; }
        public decimal? ValueOfStockOverReporting { get; set; }
    }
}
