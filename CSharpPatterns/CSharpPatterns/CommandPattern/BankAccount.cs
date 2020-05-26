using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPatterns.CommandPattern
{
    public class BankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited ${amount}, balance is now {balance}");
        }

        public bool WithDraw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine($"Withdraw ${amount}, balance is now {balance}");
                return true;
            }
            Console.WriteLine($"withdraw wasn't successful");
            return false;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}, {nameof(overdraftLimit)}: {overdraftLimit}";
        }
    }


    //building this interface to send command to an agent to make changes happen
    public interface ICommand
    {
        void Call();
        void Undo();
    }


    /// <summary>
    /// We want to command the bank account to do certain operations.
    /// The BankAccountCommand encapsulates and objectifies the commands, so we won't directly interact with the
    /// BankAccount. We can keep track of the calls and roll back if needed. 
    /// </summary>
    public class BankAccountCommand : ICommand
    {
        private BankAccount account;

        public enum Action
        {
            Deposit,
            WithDraw
        }

        private Action action;
        private int amount;
        private bool succeeded { get; set; }

        public bool Success
        {
            get => succeeded;
            set => succeeded = value;
        }
        public BankAccountCommand(BankAccount account, Action action, int amount)
        {
            this.account = account;
            this.action = action;
            this.amount = amount;
        }
        public void Call()
        {
            switch (action)
            {
                case Action.Deposit:
                    account.Deposit(amount);
                    succeeded = true;
                    break;
                case Action.WithDraw:
                    succeeded = account.WithDraw(amount);
                    break;
            }
        }

        public void Undo()
        {
            if(!succeeded) return;
            switch (action)
            {
                case Action.Deposit:
                    account.WithDraw(amount);
                    break;
                case Action.WithDraw:
                    account.Deposit(amount);
                    break;
            }
        }
    }
}
