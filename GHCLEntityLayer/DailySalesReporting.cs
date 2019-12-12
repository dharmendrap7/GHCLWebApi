using System;

namespace GHCLEntityLayer
{
    public class DailySalesReporting
    {
        public int? Id { get; set; }
        public DateTime? RetailingDate { get; set; }
        public long? SalesOfficerId { get; set; }
        public long? DistributorId { get; set; }
        public int? TotalCalls { get; set; }
        public int? ProductiveCalls { get; set; }
        public string CreatedBy { get; set; }
        public int? ProductId { get; set; }
        public string ProductSKUCode { get; set; }
        public int? ProductCategoryId { get; set; }
        public float? ProductSalesQuantity { get; set; }
        public string ZoneName { get; set; }
        public string StateName { get; set; }
        public string HeadQuaterName { get; set; }
        public string AreaHeadName { get; set; }
        public string SalesOfficerName { get; set; }
        public string DistributorName { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public decimal? ProductSpecificPrice { get; set; }
        public string ContactNumber { get; set; }
    }
}
