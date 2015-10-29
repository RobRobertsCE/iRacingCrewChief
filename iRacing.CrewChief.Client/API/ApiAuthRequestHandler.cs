using System;
using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;
using iRacing.CrewChief.Client.Request;
using iRacing.CrewChief.Client.Response;

namespace iRacing.CrewChief.Client.API
{
    class ApiAuthRequestHandler : ApiRequestHandler, IRequestHandler
    {
        public override string ApiEndpoint
        {
            get { throw new NotImplementedException(); }
        }

        public ApiAuthRequestHandler()
            : base()
        {

        }

        public ICrewChiefResponse HandleRequest(ICrewChiefRequest request)
        {
            ICrewChiefAuthResponse response = new AuthResponse();
            try
            {
                response.AuthToken = Guid.NewGuid().ToString();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
                response.ResponseData = ex.ToString();
            }
            return response;
        }

        public void Dispose()
        {

        }
    }
}
