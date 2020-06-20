using System;
using System.Collections.Generic;
using CSharpPatterns.StrategyPattern;
using NUnit.Framework;

namespace XTestPatterns
{
    [TestFixture]
    public class StrategyDemo
    {

        [Test]
        public void TestStrategy()
        {
            var tp = new TextProcessor();
            tp.SetOutputFormat(OutputFormat.Markdown);
            tp.AppendList(new []{"foo","bar","baz"});
            Console.WriteLine(tp);

            tp.Clear();
            tp.SetOutputFormat(OutputFormat.Html);
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(tp);
        }

        [Test]
        public void TestStrategyEquality()
        {
            var peopel = new List<StrategyPerson>();
            peopel.Sort((x,y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal));

            //using IComparer and the strategy pattern built in .Net 
            peopel.Sort(StrategyPerson.IdNameAgeComparer);
        }
    }
}
