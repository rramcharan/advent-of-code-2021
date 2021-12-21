using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day07.Part2
{

    public class PuzzleD07P2
    {
        public class Swarm
        {
            public List<Crab> Crabs { get; }
            public Swarm()
            {
                Crabs = new List<Crab>();
            }

            public int NumberOfFishes => Crabs.Count;

            public void CreateSwarm(string horizontalPositions)
            {
                foreach (var horizontalPositionText in horizontalPositions.Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    var horizontalPosition = int.Parse(horizontalPositionText.Trim());
                    CreateCrab(horizontalPosition);
                }
            }
            public void CreateCrab(int horizontalPosition)
            {
                Crabs.Add(new Crab(horizontalPosition));
            }

            public int AdjustToPosition(int moveToHorizontalPosition)
            {
                var fuel = 0;
                foreach (var crab in Crabs)
                {
                    var steps = crab.HorizontalPosition > moveToHorizontalPosition
                        ? crab.HorizontalPosition-moveToHorizontalPosition
                        : moveToHorizontalPosition-crab.HorizontalPosition;
                    fuel += FuelCalculator.Calculate(steps);
                }
                return fuel;
            }
            public int LeastFuelToSamePosition()
            {
                var leastFuel = AdjustToPosition(0);
                var max = Crabs.Max(c => c.HorizontalPosition);
                // Crabs.Select(c => c.HorizontalPosition).OrderBy(c => c).Distinct().ToList();
                for (var i = 1; i <= max; i++)
                {
                    var fuel = AdjustToPosition(i);
                    if (fuel < leastFuel)
                    {
                        leastFuel = fuel;
                    }
                }
                return leastFuel;
            }
        }
        public class Crab
        {
            public int HorizontalPosition { get; private set; }
            
            public Crab(int horizontalPosition)
            {
                HorizontalPosition = horizontalPosition;
            }
        }

        public class FuelCalculator
        {
            public static int Calculate(int steps)
            {
                return (steps * (steps+1)) / 2;
            }
        }
    }
}