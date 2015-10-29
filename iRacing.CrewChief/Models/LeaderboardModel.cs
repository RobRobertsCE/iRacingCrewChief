using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Models
{
    [Serializable()]
    public class LeaderboardModel
    {
        public long CarIdx { get; set; }
        public string UserName { get; set; }
        public long UserID { get; set; }
        public string CarNumber { get; set; }
        public string CarScreenName { get; set; }
        public string CarScreenNameShort { get; set; }
        public string CarClassShortName { get; set; }
        public string CarClassColor { get; set; }
        public long IRating { get; set; }
        public string LicString { get; set; }
        public string LicColor { get; set; }
        public string ClubName { get; set; }
        public string DivisionName { get; set; }
        public long Position { get; set; }
        public long ClassPosition { get; set; }
        public double Time { get; set; }
        public long FastestLap { get; set; }
        public double FastestTime { get; set; }
        public double LastTime { get; set; }
        public long LapsLed { get; set; }
        public long LapsComplete { get; set; }
        public double LapsDriven { get; set; }
        public long Incidents { get; set; }
        public long ReasonOutId { get; set; }
        public string ReasonOutStr { get; set; }
        // laps down 
        public long Lap { get; set; }

        public LeaderboardModel()
        { }

        public LeaderboardModel(ResultsPositionsModel result, DriverModel driver)
        {
            CarIdx = driver.CarIdx;
            UserID = driver.UserID;
            UserName = driver.UserName;
            CarNumber = driver.CarNumber;
            IRating = driver.IRating;
            LicString = driver.LicString;
            LicColor = driver.LicColor;
            Position = result.Position;
            ClassPosition = result.ClassPosition;
            CarClassColor = driver.CarClassColor;
            CarScreenName = driver.CarScreenName;
            ClubName = driver.ClubName;
            DivisionName = driver.DivisionName;
            CarScreenNameShort = driver.CarScreenNameShort;
            CarClassShortName = driver.CarClassShortName;
            Time = result.Time;
            FastestLap = result.FastestLap;
            FastestTime = result.FastestTime;
            LastTime = result.LastTime;
            LapsLed = result.LapsLed;
            LapsComplete = result.LapsComplete;
            LapsDriven = result.LapsDriven;
            Incidents = result.Incidents;
            ReasonOutId = result.ReasonOutId;
            ReasonOutStr = result.ReasonOutStr;
            Lap = result.Lap;
            Time = result.Time;
        }

    }
}
