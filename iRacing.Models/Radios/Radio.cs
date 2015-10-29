namespace iRacing.Models.Radios
{
    public partial class Radio
    {
        public long RadioNum { get; set; }
        public long HopCount { get; set; }
        public long NumFrequencies { get; set; }
        public long TunedToFrequencyNum { get; set; }
        public long ScanningIsOn { get; set; }
        public Frequencies[] Frequencies { get; set; }
    }
}
