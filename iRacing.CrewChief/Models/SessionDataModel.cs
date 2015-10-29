using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Models
{
    [Serializable]
    public class SessionDataModel
    {
        public string Raw;
        public int InfoUpdate;

        public DriverInfoModel DriverInfo { get; set; }
        public WeekendInfoModel WeekendInfo { get; set; }
        public SessionInfoModel SessionInfo { get; set; }
    }
}
