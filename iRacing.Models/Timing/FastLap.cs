using System;
using iRacing.Models.Drivers;

namespace iRacing.Models.Timing
{
    public class FastLap
    {
        public Driver Driver;
        public TimeSpan Time;

        public static bool operator ==(FastLap a, FastLap b)
        {
            if ((object)a == null && (object)b == null)
                return true;

            if ((object)a == null || (object)b == null)
                return false;
            
            return a.Driver == b.Driver && a.Time == b.Time;
        }

        public static bool operator !=(FastLap a, FastLap b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is FastLap && this == (FastLap)obj;
        }

        public override int GetHashCode()
        {
            return Driver.GetHashCode();
        }
    }
}
