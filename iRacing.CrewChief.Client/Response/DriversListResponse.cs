using System;
using iRacing.CrewChief.Response;
using iRacing.CrewChief.Models;
using System.Collections.Generic;

namespace iRacing.CrewChief.Server.Response
{
    class DriversListResponse : ICrewChiefDriversListResponse
    {
        public int StatusCode { get; set; }

        public IList<DriverModel> Drivers { get; set; }

        public string ResponseData { get; set; }

        public CrewChiefMessageType MessageType
        {
            get
            {
                return CrewChiefMessageType.DriversList;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }
    }
}
