using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    public class Product
    {
        public string Name { get; set; }
        public Color color { get; set; }
        public Size Size { get; set; }
    }

    public enum Color
    {
        red,
        green,
        blue,
        white
    }

    public enum Size
    {
        small,
        medium,
        large,
        XLarge
    }
}
