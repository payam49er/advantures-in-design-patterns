using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Decorator
{
    public interface IBird
    {
        void Fly();
        int Weight { get; set; }
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }
        public void Fly()
        {
            Console.WriteLine($"Soaring in the sky with {Weight}");
        }
    }
}
