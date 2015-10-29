using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Request
{
    public interface ICrewChiefAuthRequest : ICrewChiefRequest
    {
        string LoginData { get; set; }
    }
}
