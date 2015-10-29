using System;
using iRacing.CrewChief.Client.Request;

namespace iRacing.CrewChief.Client.API
{
    static class ApiRequestHandlerFactory
    {
        public static IRequestHandler GetHandler(CrewChiefMessageType requestType)
        {
            switch (requestType)
            {         
                case CrewChiefMessageType.Authentication :
                    return new ApiAuthRequestHandler();
                    break;

                case CrewChiefMessageType.DataSample:
                    return new ApiDataSampleRequestHandler();
                    break;

                default:
                    throw new ArgumentException(String.Format("Invalid API RequestType: {0}", requestType.ToString()));
            }
        }
    }
}
