namespace GHCLEntityLayer
{
    public class ZoneWiseAreaHeadSalesOfficer
    {
        public int? MonthId { get; set; }
        public string MonthName { get; set; }
        public int? ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int? AreaHeadId { get; set; }
        public string AreaHeadName { get; set; }
        public int? SalesOfficerId { get; set; }
        public string SalesOfficerName { get; set; }
        public int? TotalCalls { get; set; }
        public int? TotalProductiveCalls { get; set; }
        public int? TotalRecordCount { get; set; }
        public float? ProductSalesQuantity { get; set; }
        public decimal? ProductSpecificPrice { get; set; }
        public int? DailyRetailingId { get; set; }
    }
}
