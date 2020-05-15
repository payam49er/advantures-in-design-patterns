using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public interface ILizard
    {
        void Crawl();
        int Weight { get; set; }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }
        public void Crawl()
        {
            Console.WriteLine($"crawling in the dirt with {Weight}");
        }

    }
}
