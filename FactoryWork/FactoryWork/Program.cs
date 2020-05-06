using System;

namespace FactoryWork
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }

    public class PersonFactory
    {
        private static int id = 0;
        public static Person CreatePerson(string name)
        {
            return new Person
            {
                Name = name,
                Id = id++
            };
        }
    }
    class Program
    {
        static void Main ( string[] args )
        {
            var fisrPerson = PersonFactory.CreatePerson("Payam");
            var secondPerson = PersonFactory.CreatePerson("Jim");
            var thirdPerson = PersonFactory.CreatePerson("Jack");

            Console.WriteLine(fisrPerson);
            Console.WriteLine(thirdPerson);
        }
    }
}
