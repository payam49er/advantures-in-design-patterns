using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpPatterns.CommandPattern;
using NUnit.Framework;

namespace XTestPatterns
{
    [TestFixture]
    public class CommandDemo
    {

        [Test]
        public void Demo()
        {
            var ba = new BankAccount();
            var commands = new List<BankAccountCommand>
            {
                new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100),
                new BankAccountCommand(ba, BankAccountCommand.Action.WithDraw, 1000)
            };

            Console.WriteLine(ba);

            foreach (var command in commands)
            {
                command.Call();
            }

            //using Enumerable.Reverse because we want to start from last to go to first. Reverse is part of List API, and it is mutating API. 
            
            foreach (var command in Enumerable.Reverse(commands))
            {
                command.Undo();
            }

        }



        [Test]
        public void TestCompositeCommand()
        {
            var ba = new BankAccount();
            var deposit = new BankAccountCommand(ba,BankAccountCommand.Action.Deposit,100);
            var withdraw = new BankAccountCommand(ba,BankAccountCommand.Action.WithDraw,50);
            var composite = new CompositeBankAccountCommand(new[] {deposit, withdraw});

            composite.Call();
            Console.WriteLine(ba);

            composite.Undo();
            Console.WriteLine(ba);
        }

        [Test]

        public void TestCompositeTransferMoney()
        {
            var from = new BankAccount();
            from.Deposit(1000);
            var to = new BankAccount();

            var mtc = new MoneyTransferCommand(from, to ,250);
            mtc.Call();

            Console.WriteLine(from);
            Console.WriteLine(to);


            mtc.Undo();

            Console.WriteLine(from);
            Console.WriteLine(to);

        }

        [Test]

        public void TestCommandChallenge()
        {
            var cm = new CommandChallenge();

            cm.Amount = 100;
            cm.TheAction = CommandChallenge.Action.Deposit;
            cm.Success = true;

            var cm2 = new CommandChallenge();
            cm2.Amount = 100;
            cm2.TheAction = CommandChallenge.Action.Withdraw;



            var acc = new Account();

            acc.Process(cm);
            Console.WriteLine(acc.Balance);


            acc.Process(cm2);

            Console.WriteLine(acc.Balance);
        }
    }
}

