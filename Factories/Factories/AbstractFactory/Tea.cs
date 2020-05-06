using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.AbstractFactory
{
    internal class Tea:IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Hot tea is consumed with milk");
        }
    }
}
