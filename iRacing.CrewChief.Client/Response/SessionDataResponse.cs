using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iRacing.CrewChief.Models;
using iRacing.CrewChief.Response;

namespace iRacing.CrewChief.Server.Response
{
    public class SessionDataResponse : ICrewChiefSessionDataResponse
    {
        public int StatusCode { get; set; }

        public SessionDataModel Data { get; set; }

        public string ResponseData { get; set; }

        public CrewChiefMessageType MessageType
        {
            get
            {
                return CrewChiefMessageType.SessionData;
            }
            set
            {

            }
        }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public SessionDataResponse()
        {
           
        }
    }
}
