using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Decorator
{

   
    class Program
    {
        static void Main ( string[] args )
        {
            //var cb = new CodeBuilder();
            //cb.AppendLine("class Foo")
            //    .AppendLine("{")
            //    .AppendLine("}");
            //Console.Write(cb);

            //MyStringBuilder s = "Hello";
            //s += " world";
            //Console.WriteLine(s);

            //var d = new Dragon();
            //d.Weight = 120;
            //d.Fly();
            //d.Crawl();

            //AnotherDragon anotherDragon = new AnotherDragon {Age = 12};

            //pay attention to this casting! 
            //((IAnotherBird)anotherDragon).Fly(); 

            //if(anotherDragon is IAnotherBird bird)
            //    bird.Fly();

            //if(anotherDragon is IAnotherLizard lizard)
            //    lizard.Crawl();

            var square = new Square(5.6f);
            Console.WriteLine(square.AsString());

            var redSquare = new ColoredShape(square,"red");
            Console.WriteLine(redSquare.AsString());

            var transparentSquare = new TransparentShape(redSquare,0.5f);
            Console.WriteLine(transparentSquare.AsString());
        }
    }
}
