using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MoreLinq;

namespace Singleton
{

    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class Database:IDatabase
    {
        private static readonly string Path =
            "[path to this file]/capitals.txt";
        private Dictionary<string, int> capitals = new Dictionary<string, int>();
        
        //let's declare it as lazy, so we would initialize it only when it is really called for. 
        private static Lazy<Database> instance => new Lazy<Database>(()=>new Database());
        public static Database Instance => instance.Value;

        private Database()
        {
            capitals = File.ReadAllLines(Path).Batch(2)
                .ToDictionary(x => x.ElementAt(0).Trim(), x => int.Parse(x.ElementAt(1))); 
        }
        
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }

    public class SingletonRecordFinder
    {
        public int GetToalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += Database.Instance.GetPopulation(name);
            }

            return result;
        }
    }
    
    //Since singleton pattern can't give us the changes in a live database, we implement a Dummy database that
    //doesn't depend on a static reference to the database

    public class ConfigurableRecordFinder
    {
        // with this pattern, you can decide whhat database you want to feed into the constructor, and later use. 
        private IDatabase _database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            _database = database;
        }
        
        public int GetToalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += _database.GetPopulation(name);
            }

            return result;
        }
    }

    public class DummyDatabase:IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>()
            {
                ["Tokyo"] = 1,
                ["New York"] = 2,
                ["Mexico City"] = 3
            }[name];
        }
    }

    public class OrdinaryDatabse:IDatabase
    {
        private static readonly string Path =
            "/Users/pshoghi/Code/advantures-in-design-patterns/Singleton/Singleton/capitals.txt";
        private Dictionary<string, int> capitals = new Dictionary<string, int>();

        public OrdinaryDatabse()
        {
            capitals = File.ReadAllLines(Path).Batch(2)
                .ToDictionary(x => x.ElementAt(0).Trim(), x => int.Parse(x.ElementAt(1)));  
        }

            public int GetPopulation(string name)
            {
                return capitals[name];
            }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Singleton through dependency injection");
            var collection = new ServiceCollection();
            collection.AddSingleton<IDatabase, OrdinaryDatabse>();
            var serviceProvider = collection.BuildServiceProvider();
            var service = serviceProvider.GetService<IDatabase>();
            var tokyoPop = service.GetPopulation("Tokyo");
            Console.WriteLine($"Tokyo population is {tokyoPop}");
            
            
            SingletonRecordFinder recordFinder = new SingletonRecordFinder();
            var result = recordFinder.GetToalPopulation(new[] {"Tokyo", "New York"});
            Console.WriteLine($"Total Population {result}");
            
            var configurableRecordFinder = new ConfigurableRecordFinder(new DummyDatabase());
            var total = configurableRecordFinder.GetToalPopulation(new[] {"New York", "Tokyo"});
            Console.WriteLine(total);
            
            
            Console.WriteLine("A variation of singleton, which is MonoState");
            var ceo1 = new MonoState()
            {
                Name = "Payam",
                Position = "CEO",
                Age = 100
            };

            var ceo2 = new MonoState()
            {
                Name = "Jack",
                Position = "Developer",
                Age = 90
            };
            
            Console.WriteLine(ceo1);
            Console.WriteLine(ceo2);
        }
    }
}