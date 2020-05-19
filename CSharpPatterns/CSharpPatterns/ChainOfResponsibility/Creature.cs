using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPatterns.ChainOfResponsibility
{
    public class Creature
    {
        public string Name;
        public int Attack, Defense;

        public Creature(string name, int attack, int defense)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }

    public class CreatureModifier
    {
        protected Creature creature;
        protected CreatureModifier next; // linked list

        public CreatureModifier(Creature creature)
        {
            this.creature = creature;
        }

        public void Add(CreatureModifier cm)
        {
            if (next != null)
            {
                next.Add(cm);
            }
            else
            {
                next = cm;
            }
        }

        public virtual void Handle() => next?.Handle();
    }


    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Doubling {creature.Name}'s attack");
            creature.Attack *= 2;
            base.Handle();
        }
    }

    public class IncreaseDefenseModifier:CreatureModifier
    {
        public override void Handle()
        {
            base.Handle();
        }

        public IncreaseDefenseModifier(Creature creature) : base(creature)
        {
            Console.WriteLine($"Increasing {creature.Name}'s defense count");
            creature.Defense +=3;
            base.Handle();
        }
    }

    public class NoBonusesModifier:CreatureModifier
    {

        public NoBonusesModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            //we do nothing
        }
    }
}
