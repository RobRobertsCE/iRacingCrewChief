using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Models
{
    [Serializable]
    public partial class SessionInfoModel
    {
        public SessionsModel Current { get { return Sessions.LastOrDefault(); } set { } }
        public SessionsModel[] Sessions { get; set; }
        public SessionInfoModel()
        {
            Sessions = new SessionsModel[] { new SessionsModel() };
        }
    }
}
