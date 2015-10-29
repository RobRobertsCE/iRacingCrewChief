using System.Linq;

namespace iRacing.Models.Sessions
{
    public static class SessionExtensions
    {
        public static Session Qualifying(this Session[] sessions)
        {
            return sessions.FirstOrDefault(s => s.SessionType.ToLower().Contains("qualif"));
        }    
    }
}
