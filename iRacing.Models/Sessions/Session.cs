using iRacing.Models.Timing;

namespace iRacing.Models.Sessions
{
    public partial class Session
    {
        public bool IsRace
        {
            get
            {
                return this.SessionType.ToLower().Contains("race");
            }
            set
            {

            }
        }          
        public int _SessionLaps
        {
            get
            {
                int result = 0;
                int.TryParse(SessionLaps, out result);
                return result;
            }
        }
        public double _SessionTime
        {
            get
            {
                double result = 0;
                double.TryParse(SessionTime.Replace(" sec", ""), out result);
                return result;
            }
        }
        public bool IsLimitedSessionLaps
        {
            get
            {
                return SessionLaps.ToLower() != "unlimited";
            }
        }
        public bool IsLimitedTime
        {
            get
            {
                return SessionTime.ToLower() != "unlimited";
            }
        }  
        public long SessionNum { get; set; }
        public string SessionLaps { get; set; }
        public string SessionTime { get; set; }
        public long SessionNumLapsToAvg { get; set; }
        public string SessionType { get; set; }   
        public ResultsPositions[] ResultsPositions { get; set; }    
        public ResultsFastestLap[] ResultsFastestLap { get; set; }
        public double ResultsAverageLapTime { get; set; }
        public long ResultsNumCautionFlags { get; set; }
        public long ResultsNumCautionLaps { get; set; }
        public long ResultsNumLeadChanges { get; set; }
        public long ResultsLapsComplete { get; set; }
        public long ResultsOfficial { get; set; }
    }
}
