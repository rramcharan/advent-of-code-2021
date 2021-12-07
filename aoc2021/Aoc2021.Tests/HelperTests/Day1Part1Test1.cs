using System.Collections.Generic;
using Aoc2021.Lib.Helper;
using Shouldly;
using Xunit;

namespace Aoc2021.Tests.HelperTests
{
    public class BooleanArrayHelperTests
    {
        [Theory]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("100", 4)]
        [InlineData("101", 5)]
        [InlineData("111", 7)]
        [InlineData("10111", 23)]
        [InlineData("00010111", 23)]
        public void Test01(string binText, int expected)
        {
            var bools = new List<bool>();
            for (var idx = 0; idx < binText.Length; idx++)
            {
                bools.Add(binText.Substring(idx, 1) == "1");
            }

            var actual = bools.ToArray().ToInt();
            actual.ShouldBe(expected);
        }
    }
}