using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day21.Part1
{

    public class PuzzleD21P1
    {
        private PuzzleD21P1(int positionPlayer1, int positionPlayer2)
        {
            Player1 = new Player(positionPlayer1);
            Player2 = new Player(positionPlayer2);
            TurnOfPlayer1 = true;
            NbrOfRolledDie = 0;
        }

        public static PuzzleD21P1 Start(int positionPlayer1, int positionPlayer2)
        {
            return new PuzzleD21P1(positionPlayer1, positionPlayer2);
        }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public int NbrOfRolledDie { get; set; }
        public int Dice { get; set; }
        public bool TurnOfPlayer1 { get; set; }
        
        public void RoleDice()
        {
            var dice = NextDice() + NextDice() +NextDice();
            var player = TurnOfPlayer1 ? Player1 : Player2;
            TurnOfPlayer1 = !TurnOfPlayer1;
            player.Rolls(dice);
            if (player.Score >= 1000)
            {
                Winner = player;
            }
        }
        public Player? Winner { get; set; }

        public Player? Looser => Winner == null
            ? null
            : Winner == Player1
                ? Player2
                : Player1;

        public int TotalScoreLoose => NbrOfRolledDie * Looser?.Score ?? 0;
        private int NextDice()
        {
            NbrOfRolledDie++;
            Dice = 1+(Dice % 100);
            return Dice;
        }
        public void Play()
        {
            while (Winner == null)
            {
                RoleDice();
            }
        }
        
        public class Player
        {
            public Player(int position)
            {
                Position = position;
                Score = 0;
            }
            public int Position { get; private set; }
            public int Score { get; set; }
            public void Rolls(int steps)
            {
                Position = 1 + ((Position+steps-1) % 10);
                Score += Position;
            }
        }

    }
}