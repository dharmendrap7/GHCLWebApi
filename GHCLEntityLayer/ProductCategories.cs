namespace GHCLEntityLayer
{
    public class ProductCategories
    {
        public int? Id { get; set; }
        public string ProductCategory { get; set; }
        public int? ProductTypeId { get; set; }        
        public string ProductType { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
    }
}
