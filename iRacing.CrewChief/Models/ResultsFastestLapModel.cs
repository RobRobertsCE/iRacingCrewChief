using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Models
{
    [Serializable]
    public class ResultsFastestLapModel
    {
        public long CarIdx { get; set; }
        public long FastestLap { get; set; }
        public double FastestTime { get; set; }
    }
}
