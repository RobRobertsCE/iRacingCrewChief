using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;

namespace iRacing.CrewChief
{
    public interface ICrewChiefServer : IDisposable
    {
        event CrewChiefEventHandler CrewChiefResponseEvent;

        void SendRequest(ICrewChiefRequest request);
        void SendRequest(CrewChiefMessageType requestType);
    }
}
