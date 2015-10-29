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

using System;
using System.Collections.Generic;
using iRacing.Models.Sessions;
using iRacing.Models.Telemetry;

namespace iRacing.Models
{
	[Serializable]
    public class DataSample
    {
        public static readonly DataSample YetToConnected = new DataSample { IsConnected = false };
        public DataSample LastSample { get; set; }        
        private ISessionData sessionData;
        public ISessionData SessionData
        {
            get
            {
                return sessionData;
            }
            set 
            {
                sessionData = value;
            }
        }
        private ITelemetry telemetry;
        public ITelemetry Telemetry
        {
            get
            {
                return telemetry;
            }
            set
            {
                telemetry = value;
            }
        }
        public bool IsConnected { get; set; }
        public Dictionary<string, string> TelemetryDescription { get; set; }

        public DataSample()
        {
            IsConnected = true;
        }
    }
}
