namespace GHCLEntityLayer
{
    public class Product
    {
        public int? Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductCategoryId { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSKUCode { get; set; }
        public string ProductWeightDescription { get; set; }
        public string ProductWeight { get; set; }
        public int? NumberOfPieces { get; set; }
        public decimal? ProductPrice { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
    }
}
