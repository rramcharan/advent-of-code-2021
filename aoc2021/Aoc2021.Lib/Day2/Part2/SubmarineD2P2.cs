using System;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day2.Part1
{
    public class SubmarineD2P2
    {
        public SubmarineD2P2()
        {
            HorizontalPosition = 0;
            Depth = 0;
            Aim = 0;
        }

        public int HorizontalPosition { get; private set; }
        public int Depth { get; private set; }
        public int Aim { get; private set; }

        public int MultiplyResultInt => (Depth * HorizontalPosition);
        public long MultiplyResultLong => (1L * Depth * HorizontalPosition);

        public static SubmarineD2P2 Moves(string text)
        {
            var result = new SubmarineD2P2();

            foreach (var line in text.LineByLine(true))
            {
                result.MoveStep(line);
            }

            return result;
        }

        private void MoveStep(string commandText)
        {
            var command = new Command(commandText);
            switch (command.Direction)
            {
                case Directions.Forward:
                    HorizontalPosition += command.Steps;
                    Depth += Aim * command.Steps;
                    break;
                case Directions.Down:
                    Aim += command.Steps;
                    break;
                case Directions.Up:
                    Aim -= command.Steps;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Invallid direction: '{command.Direction}'");
            }
        }
    }
}