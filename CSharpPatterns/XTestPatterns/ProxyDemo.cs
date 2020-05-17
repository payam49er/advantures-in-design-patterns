using System;
using CSharpPatterns.Proxy;
using NUnit.Framework;


namespace XTestPatterns
{
    [TestFixture]
    public class ProxyDemo
    {
       [Test]
        public void TestProxyPattern ()
        {
            Driver driver = new Driver();
            driver.Age = 22;
            ICar car = new CarProxy(driver);
            car.Drive();

        }
    }

    [TestFixture]
    public class PropertyDemo
    {

        public class Creature
        {
            private Property<int> agility = new Property<int>();

            public int Agility
            {
                get => this.agility.Value;
                set => this.agility = value;
            }
        }



        [Test]
        public void TestPropertyProxyPattern()
        {
            var c = new Creature();
            c.Agility = 100;

            c.Agility = 10;

            Console.WriteLine(c.Agility);

        }
        
    }


    [TestFixture]
    public class ValueProxy
    {
        [Test]
        public void TestValueProxy()
        {
           Console.WriteLine(10f * 5.Percent());

           Console.WriteLine(2.Percent() + 3.Percent());
        }
    }

}
