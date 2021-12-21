using System.Collections.Generic;
using System.Linq;
using Aoc2021.Lib.Day1.Part1;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day1.Part2
{
    public class SubmarinePart2
    {
        public SubmarinePart2()
        {
            HasDepthRegistered = false;
            DepthBuffer = new Queue<int>(3);
        }
        public bool HasDepthRegistered { get; set; }

        public static SubmarinePart2 ReadLines(string text)
        {
            var result = new SubmarinePart2();

            foreach (var line in text.LineByLine(true))
            {
                result.RegisterDepth(int.Parse(line));
            }

            return result;
        }

        public int LastDepth { get; private set; }
        public Queue<int> DepthBuffer { get; private set; }

        public int NumberOfDepthIncreases { get; set; }

        public void RegisterDepth(int depth)
        {
            DepthBuffer.Enqueue(depth);
            if (DepthBuffer.Count == 3)
            {
                RegisterDepthIncreases(DepthBuffer.Sum(d => d));
                DepthBuffer.Dequeue();
            }
        }
        
        public void RegisterDepthIncreases(int depth)
        {
            if (HasDepthRegistered)
            {
                if (depth > LastDepth) NumberOfDepthIncreases++;
            }
            else
            {
                HasDepthRegistered = true;
            }

            LastDepth = depth;
        }
    }
}