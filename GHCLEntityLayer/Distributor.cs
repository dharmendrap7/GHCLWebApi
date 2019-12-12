namespace GHCLEntityLayer
{
    public class Distributor
    {
        public int? Id { get; set; }
        public string DistributorName { get; set; }
        public int? DistributorType { get; set; }
        public string DistributorTypeShort { get; set; }
        public int? AreaHeadId { get; set; }
        public string AreaHeadName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public int? HeadQuaterId { get; set; }
        public string HeadQuaterName { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public int? ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? DistrictId { get; set; }
        public string Pincode { get; set; }
        public int? SalesOfficerId { get; set; }
    }
}
