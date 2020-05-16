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
            driver.Age = 14;
            ICar car = new CarProxy(driver);
            car.Drive();

        }
    }
}
