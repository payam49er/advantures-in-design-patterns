using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderPattern
{
    public class FuncPerson
    {
        public string Name, Position;
    }

    //public sealed class FuncPersonBuilder
    //{
    //    private readonly List<Func<FuncPerson, FuncPerson>> actions = new List<Func<FuncPerson, FuncPerson>>();

    //    public FuncPersonBuilder Called(string name) => Do(p => p.Name = name);
    //   // public FuncPersonBuilder WorkAtAs(string position) => Do(w => w.Position = position);

    //    public FuncPerson Build() => actions.Aggregate(new FuncPerson(), (p, f) => f(p));

    //    public FuncPersonBuilder Do(Action<FuncPerson> action) => AddAction(action);

    //    private FuncPersonBuilder AddAction(Action<FuncPerson> action)
    //    {
    //        actions.Add(p =>
    //        {
    //            action(p);
    //            return p;
    //        });
    //        return this;
    //    }
    //}

    //we can't inheriet from sealed classed, but we can use extension methods to expand them
    public static class FuncPersonBuilderExtension
    {
        public static FuncPersonBuilder WorksAs ( this FuncPersonBuilder personBuilder, string position )
        {
            return personBuilder.Do(p => p.Position = position);
        }
    }


    //Let's generalize the codes above. The pattern above can be used in many places. in a functional way, we implement a bunch of actions on a list of objects 
    // and building an object

    /// <summary>
    /// Here we are enforcing the first type TSubject to be newed by the consumer, and we have seen the TSelf pattern as recursive generic
    /// which helps to create fluent API
    /// </summary>
    /// <typeparam name="TSubject"></typeparam>
    /// <typeparam name="TSelf"></typeparam>
    public abstract class FunctionalBuilder<TSubject, TSelf> where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

        // public TSelf Called ( string name ) => Do(p => p.Name = name);
        // public FuncPersonBuilder WorkAtAs(string position) => Do(w => w.Position = position);

        public TSubject Build () => actions.Aggregate(new TSubject(), ( p, f ) => f(p));

        public TSelf Do ( Action<TSubject> action ) => AddAction(action);

        private TSelf AddAction ( Action<TSubject> action )
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf) this;
        }
    }

    //we implement the Called method now in this implementation class, and the extension method that was created above can remain intact
    public sealed class FuncPersonBuilder : FunctionalBuilder<FuncPerson,FuncPersonBuilder>
    {
        public FuncPersonBuilder Called(string name) => Do(p => p.Name = name);
    }
}
