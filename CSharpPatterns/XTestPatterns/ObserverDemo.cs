using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
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

        [Test]
        public void TestingBindingList()
        {
            var markets = new Market();
            markets.Prices.ListChanged += (sender, eventargs) =>
            {
                if (eventargs.ListChangedType == ListChangedType.ItemAdded)
                {
                    float price = ((BindingList<float>) sender)[eventargs.NewIndex];
                    Console.WriteLine($"Binding list got a price of {price}");
                }
            };
        }


        [Test]
        public void TestPropertyChange()
        {
            var product = new Product {Name = "Book"};
            var biWindow = new BiWindow {ProductName = "Book"};

            product.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Name")
                {
                    Console.WriteLine("Name changed in product");
                    biWindow.ProductName = product.Name;
                    Console.WriteLine($"BiWindow product name changed: {biWindow.ProductName}");
                }
            };

            biWindow.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "ProductName")
                {
                    Console.WriteLine("BiWindow property name changed");
                    product.Name = biWindow.ProductName;
                    Console.WriteLine($"Product Name {product.Name}");
                }
            };


            product.Name = "Smart Book";

            biWindow.ProductName = "Fiction Book";
        }

        [Test]
        public void TestPropertyChangeBidirectional()
        {
            var product = new Product { Name = "Book" };
            var biWindow = new BiWindow { ProductName = "Book" };

            using (var binding = new BirectionalBinding(
                    product,
                    ()=>product.Name,
                    biWindow,
                    () => biWindow.ProductName
            ))
            {
                Console.WriteLine("Name changed in product");
                product.Name = "Smart Book";
                Console.WriteLine($"BiWindow product name changed: {biWindow.ProductName}");
                Console.WriteLine($"Product Name {product.Name}");

                Console.WriteLine("BiWindow property name changed");
                biWindow.ProductName = "Fiction Book";
                Console.WriteLine($"Product Name {product.Name}");

                Console.WriteLine($"BiWindow product name changed: {biWindow.ProductName}");
            }
        }
    }
}
