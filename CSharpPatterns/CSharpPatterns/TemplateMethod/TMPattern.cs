using System;

namespace CSharpPatterns.TemplateMethod
{
    public abstract class Game
    {
        //we are defining a template method in the base class, which is composed of several abstract invocation
        //in the derived class, we define what the abstract methods implementations are
        public void Run()
        {
            Start();
            while (!HaveWinner)
            {
                TakeTurn();
            }
            Console.WriteLine($"Player {WinningPlayer} wins");
        }


        protected int currentPlayer;
        protected readonly int numberOfPlayers;
        protected abstract bool HaveWinner { get; }
        protected abstract int WinningPlayer { get; }
        protected abstract void Start();
        protected abstract void TakeTurn();


        protected Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }
    }

    public class Chess:Game
    {
        private int Turn = 1;
        private int maxTurns = 10;
        public Chess() : base(2)
        {
        }

        protected override bool HaveWinner => Turn == maxTurns;
        protected override int WinningPlayer => currentPlayer;
        protected override void Start()
        {
            Console.WriteLine($"Starting a game of chess with {numberOfPlayers} players.");
        }

        protected override void TakeTurn()
        {
            Console.WriteLine($"Turn {Turn++} taken by player {currentPlayer}");
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        }
    }


    //functional template mathod
    public static class GameTemplate
    {
        public static void Run(
            Action start,
            Action takeTurn,
            Func<bool> haveWinner,
            Func<int> winningPlayer
        )
        {
            start();
            while (!haveWinner())
            {
                takeTurn();
            }

            Console.WriteLine($"Player {winningPlayer} wins.");
        }
    }
}
