using System;

namespace Croisant_Crawler.Data
{
    public struct RangeInt
    {
        public int min;
        public int max;

        public int Lenght => max - min;

        public RangeInt(int min, int max) => (this.min, this.max) = (min, max);
        public RangeInt(int max) => (this.min, this.max) = (0, max);

        public float Evaluate(float t) => MyMath.Lerp(min, max, t);
        public float Percent(float value) => MyMath.InverseLerp(min, max, value);
        public float Clamp(float value) => MyMath.Clamp(value, (float)min, (float)max);
        public int Clamp(int value) => (int)MyMath.Clamp(value, min, max);
        public bool IsInRange(float value) => (value >= min && value <= max);
        public bool IsInRange(int value)   => (value >= min && value <= max);

        public float RandomFloat => MyMath.Lerp(min, max, MyMath.RandomFloat);
        public int RandomInt => (int)RandomFloat;

        public override string ToString() => $"RangeInt: ({min}, {max})";
    }
}