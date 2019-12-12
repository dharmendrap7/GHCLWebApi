namespace GHCLEntityLayer
{
    public class ProductPriceConfiguration
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public int? HeadQuaterId { get; set; }
        public string HeadQuaterName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
