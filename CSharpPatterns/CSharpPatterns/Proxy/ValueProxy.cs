using System;

namespace CSharpPatterns.Proxy
{
    public struct Percentage
    {
        private readonly float value;

        internal Percentage(float value)
        {
            this.value = value;
        }

        public static float operator *(float f, Percentage p) => f * p.value;

        public static Percentage operator +(Percentage a, Percentage b) => new Percentage(a.value + b.value);

        public override string ToString() => $"{Math.Round(value*100,2)}%";

    }

    public static class PercentageExtension
    {
        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent ( this float value )
        {
            return new Percentage(value / 100.0f);
        }
    }
   
}
