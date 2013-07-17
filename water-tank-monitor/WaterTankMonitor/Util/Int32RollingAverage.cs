using System;
using Microsoft.SPOT;

namespace WaterTankMonitor.Util
{
    /// <summary>
    /// http://stackoverflow.com/a/3097014/18437
    /// </summary>
    public class Int32RollingAverage
    {
        bool firstValue = true;
        int[] values;
        int sum = 0;
        int pos = 0;

        public Int32RollingAverage(int capacity)
        {
            values = new int[capacity];  // all 0's initially
        }

        public void AddValue(int v)
        {
            if (firstValue)
            {
                firstValue = false;
                for (int i = 0; i < values.Length; i++)
                {
                    AddValue(v);
                }
            }

            sum -= values[pos];  // only need the array to subtract old value
            sum += v;
            values[pos] = v;
            pos = (pos + 1) % values.Length;
        }

        public int Average()
        {
            return sum / values.Length;
        }
    }
}
