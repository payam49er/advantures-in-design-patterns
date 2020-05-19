using System;
using Dynamitey.DynamicObjects;

namespace CSharpPatterns.Proxy
{
    public class ProxyChallenge
    {
        
    }
    
    public class Person
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
        
        
    }

    public class ResponsiblePerson
    {
        private readonly Person _person;

        public Person responsiblePerson
        {
            get
            {
                return _person;
            }
        }
        public ResponsiblePerson(Person person)
        {
            this._person = person;
        }
        
        

        public int Age
        {
            get
            {
                return _person.Age;
            }
            set
            {
                _person.Age = value;
            }
        }

        public string Drink()
        {
            if (_person.Age >= 18)
               return _person.Drink();
            return "too young";
        }

        public string Drive()
        {
            if (_person.Age >= 16)
                return _person.Drive();
            return "too young";
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }
    }
}