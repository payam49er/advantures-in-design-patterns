using System;

namespace CSharpPatterns.ObserverPattern
{

    public class FallsIllEventsArgs:EventArgs
    {
        public string Address;
    }

    public class Person
    {
        public void CatchACold()
        {
            FallsIll?.Invoke(this,new FallsIllEventsArgs{Address = "Brooklyn, NY"});
        }

        public event EventHandler<FallsIllEventsArgs> FallsIll;
    }


    class ObserverSample
    {
    }
}
