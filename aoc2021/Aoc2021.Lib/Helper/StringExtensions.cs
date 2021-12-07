using System;
using System.Collections.Generic;
using System.IO;

namespace Aoc2021.Lib.Helper
{
    public static class StringExtensions
    {
        public static IEnumerable<string> LineByLine(this string text, bool allowEmptyLines = false)
        {
            using StringReader reader = new StringReader(text);
            while (true)
            {
                string? line = reader.ReadLine();
                if (line == null) break;

                line = line.Trim();
                if (!allowEmptyLines)
                {
                    if (string.IsNullOrEmpty(line))
                        throw new Exception("Empty lines are not allowed");
                }

                yield return line;
            }
        }
    }

}
