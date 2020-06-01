using System;
using System.Collections.Generic;
using System.Text;
using CSharpPatterns.ObserverPattern;
using NUnit.Framework;

namespace XTestPatterns
{
    [TestFixture]
    class ObserverDemo
    {
        private void CallDoctor ( object? sender, FallsIllEventsArgs e )
        {
            Console.WriteLine($"A doctor has been called to {e.Address}");
        }


        [Test]
        public void TestObserverSample ()
        {
            var person = new Person();
            person.FallsIll += CallDoctor;

            //event happens
            person.CatchACold();


            //unsubscribe and the event handler won't be called anymore even though the event happened
            person.FallsIll -= CallDoctor;
            person.CatchACold();

        }

        [Test]
        public void TestWeakObserver ()
        {
            var btn = new Button();
            var window = new Window(btn);

            var windowRef = new WeakReference(window);

            btn.Fire();

            Console.WriteLine("setting window to null");

            window = null;

            FireGC();

            Console.WriteLine($"Is window alive after GC? {windowRef.IsAlive}");
        }

        private void FireGC ()
        {
            Console.WriteLine("Starting GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("GC is done");
        }




        [Test]
        public void TestSpecialInterfaces ()
        {
            var specialPerson = new SpecialPerson();
            var myObserver = new MyObserver();
            IDisposable subscription = specialPerson.Subscribe(myObserver);

            specialPerson.FallIll();
        }



    }




}
