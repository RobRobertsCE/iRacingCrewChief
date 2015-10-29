using System;
using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;
using iRacing.CrewChief.Client.Request;

namespace iRacing.CrewChief.Client.Socket
{
    public class CrewChiefSocketServer : ICrewChiefServer
    {
        public event CrewChiefEventHandler CrewChiefResponseEvent;
        protected virtual void OnCrewChiefResponse(ICrewChiefResponse response)
        {
            var handler = this.CrewChiefResponseEvent;
            if (null != handler)
                this.CrewChiefResponseEvent(this, response);
        }

        public virtual void SendRequest(CrewChiefMessageType requestType)
        {
            this.SendRequest(new CrewChiefRequest() { MessageType = requestType });
        }

        public virtual void SendRequest(ICrewChiefRequest request)
        {
            var handler = GetHandler(request.MessageType);
            var response = handler.HandleRequest(request);
            OnCrewChiefResponse(response);
        }

        protected virtual IRequestHandler GetHandler(CrewChiefMessageType requestType)
        {
            switch (requestType)
            {                              
                case CrewChiefMessageType.DataSample:
                    return new SocketDataSampleRequestHandler();
                    break;

                default:
                    throw new ArgumentException(String.Format("Invalid Socket RequestType: {0}", requestType.ToString()));
            }
        }

        public void Dispose()
        {
          
        }
    }
}
