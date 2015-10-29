using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Models
{
    [Serializable]
    public class DataSampleModel //: iRacingSDK.DataSample
    {
        new public bool IsConnected { get; set; }


        private SessionDataModel sessionData;
        new public SessionDataModel SessionData
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

        //private TelemetryModel telemetry;
        //new public TelemetryModel Telemetry
        //{
        //    get
        //    {
        //        return telemetry;
        //    }
        //    set
        //    {
        //        telemetry = value;
        //    }
        //}

        private TelemetryDataModel telemetry;
        new public TelemetryDataModel Telemetry
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

        public DataSampleModel()
        {
            IsConnected = true;
        }
    }
}
