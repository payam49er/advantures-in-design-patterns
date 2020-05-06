using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    /// <summary>
    /// we are attempting to build fluent API through inheritance 
    /// </summary>
    public class Person
    {
        public string Name;
        public string LastName;
        public string Position;

        public class Builder:PersonJobBuilder<Builder>
        {
            
        }
        public static Builder New => new Builder();
        public override string ToString()
        {
            return $"{LastName} {Name} - works at {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();
        public Person Build() => person;
    }
    public class PersonInfoBuilder<SELF>:PersonBuilder where SELF: PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF) this;
        }
    }

    public class PersonJobBuilder<SELF>:PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF:PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position; 
            return (SELF) this;
        }
    }
}
