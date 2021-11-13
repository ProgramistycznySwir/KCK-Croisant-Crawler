namespace Croisant_Crawler.Data
{
    public struct ValueInRangeInt
    {
        public RangeInt range;
        public int value;

        public ValueInRangeInt(int min, int max, int value)
            => (this.range, this.value) = (new RangeInt(min, max), value);
        public ValueInRangeInt(RangeInt range, int value)
            => (this.range, this.value) = (range, value);

        public float Percent => range.Percent(value);

        public bool IsMin => value <= range.min;
        public bool IsMax => value >= range.max;

        public override string ToString()
            => $"Value: {value} in {range}";
    }
}