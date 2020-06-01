using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace CSharpPatterns.ObserverPattern
{

    public class FallsIllEventsArgs
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
