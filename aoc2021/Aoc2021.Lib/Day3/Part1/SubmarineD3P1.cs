using System;
using System.Collections.Generic;
using System.Linq;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day3.Part1
{
    public class SubmarineD3P1
    {
        private readonly int _capacity;

        public SubmarineD3P1(int capacity)
        {
            _capacity = capacity;
            BinaryNumbers = new List<BinaryNumber>();
            for(var idx=0; idx<capacity;idx++)
            {
                BinaryNumbers.Add(new BinaryNumber(capacity-idx));
            };
        }

        public int GammaRate => BinaryNumbers.Sum(b => b.GammaRate);

        public int EpsilonRate => BinaryNumbers.Sum(b => b.EpsilonRate);

        public int PowerConsumption => GammaRate * EpsilonRate;

        public List<BinaryNumber> BinaryNumbers { get; }


        public static SubmarineD3P1 RegisterDiagnosticInput(int capacity, string text)
        {
            var result = new SubmarineD3P1(capacity);
        
            foreach (var line in text.LineByLine(true))
            {
                result.RegisterSingleDiagnosticInput(line);
            }
        
            return result;
        }

        public void RegisterSingleDiagnosticInput(string binaryNumbers)
        {
            if (binaryNumbers.Length != _capacity)
                throw new ArgumentException($"Invalid binary numbers: '{binaryNumbers}'. Too many numbers: {binaryNumbers.Length}");
            for (var idx = 0; idx < _capacity; idx++)
            {
                UpdateBinaryNumber(idx, int.Parse(binaryNumbers.Substring(idx, 1)));
            }
        }

        private void UpdateBinaryNumber(int idx, int number)
        {
            switch (number)
            {
                case 0:
                    BinaryNumbers[idx].NumberOfZeros++;
                    break;
                case 1:
                    BinaryNumbers[idx].NumberOfOnes++;
                    break;
            }
        }

        public class BinaryNumber
        {
            public int Weigth { get; }

            public BinaryNumber(int weigth)
            {
                Weigth = 1<<(weigth-1);
            }
            public int NumberOfZeros { get; set; }
            public int NumberOfOnes { get; set; }

            public int GammaRate => NumberOfOnes > NumberOfZeros ? Weigth : 0;
            public int EpsilonRate => NumberOfOnes > NumberOfZeros ? 0: Weigth;
        }
    }
}