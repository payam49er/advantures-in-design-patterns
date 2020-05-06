using System;
using System.Collections.Generic;
using System.Text;

namespace Factories
{
    // This is an example of factory method. Constructor turns into private and static methods help to create
    // a clean API to create objects with different specification. 
 

    public class Point
    {
        private double x;
        private double y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
        public static class Factory
        {
            public static Point NewCartisianPoint ( double x, double y )
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint ( double rho, double theta )
            {
                return new Point(Math.Cos(rho), Math.Sin(theta));
            }
        }
    }
}
