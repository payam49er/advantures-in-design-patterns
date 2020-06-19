using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Stateless;

namespace CSharpPatterns.StatePattern
{

    public enum State
    {
        OffHook,
        Connecting,
        Connected,
        OnHold
    }

    public enum Trigger
    {
        CallDialed,
        HungUp,
        CallConnected,
        PlacedOnHold,
        TakenOffHold,
        LeftMessage
    }

    //better approach is to use switch expression

    public enum Chest
    {
        Open,
        Closed,
        Locked
    }

    public enum Action
    {
        Open,
        Close
    }
    public class StatePatternSwitchExpression
    {
        //use pattern matching
        public static Chest Manipulate(Chest chest, Action action, bool haveKey) =>
            (chest, action, haveKey) switch
            {
                (Chest.Locked, Action.Open, true) => Chest.Open,
                (Chest.Closed, Action.Open, _) => Chest.Open,
                (Chest.Open, Action.Close, true) => Chest.Locked,
                (Chest.Open, Action.Close, false) => Chest.Closed,
                _ => chest
            };
    }

    //using stateless library fron Nuget
    public enum Health
    {
        NonReproductive,
        Pregnant,
        Reproductive
    }

    public enum Activity
    {
        GiveBirth,
        ReachPuberty,
        HaveAbortion,
        HaveUnprotectedSex,
        Historectomy
    }

    //public class Reproductive
    //{
    //    StateMachine<Health, Activity> nonProductiveMachine = new StateMachine<Health, Activity>(Health.NonReproductive);
        
    //}
}
