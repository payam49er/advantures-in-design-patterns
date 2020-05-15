using System;

namespace DecoratorPractice
{
    public class Bird
    {
        public int Age { get; set; }

        public string Fly ()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl ()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon // no need for interfaces
    {
        private readonly Bird bird;
        private readonly Lizard lizard;

        public Dragon()
        {
            bird = new Bird();
            lizard = new Lizard();
        }

        public int Age
        {
            get => this.Age;
            set
            {
                lizard.Age = value;
                bird.Age = value;
            }
        }

        public string Fly() => bird.Fly();

        public string Crawl() =>  lizard.Crawl();

    }
    class Program
    {
        static void Main ( string[] args )
        {
           Dragon dragon = new Dragon();
           dragon.Age = 15;
           Console.WriteLine(dragon.Crawl());
        }
    }
}
