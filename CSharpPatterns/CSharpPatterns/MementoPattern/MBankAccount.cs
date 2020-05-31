using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPatterns.MementoPattern
{

    public class Memento
    {
        public int Balance { get; }

        public Memento(int balance)
        {
            this.Balance = balance;
        }


    }


    public class MBankAccount
    {
        private int _balance;
        private List<Memento> _changes = new List<Memento>();
        private int current;

        public MBankAccount(int balance)
        {
            this._balance = balance;
            _changes.Add(new Memento(_balance));
        }

        public Memento Deposit(int amount)
        {
            _balance += amount;
            var m = new Memento(_balance);
            _changes.Add(m);
            ++current;
            return m;
        }

        public Memento Restore(Memento m)
        {
            if (m != null)
            {
                _balance = m.Balance;
                _changes.Add(m);
                return m;
            }

            return null;
        }

        public override string ToString()
        {
            return $"Balance: {_balance}";
        }

        public Memento Undo()
        {
            if (current > 0)
            {
                var m = _changes[--current];
                _balance = m.Balance;
                return m;
            }

            return null;
        }

        public Memento Redo()
        {
            if (current+1 < _changes.Count)
            {
                var m = _changes[++current];
                _balance = m.Balance;
                return m;
            }

            return null;
        }
    }
}
