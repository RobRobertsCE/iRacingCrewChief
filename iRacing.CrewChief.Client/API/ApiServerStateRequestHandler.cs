using System;
using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;
using iRacing.CrewChief.Server.Request;
using iRacing.CrewChief.Server.Response;

namespace iRacing.CrewChief.Server.API
{
    class ApiServerStateRequestHandler : ApiRequestHandler, IRequestHandler
    {
        public override string ApiEndpoint
        {
            get { throw new NotImplementedException(); }
        }

        public ApiServerStateRequestHandler()
            : base()
        {

        }

        public ICrewChiefResponse HandleRequest(ICrewChiefRequest request)
        {
            ICrewChiefServerStateResponse response = new ServerStateResponse();
            try
            {
                response.ServerState = "true";// iRacingSDKConnection.IsConnected;
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
