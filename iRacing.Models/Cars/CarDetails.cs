using iRacing.Models.Drivers;
using iRacing.Models.Telemetry;

namespace iRacing.Models.Cars
{
    public class CarDetails
    {
        readonly int carIdx;
        readonly ITelemetry telemetry;
        readonly Driver driver;

        public CarDetails(ITelemetry telemetry, int carIdx)
        {
            this.telemetry = telemetry;
            this.carIdx = carIdx;
            this.driver = telemetry.SessionData.DriverInfo.CompetingDrivers[carIdx];
        }

        public int Index { get { return carIdx; } }
        public int CarIdx { get { return carIdx; } }
        public Driver Driver { get { return driver; } }
        public string CarNumberDisplay { get { return driver == null ? "" : driver.CarNumber; } }
        public short CarNumberRaw { get { return driver == null ? (short)-1 : (short)driver.CarNumberRaw; } }
        public string UserName { get { return driver == null ? "Unknown" : driver.UserName; } }
        public bool IsPaceCar { get { return carIdx == 0; } }

        public Car Car(DataSample data)
        {
            return data.Telemetry.Cars[this.carIdx];
        }
    }
}
