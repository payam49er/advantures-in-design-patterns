using System;
using System.Collections.Generic;
using System.Text;
using CSharpPatterns.InterpreterPattern;
using NUnit.Framework;

namespace XTestPatterns
{
    [TestFixture]
    public class InterpreterDemo
    {
        [Test]
        public void TestLex()
        {
            var input = "(13+4)-(12+1)";
            var tokens = HandMadeInterpreter.Lex(input);
            Console.WriteLine(string.Join("\t", tokens));


            var parsed = HandMadeInterpreter.Parse(tokens);

            Console.WriteLine(parsed.Value);
        }


        [Test]
        public void TestInterpreterChallenge()
        {
            var ep = new InterpreterChallenge();
           
            ep.Variables.Add('x', 5);

            Assert.That(ep.Calculate("1"), Is.EqualTo(1));

            Assert.That(ep.Calculate("1+2"), Is.EqualTo(3));

            Assert.That(ep.Calculate("1+x"), Is.EqualTo(6));

            Assert.That(ep.Calculate("1+xy"), Is.EqualTo(0));
        }
    }
}
