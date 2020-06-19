using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using CSharpPatterns.StatePattern;
using CSharpPatterns.TemplateMethod;
using Dynamitey.DynamicObjects;
using NUnit.Framework;
using Action = CSharpPatterns.StatePattern.Action;
using static CSharpPatterns.StatePattern.StatePatternSwitchExpression;

namespace XTestPatterns
{
    [TestFixture]
    public class StateDemo
    {
        [Test]
        public void DemoManualState ()
        {
            Dictionary<State, List<(Trigger, State)>> rules = new Dictionary<State, List<(Trigger, State)>>
            {
                [State.OffHook] = new List<(Trigger, State)> { (Trigger.CallDialed, State.Connecting) },

                [State.Connecting] = new List<(Trigger, State)>
                {
                    (Trigger.HungUp, State.OffHook),
                    (Trigger.CallConnected, State.Connected)
                },
                [State.Connected] = new List<(Trigger, State)>
                {
                    (Trigger.LeftMessage, State.OffHook),
                    (Trigger.HungUp, State.OffHook),
                    (Trigger.PlacedOnHold, State.OnHold)
                },
                [State.OnHold] = new List<(Trigger, State)>
                {
                    (Trigger.TakenOffHold, State.Connected),
                    (Trigger.HungUp, State.OffHook)
                }
            };


            var state = State.OffHook;
            while (true)
            {
                Console.WriteLine($"The phone is currently {state}");
                Console.WriteLine("Select a trigger: ");
                for (var index = 0; index < rules[state].Count; index++)
                {
                    var (t, _) = rules[state][index];
                    Console.WriteLine($"{index}. {t}");
                }

                int input = int.Parse(Console.ReadLine());
                var (_, s) = rules[state][input];
                state = s;
            }
        }


        [Test]
        public void TestChest()
        {
            var chest = Chest.Locked;
            Console.WriteLine($"Chest is {chest}");

            chest =  Manipulate(chest, Action.Open, true);
            Console.WriteLine($"Chest is {chest}");

            chest = Manipulate(chest, Action.Close, false);
            Console.WriteLine($"Chest is {chest}");

            chest = Manipulate(chest, Action.Close, false);
            Console.WriteLine($"Chest is {chest}");
        }
    }
}
