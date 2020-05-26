using System;
using CSharpPatterns.ChainOfResponsibility;
using NUnit.Framework;

namespace XTestPatterns
{
    [TestFixture]
    public class ChainOfResponsibilityDemo
    {

        [Test]
        public void TestCreatureModifier()
        {
            var goblin = new Creature("Goblin",2,2);
            Console.WriteLine(goblin);

            CreatureModifier root = new CreatureModifier(goblin);
            Console.WriteLine("Doubling Gblin's attacks");
            root.Add(new DoubleAttackModifier(goblin));
            root.Handle();
            Console.WriteLine(goblin);

            root.Add(new NoBonusesModifier(goblin));
            root.Handle();

            root.Add(new IncreaseDefenseModifier(goblin));
            root.Handle();
            Console.WriteLine(goblin);

           

            root.Add(new IncreaseDefenseModifier(goblin));
            root.Handle();
            Console.WriteLine(goblin);

            root.Add(new IncreaseDefenseModifier(goblin));
            root.Handle();
            Console.WriteLine(goblin);

        }


        [Test]
        public void TestBrokerChainOfResponsibility()
        {
            var game = new Game();
            var goblin = new BrokerCreature(game, "Better Goblin",2,2);
            using (new BrokerCreature.BrokerDoubleAttackModifier(game,goblin))
            {
                Console.WriteLine(goblin);

                using (new BrokerCreature.BrokerIncreaseDefenseModifier(game,goblin))
                {
                    Console.WriteLine(goblin);
                }
            }

            Console.WriteLine(goblin);
        }

        [Test]
        public void ChailChallengeTest()
        {
            var challengeGame = new ChallengeGame();
            var goblin = new Goblin(challengeGame);
            challengeGame.Creatures.Add(goblin);
            Assert.That(goblin.Attack,Is.EqualTo(1));
            Assert.That(goblin.Defense,Is.EqualTo(1));
        }

    }
}
