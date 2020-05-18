using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Text;
using Dynamitey.DynamicObjects;
using ImpromptuInterface;
using static System.Console;

namespace CSharpPatterns.Proxy
{
    public interface IBankAccount
    {
        void Deposit ( int amount );
        bool Withdraw ( int amount );
        string ToString ();
    }

    public class BankAccount : IBankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit ( int amount )
        {
            balance += amount;
            WriteLine($"Deposited ${amount}, balance is now {balance}");
        }

        public bool Withdraw ( int amount )
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                WriteLine($"Withdrew ${amount}, balance is now {balance}");
                return true;
            }
            return false;
        }

        public override string ToString ()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    public class Log<T> : DynamicObject where T:class,new()
    {
        private readonly T subject;
        private Dictionary<string,int> methodCallCount = new Dictionary<string,int>();

        protected Log(T subject)
        {
            this.subject = subject;
        }

        //creating a factory method to force our dynamic object to behave as if it implements a particular interface
        public static I As<I>() where I : class
        {
            if(!typeof(I).IsInterface)
                throw new ArgumentException("I must be an interface");
            return new Log<T>(new T()).ActLike<I>();
        }



        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                WriteLine($"Invoking {subject.GetType().Name}.{binder.Name} with arguments [{string.Join(",",args)}]");
                if (methodCallCount.ContainsKey(binder.Name))
                {
                    methodCallCount[binder.Name]++;
                }
                else
                {
                    methodCallCount.Add(binder.Name,1);
                }

                result = subject.GetType().GetMethod(binder.Name).Invoke(subject, args);
                return true;
            }
            catch (Exception e)
            {
                result = null;
                return false;
            }
        }

        public string info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (KeyValuePair<string, int> keyValuePair in methodCallCount)
                {
                    sb.AppendLine($"{keyValuePair.Key} called {keyValuePair.Value} times");
                }

                return sb.ToString();
            }
        }

        public override string ToString()
        {
            return $"{info} \n {subject}";
        }
    }

}
