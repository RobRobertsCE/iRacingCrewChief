using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iRacing.CrewChief.Request;
using iRacing.CrewChief.Response;
using iRacing.CrewChief.Client.Request;
using iRacing.CrewChief.Client.Response;
using iRacing.Models;
using Newtonsoft.Json;

namespace iRacing.CrewChief.Client.Socket
{
    class SocketDataSampleRequestHandler : SocketRequestHandler, IRequestHandler
    {
        public ICrewChiefResponse HandleRequest(ICrewChiefRequest request)
        {
            ICrewChiefDataSampleResponse response = new DataSampleResponse();
            try
            {
                var socketResponse = base.SendRequest(request.MessageType.ToString());
                response.ResponseData = socketResponse;
                response.Data = JsonConvert.DeserializeObject<DataSample>(socketResponse);
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
