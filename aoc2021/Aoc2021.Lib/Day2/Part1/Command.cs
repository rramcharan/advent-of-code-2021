using System;

namespace Aoc2021.Lib.Day2.Part1
{
    public class Command
    {
        public Command(string text)
        {
            var splitted = text.Split(" ");
            if (splitted.Length != 2)
                throw new ArgumentException($"Invalid command: '{text}'", nameof(text));
            Direction = Enum.Parse<Directions>(splitted[0], true);
            Steps = Int32.Parse(splitted[1]);
        }

        public Directions Direction { get;}
        public int Steps { get; set; }
        
    }
}