using System;
using CSharpPatterns.TemplateMethod;
using NUnit.Framework;

namespace XTestPatterns
{
    [TestFixture]
    public class TemplateMethodDemo
    {

        [Test]
        public void TestChess()
        {
            Chess chess = new Chess();
            chess.Run();
        }

        [Test]
        public void TestFunctionalTM()
        {
            int currentPlayer = 0;
            int WinningPlayer() => (currentPlayer += 1) % 2;
            int turn = 1;
            int maxTurn = 10;
            bool HaveWinner() => maxTurn == turn;
            GameTemplate.Run(
                () => { 
                    Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}");
                },
                () => { 
                    Console.WriteLine($"Player {currentPlayer} makes a move");
                    currentPlayer++;
                },
                HaveWinner,WinningPlayer);
        }
    }
}