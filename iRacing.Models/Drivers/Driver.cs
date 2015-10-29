namespace iRacing.Models.Drivers
{
    public partial class Driver
    {
        public bool IsPaceCar { get { return this.CarIdx == 0; } }
        public long CarIdx { get; set; }
        public string UserName { get; set; }
        public string AbbrevName { get; set; }
        public string Initials { get; set; }
        public long UserID { get; set; }
        public long TeamID { get; set; }
        public string TeamName { get; set; }
        public string CarNumber { get; set; }
        public long CarNumberRaw { get; set; }
        public string CarPath { get; set; }
        public long CarClassID { get; set; }
        public long CarID { get; set; }
        public string CarScreenName { get; set; }
        public string CarScreenNameShort { get; set; }
        public string CarClassShortName { get; set; }
        public long CarClassRelSpeed { get; set; }
        public long CarClassLicenseLevel { get; set; }
        public string CarClassMaxFuelPct { get; set; }
        public string CarClassWeightPenalty { get; set; }
        public string CarClassColor { get; set; }
        public long IRating { get; set; }
        public long LicLevel { get; set; }
        public long LicSubLevel { get; set; }
        public string LicString { get; set; }
        public string LicColor { get; set; }
        public long IsSpectator { get; set; }
        public string CarDesignStr { get; set; }
        public string HelmetDesignStr { get; set; }
        public string SuitDesignStr { get; set; }
        public string CarNumberDesignStr { get; set; }
        public long CarSponsor_1 { get; set; }
        public long CarSponsor_2 { get; set; }
        public string ClubName { get; set; }
        public string DivisionName { get; set; }
    }
}
