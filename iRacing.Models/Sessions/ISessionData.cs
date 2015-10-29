using System;

namespace iRacing.Models.Sessions
{
    public interface ISessionData
    {
        string Raw { get; set; }
        int InfoUpdate { get; set; }
        iRacing.Models.Cameras.CameraInfo CameraInfo { get; set; }
        iRacing.Models.Drivers.DriverInfo DriverInfo { get; set; }
        iRacing.Models.Radios.RadioInfo RadioInfo { get; set; }
        SessionInfo SessionInfo { get; set; }
        iRacing.Models.Timing.SplitTimeInfo SplitTimeInfo { get; set; }
        iRacing.Models.Weekends.WeekendInfo WeekendInfo { get; set; }
    }
}
