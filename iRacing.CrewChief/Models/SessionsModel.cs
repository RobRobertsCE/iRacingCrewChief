using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Models
{
    [Serializable]
    public class SessionsModel
    {
        public long SessionNum { get; set; }
        public string SessionLaps { get; set; }
        public string SessionTime { get; set; }
        public long SessionNumLapsToAvg { get; set; }
        public string SessionType { get; set; }
        public double ResultsAverageLapTime { get; set; }
        public long ResultsNumCautionFlags { get; set; }
        public long ResultsNumCautionLaps { get; set; }
        public long ResultsNumLeadChanges { get; set; }
        public long ResultsLapsComplete { get; set; }
        public long ResultsOfficial { get; set; }

        public ResultsPositionsModel[] ResultsPositions { get; set; }
        public ResultsFastestLapModel[] ResultsFastestLap { get; set; }
    }
}
