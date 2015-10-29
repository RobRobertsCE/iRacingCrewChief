using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Models
{
    [Serializable]
    public class DriverInfoModel
    {
          public long DriverCarIdx { get; set; }
            public double DriverHeadPosX { get; set; }
            public double DriverHeadPosY { get; set; }
            public double DriverHeadPosZ { get; set; }
            public double DriverCarIdleRPM { get; set; }
            public double DriverCarRedLine { get; set; }
            public double DriverCarFuelKgPerLtr { get; set; }
            public double DriverCarSLFirstRPM { get; set; }
            public double DriverCarSLShiftRPM { get; set; }
            public double DriverCarSLLastRPM { get; set; }
            public double DriverCarSLBlinkRPM { get; set; }
            public double DriverPitTrkPct { get; set; }

            public DriverModel[] Drivers { get; set; }

            private DriverModel[] competingDrivers;
            public DriverModel[] CompetingDrivers
            {
                get
                {
                    if (competingDrivers != null)
                        return competingDrivers;

                    competingDrivers = new DriverModel[99];

                    foreach (var d in this.Drivers)
                        if (d.CarIdx < competingDrivers.Length)
                            competingDrivers[d.CarIdx] = d;

                    for (var i = 0; i < competingDrivers.Length; i++)
                        if (competingDrivers[i] == null)
                            competingDrivers[i] = new DriverModel
                            {
                                UserName = "",
                                AbbrevName = "",
                                Initials = "",
                                TeamName = "",
                                CarNumber = "",
                                CarPath = "",
                                CarScreenName = "",
                                CarScreenNameShort = "",
                                CarClassShortName = "",
                                //CarClassMaxFuel = "",
                                CarClassWeightPenalty = "",
                                CarClassColor = "",
                                LicString = "",
                                LicColor = "",
                                CarDesignStr = "",
                                HelmetDesignStr = "",
                                SuitDesignStr = "",
                                CarNumberDesignStr = ""
                            };

                    return competingDrivers;
                }
                set
                {

                }
            }
    }  
         
}
