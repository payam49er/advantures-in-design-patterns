using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPatterns.ObserverPattern
{
    public class Event
    {
        
    }

    public class FallsIllEvent:Event
    {
        public string Address;
    }


    public class SpecialPerson:IObservable<Event>  //when you observe it, it generates an event
    {


        private readonly HashSet<Subscription> subscriptions = new HashSet<Subscription>();
        

        public IDisposable Subscribe(IObserver<Event> observer)
        {
            var subscription = new Subscription(this,observer);
            subscriptions.Add(subscription);
            return subscription;
        }

        private class Subscription:IDisposable
        {
            private readonly SpecialPerson _person;
            public readonly IObserver<Event> observer;
            public Subscription(SpecialPerson person,IObserver<Event> observer)
            {
                this._person = person;
                this.observer = observer;
            }

            public void Dispose()
            {
                _person.subscriptions.Remove(this);
            }
        }

        public void FallIll()
        {
            foreach (Subscription subscription in subscriptions)
            {
                subscription.observer.OnNext(new FallsIllEvent{Address = "Brooklyn, NY"});
            }
        }
    }

    public class MyObserver:IObserver<Event>
    {
        public void OnCompleted()
        {
            //We are going to ignore this now
            //This method accepts a completed event/signal that tells us 
            //there will be no more event coming from a particular object
        }

        public void OnError(Exception error)
        {
            //We are going to ignore this method as well
            //This method tells us that there has been an error in the stream of events
        }

        public void OnNext(Event value)
        {
            if(value is FallsIllEvent args)
                Console.WriteLine($"A doctor is required at {args.Address}");
        }
    }
}
