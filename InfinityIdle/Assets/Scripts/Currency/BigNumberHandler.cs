using BreakInfinity;
using UnityEngine;

namespace InfinityIdle.Core
{
    public static class BigNumber
    {
        // Wrapper methods for consistent usage across the project
        public static BigDouble Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
                return new BigDouble(0);
            
            try
            {
                return BigDouble.Parse(value);
            }
            catch
            {
                Debug.LogWarning($"Failed to parse value: {value}, returning 0");
                return new BigDouble(0);
            }
        }

        public static string Format(BigDouble value)
        {
            return NumberFormatter.Format(value);
        }

        public static BigDouble Min(BigDouble a, BigDouble b)
        {
            return BigDouble.Min(a, b);
        }

        public static BigDouble Max(BigDouble a, BigDouble b)
        {
            return BigDouble.Max(a, b);
        }

        public static BigDouble Pow(BigDouble value, double exponent)
        {
            return BigDouble.Pow(value, exponent);
        }

        public static BigDouble Log10(BigDouble value)
        {
            return BigDouble.Log10(value);
        }

        public static BigDouble Sqrt(BigDouble value)
        {
            return BigDouble.Sqrt(value);
        }
    }
}