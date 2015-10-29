using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iRacing.CrewChief.Response;

namespace iRacing.CrewChief.Server.Response
{
    class CrewChiefResponseOfT
    {
    }
    public class CrewChiefResponseOfT<T> : ICrewChiefResponseOfT<T>
    {
        public int StatusCode { get; set; }

        public T Data { get; set; }

        public string ResponseData { get; set; }

        public CrewChiefMessageType MessageType
        {
            get
            {
                return CrewChiefMessageType.AnyOfT;
            }
            set
            {

            }
        }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public CrewChiefResponseOfT()
        {

        }
    }
}
