using System;

namespace AdapterExample
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        public SquareToRectangleAdapter(Square square)
        {
            // todo
            this.Width = square.Side;
            this.Height = square.Side;
        }

        // todo
        public int Width { get; }
        public int Height { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square();
            square.Side = 5;
            var sqToRectangle =  new SquareToRectangleAdapter(square);
            var area = sqToRectangle.Area();
            Console.WriteLine(area);

        }
    }
}
