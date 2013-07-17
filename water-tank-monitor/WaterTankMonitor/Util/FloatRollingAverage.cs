using System;
using Microsoft.SPOT;

namespace WaterTankMonitor.Util
{
    /// <summary>
    /// http://stackoverflow.com/a/3097014/18437
    /// </summary>
    public class FloatRollingAverage
    {
        bool firstValue = true;
        float[] values;
        float sum = 0;
        int pos = 0;

        public FloatRollingAverage(int capacity)
        {
            values = new float[capacity];  // all 0's initially
        }

        public void AddValue(float v)
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

        public float Average()
        {
            return sum / values.Length;
        }
    }
}
