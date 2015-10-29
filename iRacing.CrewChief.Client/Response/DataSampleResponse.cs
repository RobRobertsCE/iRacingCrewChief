using System;
using iRacing.CrewChief.Response;
using iRacing.Models;

namespace iRacing.CrewChief.Client.Response
{
    class DataSampleResponse : ICrewChiefDataSampleResponse
    {
        public int StatusCode { get; set; }

        public DataSample Data { get; set; }

        public string ResponseData { get; set; }

        public CrewChiefMessageType MessageType
        {
            get
            {
                return CrewChiefMessageType.DataSample;
            }
            set
            {

            }
        }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public DataSampleResponse()
        {
           
        }
    }
}
