using System;
using System.Collections.Generic;
using System.Text;

namespace Factories.AbstractFactory
{
    internal class Coffee:IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("this coffee is great, I am going to drink it");
        }
    }
}
