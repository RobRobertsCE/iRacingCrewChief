using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iRacing.CrewChief.Models;
using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;
using iRacing.CrewChief.Server.Request;
using iRacing.CrewChief.Server.Response;
using Newtonsoft.Json;

namespace iRacing.CrewChief.Server.Socket
{
    class SocketSessionDataRequestHandler : SocketRequestHandler, IRequestHandler
    {
        public ICrewChiefResponse HandleRequest(ICrewChiefRequest request)
        {
            ICrewChiefSessionDataResponse response = new SessionDataResponse();
            try
            {
                var socketResponse = base.SendRequest(request.MessageType.ToString());
                response.ResponseData = socketResponse;
                var dataSample = JsonConvert.DeserializeObject<DataSampleModel>(socketResponse);
                response.Data = dataSample.SessionData;
                response.MessageType = request.MessageType;
                response.StatusCode = 200;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.ToString();
            }
            return response;
        }
    }
}
