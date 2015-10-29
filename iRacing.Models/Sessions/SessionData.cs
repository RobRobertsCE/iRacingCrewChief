// This file is part of iRacingSDK.
//
// Copyright 2014 Dean Netherton
// https://github.com/vipoo/iRacingSDK.Net
//
// iRacingSDK is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// iRacingSDK is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with iRacingSDK.  If not, see <http://www.gnu.org/licenses/>.

using iRacing.Models.Cameras;
using iRacing.Models.Drivers;
using iRacing.Models.Radios;
using iRacing.Models.Timing;
using iRacing.Models.Weekends;

namespace iRacing.Models.Sessions
{
    public partial class SessionData : iRacing.Models.Sessions.ISessionData
    {
        public string Raw { get; set; }
        public int InfoUpdate { get; set; }
        public WeekendInfo WeekendInfo { get; set; }
        public SessionInfo SessionInfo { get; set; }
        public CameraInfo CameraInfo { get; set; }
        public RadioInfo RadioInfo { get; set; }
        public DriverInfo DriverInfo { get; set; }
        public SplitTimeInfo SplitTimeInfo { get; set; }
    }
}
