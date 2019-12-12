using System;

namespace GHCLEntityLayer
{
    public class DailyWorkStatusData
    {
        public DateTime? RetailingDate { get; set; }
        public int? AreaHeadId { get; set; }
        public int? MarketWorking { get; set; }
        public string AreaHeadName { get; set; }
        public string HeadQuaterName { get; set; }
        public int? TotalStrength { get; set; }
        public int? ZoneId { get; set; }
    }
}
