using System;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day2.Part1
{
    public class SubmarineD2P1
    {
        public SubmarineD2P1()
        {
            HorizontalPosition = 0;
            Depth = 0;
        }

        public int HorizontalPosition { get; private set; }
        public int Depth { get; private set; }

        public long MultiplyResult => (1L * Depth * HorizontalPosition);

        public static SubmarineD2P1 Moves(string text)
        {
            var result = new SubmarineD2P1();

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
                    break;
                case Directions.Down:
                    Depth += command.Steps;
                    break;
                case Directions.Up:
                    Depth -= command.Steps;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Invallid direction: '{command.Direction}'");
            }
        }
    }
}