using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpPatterns.CommandPattern
{
    public class CompositeBankAccountCommand:List<BankAccountCommand>,ICommand
    {
        public CompositeBankAccountCommand(IEnumerable<BankAccountCommand> bankAccountCommands):base(bankAccountCommands)
        {
            
        }

        protected CompositeBankAccountCommand()
        {
           
        }

        public virtual void Call()
        {
            ForEach(cmd=>cmd.Call());
        }

        public virtual void Undo()
        {
            foreach (var cmd in ((IEnumerable<BankAccountCommand>) this).Reverse())
            {
                if(cmd.Success) cmd.Undo();
            }
        }

        public virtual bool Success
        {
            get
            {
                return this.All(x => x.Success);
            }
            set
            {
                foreach (var cmd in this)
                {
                    cmd.Success = value;
                }
            }
        }
    }

    public class MoneyTransferCommand:CompositeBankAccountCommand
    {
     

        public MoneyTransferCommand(BankAccount from,BankAccount to, int amount) : base()
        {
          AddRange(new []
          {
              new BankAccountCommand(from,BankAccountCommand.Action.WithDraw,amount),
              new BankAccountCommand(to,BankAccountCommand.Action.Deposit,amount) 
          });
        }


        public override void Call()
        {
            BankAccountCommand last = null;
            foreach (var cmd in this)
            {
                if (last == null || last.Success)
                {
                    cmd.Call();
                    last = cmd;
                }
                else
                {
                    cmd.Undo();
                    break;
                }
            }
        }
    }
}
