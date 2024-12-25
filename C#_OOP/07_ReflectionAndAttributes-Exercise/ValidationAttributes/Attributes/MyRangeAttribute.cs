namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public int MinValue { get; }
        public int MaxValue { get; }

        public override bool IsValid(object obj)
        {
            if (obj is not int integer) return false;
            return this.MinValue <= integer && integer <= this.MaxValue;
        }
    }
}