using System;
using BreakInfinity;
using UnityEngine;

namespace InfinityIdle.Core
{
    public static class NumberFormatter
    {
        private static readonly string[] standardNotation = new string[]
        {
            "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc",
            "UDc", "DDc", "TDc", "QaDc", "QiDc", "SxDc", "SpDc", "OcDc", "NoDc", "Vg",
            "UVg", "DVg", "TVg", "QaVg", "QiVg", "SxVg", "SpVg", "OcVg", "NoVg", "Tg"
        };

        public enum NotationType
        {
            Standard,
            Scientific,
            Engineering,
            Logarithmic
        }

        private static NotationType currentNotation = NotationType.Standard;

        public static void SetNotationType(NotationType type)
        {
            currentNotation = type;
        }

        public static string Format(BigDouble value, int decimals = 2)
        {
            switch (currentNotation)
            {
                case NotationType.Standard:
                    return FormatStandard(value, decimals);
                case NotationType.Scientific:
                    return FormatScientific(value, decimals);
                case NotationType.Engineering:
                    return FormatEngineering(value, decimals);
                case NotationType.Logarithmic:
                    return FormatLogarithmic(value, decimals);
                default:
                    return FormatStandard(value, decimals);
            }
        }

        private static string FormatStandard(BigDouble value, int decimals)
        {
            if (value < 1000)
            {
                return value.ToString("F" + Math.Max(0, decimals));
            }

            int magnitude = (int)Math.Floor(BigDouble.Log10(BigDouble.Abs(value)) / 3);
            
            if (magnitude < standardNotation.Length)
            {
                BigDouble scaled = value / BigDouble.Pow(1000, magnitude);
                return scaled.ToString("F" + decimals) + standardNotation[magnitude];
            }
            else
            {
                return FormatScientific(value, decimals);
            }
        }

        private static string FormatScientific(BigDouble value, int decimals)
        {
            if (value == 0) return "0";
            
            double exponent = Math.Floor(BigDouble.Log10(BigDouble.Abs(value)));
            BigDouble mantissa = value / BigDouble.Pow(10, exponent);
            
            return mantissa.ToString("F" + decimals) + "e" + exponent.ToString("F0");
        }

        private static string FormatEngineering(BigDouble value, int decimals)
        {
            if (value == 0) return "0";
            
            double exponent = Math.Floor(BigDouble.Log10(BigDouble.Abs(value)) / 3) * 3;
            BigDouble mantissa = value / BigDouble.Pow(10, exponent);
            
            return mantissa.ToString("F" + decimals) + "e" + exponent.ToString("F0");
        }

        private static string FormatLogarithmic(BigDouble value, int decimals)
        {
            if (value <= 0) return "0";
            
            double log = BigDouble.Log10(value);
            return "e" + log.ToString("F" + decimals);
        }

        public static string FormatTime(float seconds)
        {
            if (seconds < 60)
                return $"{seconds:F0}s";
            else if (seconds < 3600)
                return $"{seconds / 60:F0}m {seconds % 60:F0}s";
            else if (seconds < 86400)
                return $"{seconds / 3600:F0}h {(seconds % 3600) / 60:F0}m";
            else
                return $"{seconds / 86400:F0}d {(seconds % 86400) / 3600:F0}h";
        }

        public static string FormatPercentage(float value, int decimals = 1)
        {
            return (value * 100).ToString("F" + decimals) + "%";
        }
    }
}