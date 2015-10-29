using System;
using iRacing.CrewChief.Response;

namespace iRacing.CrewChief.Client.Response
{
    class AuthResponse : ICrewChiefAuthResponse
    {
        public string ResponseData { get; set; }

        public string AuthToken { get; set; }

        public int StatusCode { get; set; }

        public CrewChiefMessageType MessageType
        {
            get
            {
                return CrewChiefMessageType.Authentication;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public AuthResponse()
        {
            IsSuccess = true;
        }
    }
}
