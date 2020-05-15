using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public interface ICreature
    {
        int Age { get; set; }
    }


    public interface IAnotherBird:ICreature
    {
        void Fly()
        {
            if (Age >= 10)
            {
                Console.WriteLine("I am flying");
            }
        }
    }

    public class Organism{}
    public interface IAnotherLizard :ICreature
    {
        void Crawl()
        {
            if (Age < 10)
            {
                Console.WriteLine("I am crawling");
            }
        }
    }

    public class AnotherDragon: Organism,IAnotherBird,IAnotherLizard
    {
       public int Age { get; set; }

    }
}
