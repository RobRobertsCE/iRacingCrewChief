namespace iRacing.Models.Timing
{
    public partial class ResultsPositions
    {
        public long Position { get; set; }
        public long ClassPosition { get; set; }
        public long CarIdx { get; set; }
        public long Lap { get; set; }
        public double Time { get; set; }
        public long FastestLap { get; set; }
        public double FastestTime { get; set; }
        public double LastTime { get; set; }
        public long LapsLed { get; set; }
        public long LapsComplete { get; set; }
        public double LapsDriven { get; set; }
        public long Incidents { get; set; }
        public long ReasonOutId { get; set; }
        public string ReasonOutStr { get; set; }
    }
}
