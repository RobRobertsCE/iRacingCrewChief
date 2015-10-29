namespace iRacing.Models.Radios
{
    public partial class Frequencies
    {
        public long FrequencyNum { get; set; }
        public string FrequencyName { get; set; }
        public long Priority { get; set; }
        public long CarIdx { get; set; }
        public long EntryIdx { get; set; }
        public long ClubID { get; set; }
        public long CanScan { get; set; }
        public long CanSquawk { get; set; }
        public long Muted { get; set; }
        public long IsMutable { get; set; }
        public long IsDeletable { get; set; }
    }
}
