using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iRacing.CrewChief.Models;

namespace iRacing.CrewChief.Response
{
    public interface ICrewChiefLeaderboardResponse: ICrewChiefResponse
    {
        IList<ResultsPositions> Leaderboard { get; set; }
    }
}
