using Aoc2021.Lib.Helper;

namespace Aoc2021.Day1
{
    public class Submarine
    {
        public Submarine()
        {
            HasDepthRegistered = false;
        }
        public bool HasDepthRegistered { get; set; }

        public static Submarine ReadLines(string text)
        {
            var result = new Submarine();

            foreach (var line in text.LineByLine(true))
            {
                result.RegisterDepth(int.Parse(line));
            }

            return result;
        }

        public int Depth { get; private set; }

        public int NumberOfDepthIncreases { get; set; }

        public void RegisterDepth(int depth)
        {
            if (HasDepthRegistered)
            {
                if (depth > Depth) NumberOfDepthIncreases++;
            }
            else
            {
                HasDepthRegistered = true;
            }

            Depth = depth;
        }
    }
}