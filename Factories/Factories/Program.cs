using System;
using System.Threading.Tasks;
using Factories.AbstractFactory;

namespace Factories
{
    class Program
    {
        static async Task Main ( string[] args )
        {
            var point =  Point.Factory.NewCartisianPoint(5.5, 4.3);
            var ppoint = Point.Factory.NewPolarPoint(1.0, Math.PI/2);

            Console.WriteLine($"Cartesian point: {point.ToString()}");
            Console.WriteLine($"Polar point: {ppoint.ToString()}");

            Console.WriteLine("Async factory usage:");

            var asc = await AsynchronusFactory.CreateAsyncObject();

            Console.WriteLine("Abstract Factory");
            
            var machine = new HotDrinkMachine();
            machine.MakeDrink();
            

        }
    }
}
