using System;
using System.Collections.Generic;

namespace Factories.AbstractFactory
{
    internal class TeaFactory:IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Pour {amount} ml of hot water over tea bag.");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind coffee, boil water, pour {amount} ml of hot water over coffee");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        //public enum AvailableDrink
        //{
        //    Coffee,
        //    Tea
        //}

        //private Dictionary<AvailableDrink,IHotDrinkFactory> factories = new Dictionary<AvailableDrink, IHotDrinkFactory>();

        //public HotDrinkMachine()
        //{
        //    foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
        //    {
        //        //this will create CoffeeFactory, TeaFactory
        //        var factory = (IHotDrinkFactory) Activator.CreateInstance(
        //            Type.GetType("Factories.AbstractFactory." + Enum.GetName(typeof(AvailableDrink), drink) +
        //                         "Factory"));
        //        factories.Add(drink,factory);
        //    }
        //}

        //public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        //{
        //    return factories[drink].Prepare(amount);
        //}



        //Using the above enum breaks the open and closed principle. If we want to add another 
        //drink, we need to go and manipulate a lot of code
        //we are going to use reflection to solve this issue or you can use dependency injection

        private List<Tuple<string,IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();
        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                       factories.Add(Tuple.Create(t.Name.Replace("Factory",string.Empty),(IHotDrinkFactory)Activator.CreateInstance(t))); 
                }
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.WriteLine("Available Drinks");
            for (var index = 0; index < factories.Count; index++)
            {
                Tuple<string, IHotDrinkFactory> factory = factories[index]; 
                Console.WriteLine($"{index}:{factory.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null && int.TryParse(s,out int i) && i>=0 && i < factories.Count)
                {
                    Console.WriteLine("specify amount");
                    s = Console.ReadLine();
                    if (s != null && int.TryParse(s, out int amount) && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }

                }

                Console.WriteLine("Incorrect input, try agian");
            }
        }

    }
}
