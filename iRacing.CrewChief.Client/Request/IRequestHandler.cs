using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;

namespace iRacing.CrewChief.Client.Request
{
    public interface IRequestHandler
    {
        ICrewChiefResponse HandleRequest(ICrewChiefRequest request);
    }
}
