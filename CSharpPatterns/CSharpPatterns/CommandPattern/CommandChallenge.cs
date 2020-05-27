using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPatterns.CommandPattern
{
    public class CommandChallenge
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;
    }

    public class Account
    {
        public int Balance { get; set; }

        public void Process ( CommandChallenge c )
        {
            // todo
            switch (c.TheAction)
            {
                case CommandChallenge.Action.Deposit:

                    Balance += c.Amount;
                    c.Success = true;
                    break;
                case CommandChallenge.Action.Withdraw:
                    if (Balance >= c.Amount)
                    {
                        Balance -= c.Amount;
                        c.Success = true;
                    }
                    else
                    {
                        c.Success = false;
                    }

                    break;
            }
        }
    }
}

