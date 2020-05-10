using System;
using System.Net.Sockets;

namespace Prototype
{
    public class Program
    {
        public class Person
        {
            public Person()
            {
                
            }
            internal string[] Names;
            public Address Address;

            public Person(string[] names, Address address)
            {
                this.Names = names;
                Address = address;
            }

          
            public override string ToString()
            {
                return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
            }
            
            //Doing prototyping by Copy Constructor
            // public Person(Person other)
            // {
            //     Names = other.Names;
            //     Address = new Address(other.Address);
            // }

        }
        
        public class Address
        {
            public Address()
            {
                
            }
            // public Address(Address otherAddress)
            // {
            //     StreetName = otherAddress.StreetName;
            //     HouseNumber = otherAddress.HouseNumber;
            // }
            
            public Address(string streetName, int houseNumber)
            {
                StreetName = streetName;
                HouseNumber = houseNumber;
            }
            public string StreetName;
            public int HouseNumber;

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
            }
        }
        
        
        
        
        static void Main(string[] args)
        {
            var john = new Person(new []{"John","Smith"},new Address("Park Ave",100));
            var jane = john.DeepCopyXml();
            jane.Names = new[] {"Jane", "Jackson"};
            jane.Address.HouseNumber = 221;
            Console.WriteLine(john);
            Console.WriteLine(jane);

            var jack = john;

        }
    }

   
}