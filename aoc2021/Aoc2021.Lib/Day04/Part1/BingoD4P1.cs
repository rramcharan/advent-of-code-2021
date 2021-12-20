using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day04.Part1
{
    public class BingoD4P1
    {
        private static int[] _drawnNumbers;
        private static int _drawnNumbersIdx;
        public List<Board> Boards { get; set; }

        public BingoD4P1()
        {
            Boards = new List<Board>();
        }

        public static BingoD4P1 Load(string lines)
        {
            var result = new BingoD4P1();
            var numbersDrawnLine = true;
            var linesBoard = new StringBuilder();
            var nbrOfLines = 0;
            foreach (var line in lines.LineByLine(true))
            {
                if(string.IsNullOrWhiteSpace(line)) continue;

                if (numbersDrawnLine)
                {
                    SetDrawnNumbers(line);
                    numbersDrawnLine = false;
                }
                else
                {
                    linesBoard.AppendLine(line);
                    nbrOfLines++;

                    if (nbrOfLines == 5)
                    {
                        var board = BingoD4P1.Board.Load(result.Boards.Count+1, linesBoard.ToString());
                        result.Boards.Add((board));
                        linesBoard.Clear();
                        nbrOfLines = 0;
                    }

                }
            }
            return result;
        }
        private static void SetDrawnNumbers(string line)
        {
            _drawnNumbers = line.Split(",").Select(int.Parse).ToArray();
            _drawnNumbersIdx = 0;
        }

        public bool IsBingo => Boards.Any(b => b.IsBingo);
        //public List<int> BoardsWithBingo => Boards.Where(b => b.IsBingo).Select(b => b.BoardNumber).ToList();
        public List<Board> BoardsWithBingo => Boards.Where(b => b.IsBingo).ToList();
        public int NbrOfNumbersDrawn = 0;

        public class Board
        {
            private int _lastNumber;
            public const int GridSize = 5;
            public Board(int boardNumber)
            {
                BoardNumber = boardNumber;
                IsBingo = false;
                IsBingoOnRow = -1;
                IsBingoOnCol = -1;
                Cells = new Cell[GridSize, GridSize];
                for (var row = 0; row < GridSize; row++)
                {
                    for (var col = 0; col < GridSize; col++)
                    {
                        var cell = new Cell();
                        Cells[row, col] = cell;
                        cell.Row = row;
                        cell.Column = col;
                    }
                }
            }

            public static Board Load(int boardNumber, string lines)
            {
                var board = new Board(boardNumber);
                var row = 0;
                foreach (var line in lines.LineByLine(true))
                {
                    if (string.IsNullOrEmpty(line)) continue;
                    var parts = line.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(t => ToInt(t)).ToList();
                    board.SetRow(row, parts);
                    row++;
                }
                return board;
            }

            public int BoardNumber { get; set; }
            private static int ToInt(string text)
            {
                return int.Parse(text);
            }
            private void SetRow(int row, List<int> parts)
            {
                if (parts.Count > GridSize)
                    throw new Exception($"Invalid row data. Too many cols: {string.Join(" ", parts)}");
                
                for (var col = 0; col < GridSize; col++)
                {
                    var cell = Cells[row, col];
                    cell.Number = parts[col];
                }
            }

            public string Print()
            {
                var text = new StringBuilder();
                for (var row = 0; row < GridSize; row++)
                {
                    for (var col = 0; col < GridSize; col++)
                    {
                        var space = col == GridSize-1 ? "" : " ";
                        var cell = Cells[row, col];
                        var number = cell.Number;
                        var numText = cell.IsDrawn
                            ? $"({number,2})"
                            : $"{number,4}";
                        text.Append($"{numText}{space}");
                    }
                    if (row < GridSize-1)
                    {
                        text.AppendLine();
                    }
                }
                return text.ToString();
            }

            private Cell[,] Cells { get; }
            public bool IsBingo { get; set; }
            public int IsBingoOnRow { get; set; }
            public int IsBingoOnCol { get; set; }

            public int SumUnmarked => (from Cell? cell in Cells where !cell.IsDrawn select cell.Number).Sum();
            public int Score => SumUnmarked * _lastNumber;

            public void Draw(int number)
            {
                _lastNumber = number;
                var cell = FindCellByNumber(number);
                if (cell != null)
                {
                    cell.IsDrawn = true;
                    CheckForBingo(cell.Row, cell.Column);
                }
            }
            private void CheckForBingo(int row, int col)
            {
                CheckForBingoForRow(row);
                CheckForBingoForCol(col);
            }
            private void CheckForBingoForRow(int row)
            {
                for (var col = 0; col < GridSize; col++)
                {
                    if (!Cells[row, col].IsDrawn) return;
                }
                IsBingo = true;
                IsBingoOnRow = row;
            }
            private void CheckForBingoForCol(int col)
            {
                for (var row = 0; row < GridSize; row++)
                {
                    if (!Cells[row, col].IsDrawn) return;
                }
                IsBingo = true;
                IsBingoOnCol = col;
            }

            public Cell FindCellByNumber(int number)
            {
                foreach (var cell in Cells)
                {
                    if (cell.Number == number)
                    {
                        return cell;
                    }
                }
                return null;
            }
            public List<int> DrawnNumbers()
            {
                return (from Cell? cell in Cells where cell.IsDrawn select cell.Number).ToList();
            }
        }

        public class Cell
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public int Number { get; set; }
            public bool IsDrawn { get; set; }
        }
        public void Draw(int nbrOfCardsToBeDrawn)
        {
            for (int nbr = 0; nbr < nbrOfCardsToBeDrawn; nbr++)
            {
                Draw();
            }
        }

        private void Draw()
        {
            NbrOfNumbersDrawn++;
            var number = DrawNextNumber();
            foreach (var board in Boards)
            {
                board.Draw(number);
            }
        }
        private int DrawNextNumber()
        {
            var number = _drawnNumbers[_drawnNumbersIdx];
            _drawnNumbersIdx++;
            return number;
        }
        public void DrawNumbers()
        {
            while(!IsBingo) Draw();
        }
    }
}