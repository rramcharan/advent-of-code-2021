using System.Collections.Generic;
using Aoc2021.Lib.Day05.Part1;
using Aoc2021.Lib.Day06.Part1;
using Shouldly;
using Xunit;

namespace Aoc2021.Tests.Day06Tests
{
    public class Day06Part1Tests
    {
        #region Test with one latern fish

        [Fact]
        public void TestWithOneFish()
        {
            var pool = new PuzzleD06P1.Pool();
            pool.CreateFish(3);
            
            pool.Fishes.Count.ShouldBe(1);
            pool.Fishes[0].Timer.ShouldBe(3);
            
            pool.NextDay();
            pool.Fishes.Count.ShouldBe(1);
            pool.Fishes[0].Timer.ShouldBe(2);
            
            pool.NextDay();
            pool.Fishes.Count.ShouldBe(1);
            pool.Fishes[0].Timer.ShouldBe(1);

            pool.NextDay();
            pool.Fishes.Count.ShouldBe(1);
            pool.Fishes[0].Timer.ShouldBe(0);

            pool.NextDay();
            pool.Fishes.Count.ShouldBe(2);
            pool.Fishes[0].Timer.ShouldBe(6);
            pool.Fishes[1].Timer.ShouldBe(8);
            
            pool.NextDay();
            pool.Fishes.Count.ShouldBe(2);
            pool.Fishes[0].Timer.ShouldBe(5);
            pool.Fishes[1].Timer.ShouldBe(7);
        }

        [Fact]
        public void TestExample01()
        {
            var pool = new PuzzleD06P1.Pool();
            pool.CreateFish("3,4,3,1,2");

            pool.Fishes.Count.ShouldBe(5);
            pool.State.ShouldBe(new List<int> { 3, 4, 3, 1, 2 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 2, 3, 2, 0, 1 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 1, 2, 1, 6, 0, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 0, 1, 0, 5, 6, 7, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 6, 0, 6, 4, 5, 6, 7, 8, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 5, 6, 5, 3, 4, 5, 6, 7, 7, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 4, 5, 4, 2, 3, 4, 5, 6, 6, 7 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 3, 4, 3, 1, 2, 3, 4, 5, 5, 6 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 2, 3, 2, 0, 1, 2, 3, 4, 4, 5 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 1, 2, 1, 6, 0, 1, 2, 3, 3, 4, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 0, 1, 0, 5, 6, 0, 1, 2, 2, 3, 7, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 6, 0, 6, 4, 5, 6, 0, 1, 1, 2, 6, 7, 8, 8, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 5, 6, 5, 3, 4, 5, 6, 0, 0, 1, 5, 6, 7, 7, 7, 8, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 4, 5, 4, 2, 3, 4, 5, 6, 6, 0, 4, 5, 6, 6, 6, 7, 7, 8, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 3, 4, 3, 1, 2, 3, 4, 5, 5, 6, 3, 4, 5, 5, 5, 6, 6, 7, 7, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 2, 3, 2, 0, 1, 2, 3, 4, 4, 5, 2, 3, 4, 4, 4, 5, 5, 6, 6, 7 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 1, 2, 1, 6, 0, 1, 2, 3, 3, 4, 1, 2, 3, 3, 3, 4, 4, 5, 5, 6, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 0, 1, 0, 5, 6, 0, 1, 2, 2, 3, 0, 1, 2, 2, 2, 3, 3, 4, 4, 5, 7, 8 });
            pool.AfterOneDays().State.ShouldBe(new List<int> { 6, 0, 6, 4, 5, 6, 0, 1, 1, 2, 6, 0, 1, 1, 1, 2, 2, 3, 3, 4, 6, 7, 8, 8, 8, 8 });
        }

        [Theory]
        [InlineData(18, 26)]
        [InlineData(80, 5934)]
        public void TestExample02(int nbrOfDays, int nbrOfFishes)
        {
            var pool = new PuzzleD06P1.Pool();
            pool.CreateFish("3,4,3,1,2");

            pool.Fishes.Count.ShouldBe(5);
            pool.AfterDays(nbrOfDays).NumberOfFishes.ShouldBe(nbrOfFishes);
        }

        [Fact]
        public void TestExampleAfter80Days()
        {
            var pool = new PuzzleD06P1.Pool();
            pool.CreateFish("3,4,3,1,2");

            pool.Fishes.Count.ShouldBe(5);
            pool.AfterDays(80).NumberOfFishes.ShouldBe(5934);
        }
        #endregion
        
        
        [Fact]
        public void TestPuzzel()
        {
            var pool = new PuzzleD06P1.Pool();
            pool.CreateFish("1,5,5,1,5,1,5,3,1,3,2,4,3,4,1,1,3,5,4,4,2,1,2,1,2,1,2,1,5,2,1,5,1,2,2,1,5,5,5,1,1,1,5,1,3,4,5,1,2,2,5,5,3,4,5,4,4,1,4,5,3,4,4,5,2,4,2,2,1,3,4,3,2,3,4,1,4,4,4,5,1,3,4,2,5,4,5,3,1,4,1,1,1,2,4,2,1,5,1,4,5,3,3,4,1,1,4,3,4,1,1,1,5,4,3,5,2,4,1,1,2,3,2,4,4,3,3,5,3,1,4,5,5,4,3,3,5,1,5,3,5,2,5,1,5,5,2,3,3,1,1,2,2,4,3,1,5,1,1,3,1,4,1,2,3,5,5,1,2,3,4,3,4,1,1,5,5,3,3,4,5,1,1,4,1,4,1,3,5,5,1,4,3,1,3,5,5,5,5,5,2,2,1,2,4,1,5,3,3,5,4,5,4,1,5,1,5,1,2,5,4,5,5,3,2,2,2,5,4,4,3,3,1,4,1,2,3,1,5,4,5,3,4,1,1,2,2,1,2,5,1,1,1,5,4,5,2,1,4,4,1,1,3,3,1,3,2,1,5,2,3,4,5,3,5,4,3,1,3,5,5,5,5,2,1,1,4,2,5,1,5,1,3,4,3,5,5,1,4,3");

            pool.Fishes.Count.ShouldBe(300);
            pool.AfterDays(80).NumberOfFishes.ShouldBe(346063);
        }
    }
}