using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.CrewChief.Models
{
    [Serializable]
    public class CarArrayModel : IEnumerable<CarModel>
    {
        CarModel[] cars;

        public CarArrayModel(TelemetryDataModel telemetry)
        {
            var drivers = telemetry.SessionData.DriverInfo.CompetingDrivers;

            cars = new CarModel[drivers.Length];

            for (var i = 0; i < drivers.Length; i++)
                cars[i] = new CarModel(telemetry, i);
        }

        public CarModel this[long carIdx]
        {
            get
            {
                if (carIdx < 0)
                    throw new Exception("Attempt to load car details for negative car index {0}");//.F(carIdx));

                if (carIdx >= cars.Length)
                    throw new Exception("Attempt to load car details for unknown carIndex.  carIdx: {0}, maxNumber: {1}");//.F(carIdx, cars.Length - 1));

                return cars[carIdx];
            }
        }

        public IEnumerator<CarModel> GetEnumerator()
        {
            return (cars as IEnumerable<CarModel>).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return cars.GetEnumerator();
        }
    }
}
