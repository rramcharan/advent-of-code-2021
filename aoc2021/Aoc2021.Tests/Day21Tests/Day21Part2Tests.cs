using System.Collections.Generic;
using Aoc2021.Lib.Day07.Part1;
using Aoc2021.Lib.Day21.Part1;
using Shouldly;
using Xunit;

namespace Aoc2021.Tests.Day21Tests
{
    public class Day21Part2Tests
    {
        [Fact]
        public void TestDiracDice01()
        {
            var dice = new PuzzleD21P2.DiracDice();
            dice.NbrOfUniverses.ShouldBe(0);

            dice.RoleDices();
            dice.NbrOfUniverses.ShouldBe(3);
            dice.Universes[0].StartingNumber.ShouldBe(1);
            dice.Universes[1].StartingNumber.ShouldBe(2);
            dice.Universes[2].StartingNumber.ShouldBe(3);

            dice.RoleDices();
            dice.NbrOfUniverses.ShouldBe(3);
        }

        [Fact]
        public void TestExample01()
        {
            var player1 = new PuzzleD21P2.Player(4);
            var player2 = new PuzzleD21P2.Player(8);
            
            player1.Rolls(1+2+3);
            player1.Position.ShouldBe(10);
            player1.Score.ShouldBe(10);
            
            player2.Rolls(4+5+6);
            player2.Position.ShouldBe(3);
            player2.Score.ShouldBe(3);
            
            player1.Rolls(7+8+9);
            player1.Position.ShouldBe(4);
            player1.Score.ShouldBe(14);
            
            player2.Rolls(10+11+12);
            player2.Position.ShouldBe(6);
            player2.Score.ShouldBe(9);
            
            player1.Rolls(13+14+15);
            player1.Position.ShouldBe(6);
            player1.Score.ShouldBe(20);
            
            player2.Rolls(16+17+18);
            player2.Position.ShouldBe(7);
            player2.Score.ShouldBe(16);
        }
        
        [Fact]
        public void TestExample02()
        {
            var game = PuzzleD21P2.Start(4,8);
            var player1 = game.Player1;
            var player2 = game.Player2;

            game.RoleDice();
            player1.Position.ShouldBe(10);
            player1.Score.ShouldBe(10);
            
            game.RoleDice();
            player2.Position.ShouldBe(3);
            player2.Score.ShouldBe(3);
            
            game.RoleDice();
            player1.Position.ShouldBe(4);
            player1.Score.ShouldBe(14);
            
            game.RoleDice();
            player2.Position.ShouldBe(6);
            player2.Score.ShouldBe(9);
            
            game.RoleDice();
            player1.Position.ShouldBe(6);
            player1.Score.ShouldBe(20);
            
            game.RoleDice();
            player2.Position.ShouldBe(7);
            player2.Score.ShouldBe(16);
        }

        [Fact]
        public void TestExampleAutoPlay()
        {
            var game = PuzzleD21P2.Start(4,8);
            var player1 = game.Player1;
            var player2 = game.Player2;

            game.Play();
            game.Winner.ShouldBe(player1);
            player1.Position.ShouldBe(10);
            player1.Score.ShouldBe(1000);
            
            game.Looser.ShouldBe(player2);
            player2.Position.ShouldBe(3);
            player2.Score.ShouldBe(745);
            
            game.Dice.Dice.ShouldBe(93);
            game.Dice.NbrOfUniverses.ShouldBe(993);

            game.TotalScoreLoose.ShouldBe(739785);
        }

        [Fact]
        public void TextPuzzel()
        {
            var game = PuzzleD21P2.Start(10,8);
            game.Play();
            game.TotalScoreLoose.ShouldBe(752247);
        }
    }
}