using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day05.Part1
{

    public class DiagranD05P1
    {
        private readonly int _gridSize;
        private Cell[,] Cells { get; }

        public int NbrOfDangerousAreas => Cells.Cast<Cell?>().Count(cell => cell.NbrOfHits > 1);

        private DiagranD05P1(int gridSize)
        {
            _gridSize = gridSize;
            Cells = new Cell[gridSize, gridSize];
            for (var row = 0; row < gridSize; row++)
            {
                for (var col = 0; col < gridSize; col++)
                {
                    Cells[row, col] = new Cell();
                }
            }            
        }

        public static DiagranD05P1 Load(int gridSize, string text)
        {
            var diagram = new DiagranD05P1(gridSize);
            foreach (var line in text.LineByLine(true))
            {
                if (string.IsNullOrEmpty(line)) continue;

                var coord = new Line(line);
                diagram.Draw(coord);
            }
            return diagram;
        }

        public void Draw(Line coords)
        {
            if (coords.X1 == coords.X2 || coords.Y1 == coords.Y2)
            {
                for (var x = coords.MinX; x <= coords.MaxX; x++)
                for (var y = coords.MinY; y <= coords.MaxY; y++)
                    Cells[y, x].Hit();
            }
        }

        public string Print()
        {
            var text = new StringBuilder();
            for (var row = 0; row < _gridSize; row++)
            {
                text.AppendLine();
                for (var col = 0; col < _gridSize; col++)
                {
                    var cell = Cells[row, col];
                    text.Append(cell.NbrOfHits == 0
                        ? "."
                        : cell.NbrOfHits < 10
                            ? cell.NbrOfHits.ToString()
                            : "*");
                }
            }
            return text.ToString();
        }
        
        public class Cell
        {
            public int NbrOfHits { get; private set; }
            public void Hit()
            {
                NbrOfHits++;
            }
        }
 
        public class Line
        {
            private static string _pattern = @"^(\d+),(\d+)\s->\s(\d+),(\d+)$";
            private Regex _re = new Regex(_pattern, RegexOptions.Compiled);
            public Line(string coords)
            {
                // eg 0,19 -> 235,19
                var m = _re.Match(coords);
                if (!m.Success)
                    throw new Exception("Invalid input");
                
                X1 = int.Parse(m.Groups[1].ToString());
                Y1 = int.Parse(m.Groups[2].ToString());
                X2 = int.Parse(m.Groups[3].ToString());
                Y2 = int.Parse(m.Groups[4].ToString());
            }
            
            public int X1 { get; set; }
            public int Y1 { get; set; }
            public int X2 { get; set; }
            public int Y2 { get; set; }

            public int MinX => Math.Min(X1, X2);
            public int MaxX => Math.Max(X1, X2);
            public int MinY => Math.Min(Y1, Y2);
            public int MaxY => Math.Max(Y1, Y2);

            public override string ToString()
            {
                return $"{X1},{Y1} -> {X2},{Y2}";
            }
        }
    }
}