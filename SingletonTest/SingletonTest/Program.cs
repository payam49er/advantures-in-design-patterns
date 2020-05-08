using System;

namespace SingletonTest
{

    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var a = func.Invoke();
            var b = func.Invoke();
            return ReferenceEquals(a, b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

