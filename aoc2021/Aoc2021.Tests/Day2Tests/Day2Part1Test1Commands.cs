using System;
using Aoc2021.Lib.Day1;
using Aoc2021.Lib.Day1.Part1;
using Aoc2021.Lib.Day2.Part1;
using Xunit;
using Shouldly;

namespace Aoc2021.Tests
{
    public class Day2Part1Test1Commands
    {
        [Theory]
        [InlineData("forward 5", Directions.Forward, 5)]
        [InlineData("forward -1", Directions.Forward, -1)]
        [InlineData("forward 70999", Directions.Forward, 70999)]
        [InlineData("down 15", Directions.Down, 15)]
        [InlineData("up  8", Directions.Up, 8)]
        public void TestCommands(string commandText, Directions direction, int steps)
        {
            var command = new Command(commandText);
            command.Direction.ShouldBe(direction);
            command.Steps.ShouldBe(steps);
        }

        [Fact]
        public void TestInvalidCommand01()
        {
            Assert.Throws<ArgumentException>(() => new Command("abc 12"));
        }
        
        [Fact]
        public void TestInvalidCommand02()
        {
            Assert.Throws<FormatException>(() => new Command("forward 12!"));
        }
        
        [Fact]
        public void TestInvalidCommand03()
        {
            Assert.Throws<ArgumentException>(() => new Command("forward 12 3"));
        }
    }
}