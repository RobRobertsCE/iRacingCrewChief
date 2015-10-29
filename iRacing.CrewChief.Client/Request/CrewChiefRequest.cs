using iRacing.CrewChief.Request;

namespace iRacing.CrewChief.Client.Request
{
    public class CrewChiefRequest : ICrewChiefRequest
    {
        public string RequestData { get; set; }

        public CrewChiefMessageType MessageType { get; set; }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }
    }
}
