using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Request
{
    public interface ICrewChiefRequest : ICrewCheiefMessage
    {
        string RequestData { get; set; }
    }
}
