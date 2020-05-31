using System;
using System.Collections.Generic;
using System.Text;
using CSharpPatterns.MementoPattern;
using NUnit.Framework;

namespace XTestPatterns
{
    [TestFixture]
    public class MementoDemo
    {
        [Test]
        public void TestMementoBank()
        {
            var ba = new MBankAccount(100);
            //    var m1 = ba.Deposit(50);
            //    var m2 = ba.Deposit(25);
            //    Console.WriteLine(ba);


            //    ba.Restore(m1);
            //    Console.WriteLine(ba);

            //    ba.Restore(m2);
            //    Console.WriteLine(ba);

            ba.Deposit(50);
            ba.Deposit(25);
            Console.WriteLine(ba);

            ba.Undo();
            Console.WriteLine($"Undo 1: {ba}");
            ba.Undo();

            Console.WriteLine($"Undo 2: {ba}");

            ba.Redo();
            Console.WriteLine($"Redo: {ba}");
        }
    }
}
