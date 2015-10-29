namespace iRacing.Models.Weekends
{
    public partial class WeekendOptions
    {
        public long NumStarters { get; set; }
        public string StartingGrid { get; set; }
        public string QualifyScoring { get; set; }
        public string CourseCautions { get; set; }
        public long StandingStart { get; set; }
        public string Restarts { get; set; }
        public string WeatherType { get; set; }
        public string Skies { get; set; }
        public string WindDirection { get; set; }
        public string WindSpeed { get; set; }
        public string WeatherTemp { get; set; }
        public string RelativeHumidity { get; set; }
        public string FogLevel { get; set; }
        public long Unofficial { get; set; }
        public string CommercialMode { get; set; }
        public long NightMode { get; set; }
        public long IsFixedSetup { get; set; }
        public string StrictLapsChecking { get; set; }
        public long HasOpenRegistration { get; set; }
        public long HardcoreLevel { get; set; }
    }
}
