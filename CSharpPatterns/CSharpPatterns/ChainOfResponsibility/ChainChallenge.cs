using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPatterns.ChainOfResponsibility
{
    public abstract class ChallengeCreature
    {
        public int Attack { get; set; }
        public int Defense { get; set; }

    }

    public class Goblin : ChallengeCreature
    {
        private readonly ChallengeGame _game;
        public Goblin(ChallengeGame game)
        {
            this._game = game;
        }

       
    }

    public class GoblinKing : Goblin
    {
        private readonly ChallengeGame _game;
        public GoblinKing(ChallengeGame game):base(game)
        {
            this._game = game;
        }



    }

    public class ChallengeGame
    {
        public IList<ChallengeCreature> Creatures;
  

    }
   
}
