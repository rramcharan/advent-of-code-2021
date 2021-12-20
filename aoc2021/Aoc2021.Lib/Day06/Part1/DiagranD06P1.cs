using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day06.Part1
{

    public class PuzzleD06P1
    {
        public class Pool
        {
            public List<LanternFish> Fishes { get; }
            public Pool()
            {
                Fishes = new List<LanternFish>();
            }

            public int NumberOfFishes => Fishes.Count;
            public List<int> State => Fishes.Select(f => f.Timer).ToList();

            public void CreateFish(string timers)
            {
                foreach (var timerText in timers.Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    var timer = int.Parse(timerText.Trim());
                    CreateFish(timer);
                }
            }
            public void CreateFish(int timer)
            {
                Fishes.Add(new LanternFish(timer));
            }

            public void NextDay()
            {
                var newNumberOfFishes = 0;
                foreach (var fish in Fishes)
                {
                    var addNewFish = fish.NextDay();
                    if (addNewFish)
                    {
                        newNumberOfFishes++;
                    }
                }
                for (var i = 0; i < newNumberOfFishes; i++)
                {
                    CreateFish(8);
                }
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
        public class LanternFish
        {
            public int Timer { get; private set; }
            
            public LanternFish(int timer)
            {
                Timer = timer;
            }
            public bool NextDay()
            {
                Timer--;
                if (Timer >= 0) return false;
                
                Timer = 6;
                return true;
            }
        }
    }
}