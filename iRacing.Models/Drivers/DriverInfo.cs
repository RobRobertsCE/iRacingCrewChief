namespace iRacing.Models.Drivers
{
    public partial class DriverInfo
    {
        public long DriverCarIdx { get; set; }
        public double DriverHeadPosX { get; set; }
        public double DriverHeadPosY { get; set; }
        public double DriverHeadPosZ { get; set; }
        public double DriverCarIdleRPM { get; set; }
        public double DriverCarRedLine { get; set; }
        public double DriverCarFuelKgPerLtr { get; set; }
        public double DriverCarFuelMaxLtr { get; set; }
        public double DriverCarMaxFuelPct { get; set; }
        public double DriverCarSLFirstRPM { get; set; }
        public double DriverCarSLShiftRPM { get; set; }
        public double DriverCarSLLastRPM { get; set; }
        public double DriverCarSLBlinkRPM { get; set; }
        public double DriverPitTrkPct { get; set; }
        public double DriverCarEstLapTime { get; set; }
        public string DriverSetupName { get; set; }
        public long DriverSetupIsModified { get; set; }
        public string DriverSetupLoadTypeName { get; set; }
        public long DriverSetupPassedTech { get; set; }

        Driver[] competingDrivers = null;
        public Driver[] CompetingDrivers
        {
            get
            {
                if (competingDrivers != null)
                    return competingDrivers;

                competingDrivers = new Driver[this.Drivers.MaxLength()];

                foreach (var d in this.Drivers)
                    if (d.CarIdx < competingDrivers.Length)
                        competingDrivers[d.CarIdx] = d;

                for (var i = 0; i < competingDrivers.Length; i++)
                    if (competingDrivers[i] == null)
                        competingDrivers[i] = new Driver
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
        public Driver[] Drivers { get; set; }
    }
}
