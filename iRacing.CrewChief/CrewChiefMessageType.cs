using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief
{
    public enum CrewChiefMessageType
    {
        Authentication,
        DataSample,
        SessionData,
        ServerState,
        ServiceMessage,
        Leaderboard,
        DriversList,
        AnyOfT
    }
}
