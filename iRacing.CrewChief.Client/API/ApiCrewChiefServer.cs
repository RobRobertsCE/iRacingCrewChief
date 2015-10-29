using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;
using iRacing.CrewChief.Client.Request;
using iRacing.CrewChief.Client.Response;

namespace iRacing.CrewChief.Client.API
{
    public class ApiCrewChiefServer : ICrewChiefServer
    {
        public event CrewChiefEventHandler CrewChiefResponseEvent;
        protected virtual void OnCrewChiefResponse(ICrewChiefResponse response)
        {
            var handler = this.CrewChiefResponseEvent;
            if (null != handler)
                this.CrewChiefResponseEvent(this, response);
        }

        public virtual ICrewChiefAuthResponse Connect(ICrewChiefAuthRequest authRequest)
        {
            return new AuthResponse();
        }

        public virtual void SendRequest(CrewChiefMessageType requestType)
        {
            this.SendRequest(new CrewChiefRequest() { MessageType = requestType });
        }

        public virtual void SendRequest(ICrewChiefRequest request)
        {
            var handler = ApiRequestHandlerFactory.GetHandler(request.MessageType);
            var response = handler.HandleRequest(request);
            
            OnCrewChiefResponse(response);
        }

        public virtual void Disconnect()
        {

        }

        public virtual void Dispose()
        {

        }
    }
}
