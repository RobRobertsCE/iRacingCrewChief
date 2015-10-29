using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iRacing.CrewChief.Request;

namespace iRacing.CrewChief
{
    public interface ICrewChiefClient : IDisposable
    {
        event CrewChiefEventHandler CrewChiefResponseEvent;

        void SendRequest(ICrewChiefRequest request);
    }
}
