using System;
using iRacing.CrewChief.Response;

namespace iRacing.CrewChief.Server.Response
{
    class ServerStateResponse : ICrewChiefServerStateResponse
    {
        public int StatusCode { get; set; }

        public object ServerState { get; set; }

        public string ResponseData { get; set; }

        public CrewChiefMessageType MessageType
        {
            get
            {
                return CrewChiefMessageType.ServerState;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public ServerStateResponse()
        {
            IsSuccess = true;
        }
    }
}
