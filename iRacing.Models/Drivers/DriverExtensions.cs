using System.Linq;

namespace iRacing.Models.Drivers
{
    public static class DriverExtensions
    {
        public static int MaxLength(this Driver[] self)
        {
            return (int)self.Where(d => d.CarNumberRaw > 0).Max(d => d.CarIdx) + 1;
        }
    }
}
