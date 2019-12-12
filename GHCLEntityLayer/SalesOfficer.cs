namespace GHCLEntityLayer
{
    public class SalesOfficer
    {
        public int? Id { get; set; }
        public string SalesOfficerName { get; set; }
        public int? AreaHeadId { get; set; }
        public string AreaHeadName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string EmployeeId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public int? HeadQuaterId { get; set; }
        public string HeadQuaterName { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public int? ZoneId { get; set; }
        public string ZoneName { get; set; }
    }
}
