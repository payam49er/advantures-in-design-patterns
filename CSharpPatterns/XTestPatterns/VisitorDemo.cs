using System;
using System.Text;
using CSharpPatterns.VisitorPattern;
using NUnit.Framework;

namespace XTestPatterns
{
    [TestFixture]
    public class VisitorDemo
    {
        [Test]
        public void TestExpression()
        {
            var e = new AdditionExpression(new DoubleExpression(1),
                new AdditionExpression(new DoubleExpression(2),new DoubleExpression(3) ) );
            var sb = new StringBuilder();
            e.Print(sb);
            Console.WriteLine(sb);
        }

        [Test]
        public void TestDynamicExpression()
        {
            Expression e = new AdditionExpression(new DoubleExpression(1),
                new AdditionExpression(new DoubleExpression(2), new DoubleExpression(3)));
            var ep = new ExpressionPrinter();
            var sb = new StringBuilder();
            ep.Print((dynamic)e,sb);
            Console.WriteLine(sb);
        }

        [Test]
        public void TestAcyclic()
        {
            var e = new VExpression.VAdditionExpression(
                left: new VExpression.VDoubleExpression(1),
                right: new VExpression.VAdditionExpression(
                    left: new VExpression.VDoubleExpression(2),
                    right: new VExpression.VDoubleExpression(3)));
            var ep = new VExpression.VExpressionPrinter();
            ep.Visit(e);
            Console.WriteLine(ep);
        }
    }
}
