namespace GHCLEntityLayer
{
    public class Town
    {
        public int? Id { get; set; }
        public string TownName { get; set; }
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
