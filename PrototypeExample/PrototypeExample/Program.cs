using System;
using System.IO;
using System.Xml.Serialization;

namespace PrototypeExample
{
    public class Program
    {
        public class Point
        {
            public int X, Y;
        }

        public class Line
        {
            public Line()
            {
                Start = new Point();
                End = new Point();
            }
            public Point Start, End;

            public Line DeepCopy()
            {
                using (var ms = new MemoryStream())
                {
                    var s = new XmlSerializer(typeof(Line));
                    s.Serialize(ms,this);
                    ms.Position = 0;
                    return (Line) s.Deserialize(ms);
                }
            }

            public override string ToString()
            {
                return $"{nameof(Start)}: {Start.X}, {nameof(Start)}: {Start.Y} , {nameof(End)}:{End.X}, {nameof(End)}:{End.Y}";
            }
        }
        static void Main(string[] args)
        {
            var line1 = new Line();
            line1.Start.X = 10;
            line1.Start.Y = 15;

            line1.End.X = 5;
            line1.End.Y = 7;

            var line2 = line1.DeepCopy();
            line2.End.X = 3;
            line2.End.Y = 5;
            
            Console.WriteLine($"This is line1 {line1}");
            Console.WriteLine($"This is line2 {line2}");
        }
    }
}