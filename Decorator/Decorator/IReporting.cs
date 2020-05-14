using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    public interface IReporting
    {
        void Report();
    }

    public class ReportingService:IReporting
    {
        public void Report()
        {
            Console.WriteLine("Here is your report");
        }
    }

    public class ReposrtingServiceWithLogging:IReporting
    {
        private readonly IReporting decorated;
        public ReposrtingServiceWithLogging(IReporting reporting)
        {
            decorated = reporting;
        }
        public void Report()
        {
            Console.WriteLine("Logging....");
            decorated.Report();
            Console.WriteLine("Finishing the log");
        }
    }
}
