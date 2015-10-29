using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Response
{
    public interface ICrewChiefResponse : ICrewCheiefMessage
    {
        string ResponseData { get; set; }
        bool IsSuccess { get; set; }
        string ErrorMessage { get; set; }
        int StatusCode { get; set; }
    }
}
