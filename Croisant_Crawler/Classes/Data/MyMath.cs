using System;

namespace Croisant_Crawler.Data
{
    public static class MyMath
    {
        public static readonly Random rng = new Random();

        /// <summary>
        /// Returns a + (b - a) * t.
        /// </summary>
        public static float Lerp(float a, float b, float t)
            => a + (b - a) * t;
        public static float InverseLerp(float a, float b, float value)
            => (value - a) / (b - a);

        public static float Clamp(float value, float min, float max)
            => value < min ? min : (value > max ? max : value);

        public static float RandomFloat => (float)rng.NextDouble();
    }
}