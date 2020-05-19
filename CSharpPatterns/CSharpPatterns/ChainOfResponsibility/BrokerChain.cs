using System;

namespace CSharpPatterns.ChainOfResponsibility
{
    //this is chain of responsibility + mediator
    public class Game
    {
        public event EventHandler<Query> Queries;

        public void PerformQuery(object sender,Query q)
        {
            Queries?.Invoke(sender,q);
        }
    }

    public class Query
    {
        public string CreatureName;
        public enum Argument
        {
            Attack,
            Defense
        }

        public Argument WhatToQuery;
        public int Value;

        public Query(string creatureName, Argument whatToQuery, int value)
        {
            CreatureName = creatureName;
            WhatToQuery = whatToQuery;
            this.Value = value;
        }
    }


    public class BrokerCreature
    {
        private Game game;
        public string Name;
        private int attack, defense;

        public BrokerCreature(Game game, string name, int attack, int defense)
        {
            this.game = game;
            Name = name;
            this.attack = attack;
            this.defense = defense;
        }

        public int Attack
        {
            get
            {
                var q = new Query(Name,Query.Argument.Attack,attack);
                game.PerformQuery(this,q); // q.value
                return q.Value;
            }
        }

        public int Defense
        {
            get
            {
                var q = new Query(Name, Query.Argument.Defense, defense);
                game.PerformQuery(this, q); // q.value
                return q.Value;
            }

        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }


        public abstract class BrokerCreatureModifier: IDisposable
        {
            protected Game game;
            protected BrokerCreature creature;

            protected BrokerCreatureModifier(Game game, BrokerCreature creature)
            {
                this.game = game;
                this.creature = creature;
                game.Queries += Handle;

            }

            protected abstract void Handle(object sender, Query q);
            public void Dispose()
            {
                game.Queries -= Handle;
            }
        }


        public class BrokerDoubleAttackModifier:BrokerCreatureModifier
        {
            public BrokerDoubleAttackModifier(Game game, BrokerCreature creature) : base(game, creature)
            {
            }

            protected override void Handle(object sender, Query q)
            {
                if (q.CreatureName == creature.Name && q.WhatToQuery == Query.Argument.Attack)
                {
                    q.Value *= 2;
                }
            }
        }

        public class BrokerIncreaseDefenseModifier:BrokerCreatureModifier
        {
            public BrokerIncreaseDefenseModifier(Game game, BrokerCreature creature) : base(game, creature)
            {
            }

            protected override void Handle(object sender, Query q)
            {
                if (q.CreatureName == creature.Name && q.WhatToQuery == Query.Argument.Defense)
                {
                    q.Value += 3;
                }
            }
        }
    
    }
}
