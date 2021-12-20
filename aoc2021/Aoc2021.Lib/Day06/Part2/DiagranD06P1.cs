using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day06.Part2
{

    public class PuzzleD06P2
    {
        public class Pool
        {
            public Dictionary<int,long> Fishes { get; }
            public Pool()
            {
                Fishes = new Dictionary<int, long>()
                {
                    {0, 0},
                    {1, 0},
                    {2, 0},
                    {3, 0},
                    {4, 0},
                    {5, 0},
                    {6, 0},
                    {7, 0},
                    {8, 0}
                };
            }

            public long NumberOfFishes => Fishes.Sum(f => f.Value);

            public void CreateFish(string timers)
            {
                foreach (var timerText in timers.Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    var timer = int.Parse(timerText.Trim());
                    CreateFish(timer, 1);
                }
            }
            public void CreateFish(int timer, long count)
            {
                Fishes[timer] += count;
            }

            public void NextDay()
            {
                var prev0 = Fishes[0];
                Fishes[0] = Fishes[1];
                Fishes[1] = Fishes[2];
                Fishes[2] = Fishes[3];
                Fishes[3] = Fishes[4];
                Fishes[4] = Fishes[5];
                Fishes[5] = Fishes[6];
                Fishes[6] = Fishes[7] + prev0;
                Fishes[7] = Fishes[8];
                Fishes[8] = prev0;
            }
            public Pool AfterOneDays()
            {
                NextDay();
                return this;
            }
            public Pool AfterDays(int days)
            {
                for (var day = 0; day < days; day++)
                {
                    NextDay();
                }
                return this;
            }
        }
    }
}