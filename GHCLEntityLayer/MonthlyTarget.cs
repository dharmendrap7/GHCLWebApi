namespace GHCLEntityLayer
{
    public class MonthlyTarget
    {
        public int? Id { get; set; }
        public int? ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public int? HeadQuaterId { get; set; }
        public string HeadQuaterName { get; set; }
        public int? AreaHeadId { get; set; }
        public string AreaHeadName { get; set; }
        public int? SalesOfficerId { get; set; }
        public string SalesOfficerName { get; set; }
        public int? ProductCategoryId { get; set; }
        public string ProductCategory { get; set; }
        public decimal? AssignedTargetValue { get; set; }
        public decimal? AchievedTargetValue { get; set; }
        public int? MonthId { get; set; }
        public string MonthName { get; set; }
        public int? Year { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }

    }
}
