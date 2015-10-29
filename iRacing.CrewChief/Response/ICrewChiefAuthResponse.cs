using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Response
{
    public interface ICrewChiefAuthResponse : ICrewChiefResponse 
    {        
        string AuthToken { get; set; }
    }
}
