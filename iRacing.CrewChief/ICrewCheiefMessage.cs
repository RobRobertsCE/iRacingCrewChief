using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief
{
    public interface ICrewCheiefMessage
    {
        CrewChiefMessageType MessageType { get; set; }    
    }
}
