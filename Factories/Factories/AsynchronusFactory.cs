using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    class AsynchronusFactory
    {
        private AsynchronusFactory()
        {
            // 
            Console.WriteLine("I am calling from the constructor");
        }

        private async Task<AsynchronusFactory> CreateAsync()
        {
            //some awaitable task
            await Task.Delay(1000);
            return this;
        }

        public static Task<AsynchronusFactory> CreateAsyncObject()
        {
            var obj = new AsynchronusFactory();
            return obj.CreateAsync();
        }
    }
}
