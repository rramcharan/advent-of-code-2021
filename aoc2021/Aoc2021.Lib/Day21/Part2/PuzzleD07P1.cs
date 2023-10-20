using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day21.Part1
{

    public class PuzzleD21P2
    {
        private PuzzleD21P2(int positionPlayer1, int positionPlayer2)
        {
            Dice = new DiracDice();
            Player1 = new Player(positionPlayer1);
            Player2 = new Player(positionPlayer2);
            TurnOfPlayer1 = true;
        }

        public static PuzzleD21P2 Start(int positionPlayer1, int positionPlayer2)
        {
            return new PuzzleD21P2(positionPlayer1, positionPlayer2);
        }
        
        public DiracDice Dice { get; private set; }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public bool TurnOfPlayer1 { get; set; }
        
        public Player? Winner { get; set; }

        public Player? Looser => Winner == null
            ? null
            : Winner == Player1
                ? Player2
                : Player1;

        public int TotalScoreLoose => Dice.NbrOfUniverses * Looser?.Score ?? 0;
        public void Play()
        {
            while (Winner == null)
            {
                RoleDice();
            }
        }
        public void RoleDice()
        {
            var dice = Dice.RoleDices();
            var player = TurnOfPlayer1 ? Player1 : Player2;
            TurnOfPlayer1 = !TurnOfPlayer1;
            player.Rolls(dice);
            if (player.Score >= 1000)
            {
                Winner = player;
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

        public class DiracDice
        {
            public DiracDice()
            {
                Universes = new List<Universe>();
            }
            public List<Universe> Universes { get;  }
            public int Dice { get; set; }
            public int NbrOfUniverses => Universes.Count;

            public int RoleDices()
            {
                var dices = NextDice() + NextDice() +NextDice();
                return dices;
            }
            
            private int NextDice()
            {
                Dice = 1+(Dice % 3);
                Universes.Add(new Universe(Dice));
                return Dice;
            }
        }

        public class Universe
        {
            public readonly int StartingNumber;
            public Universe(int startingNumber)
            {
                StartingNumber = startingNumber;

            }
        }
        // public class OneHunderedSidedDice
        // {
        //     public OneHunderedSidedDice()
        //     {
        //         NbrOfRolledDie = 0;
        //     }
        //     public int Dice { get; set; }
        //     public int NbrOfRolledDie { get; set; }
        //
        //     public int RoleDices()
        //     {
        //         var dices = NextDice() + NextDice() +NextDice();
        //         return dices;
        //
        //     }            
        //     private int NextDice()
        //     {
        //         NbrOfRolledDie++;
        //         Dice = 1+(Dice % 100);
        //         return Dice;
        //     }
        //     
        // }

    }
}