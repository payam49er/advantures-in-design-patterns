using System;

namespace BuilderReview
{
    class Program
    {
        static void Main ( string[] args )
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
