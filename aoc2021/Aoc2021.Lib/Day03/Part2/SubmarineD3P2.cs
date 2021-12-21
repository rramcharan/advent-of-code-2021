using System;
using System.Collections.Generic;
using System.Linq;
using Aoc2021.Lib.Helper;

namespace Aoc2021.Lib.Day3.Part1
{
    public class SubmarineD3P2
    {
        private readonly int _capacity;

        public SubmarineD3P2(int capacity)
        {
            _capacity = capacity;
            BinaryNumbers = new List<BinaryNumber>();
            DiagnosticReport = new DiagnosticReportNumbers();
            for(var idx=0; idx<capacity;idx++)
            {
                BinaryNumbers.Add(new BinaryNumber(capacity-idx));
            };
        }

        public int GammaRate => BinaryNumbers.Sum(b => b.GammaRate);

        public int EpsilonRate => BinaryNumbers.Sum(b => b.EpsilonRate);

        public int PowerConsumption => GammaRate * EpsilonRate;

        public int OxygenGeneratorRating => CalculateRating(1);
        public int Co2ScrubberRating => CalculateRating(0);

        public int LifeSupportRating => OxygenGeneratorRating * Co2ScrubberRating;
        public long LifeSupportRatingLong => 1L * OxygenGeneratorRating * Co2ScrubberRating;
        
        public List<BinaryNumber> BinaryNumbers { get; }
        public DiagnosticReportNumbers DiagnosticReport { get; }


        public static SubmarineD3P2 RegisterDiagnosticInput(int capacity, string text)
        {
            var result = new SubmarineD3P2(capacity);
        
            foreach (var line in text.LineByLine(true))
            {
                result.RegisterSingleDiagnosticInput(line);
            }

            //result.Calculate();
            return result;
        }

        // private void Calculate()
        // {
        //     CalculateOxygenGeneratorRating();
        // }
        //
        // private void CalculateOxygenGeneratorRating()
        // {
        //     OxygenGeneratorRating = CalculateRating(1);
        // }
        //
        // private void CalculateOxygenGeneratorRating()
        // {
        //     Co2ScrubberRating = CalculateRating(0);
        // }

        private int CalculateRating(int leadingNumber)
        {
            // calculate the oxygen generator rating

            IEnumerable<bool[]> allNumbers = DiagnosticReport.AllNumbers;
            for (var idx = 0; idx < _capacity; idx++)
            {
                allNumbers = MostCommonNumber(allNumbers, idx, leadingNumber);
                if (allNumbers.Count() == 1)
                {
                    return allNumbers.First().ToInt();
                }
            }

            throw new Exception($"Can't calculate rating for leading number: {leadingNumber}");

        }

        

        public IEnumerable<bool[]> MostCommonNumber(IEnumerable<bool[]> allNumbers, int idx, int leadingNumber)
        {
            var ones = allNumbers.Count(n => n[idx]);
            var zeros = allNumbers.Count(n => n[idx] == false);

            var filterValue = leadingNumber == 1
                ? ones == zeros || ones>zeros
                : zeros != ones && zeros > ones;
            
            var filteredNumbers =  allNumbers.Where(n => n[idx] == filterValue);
            return filteredNumbers;
        }

        public void RegisterSingleDiagnosticInput(string binaryNumbers)
        {
            if (binaryNumbers.Length != _capacity)
                throw new ArgumentException($"Invalid binary numbers: '{binaryNumbers}'. Too many numbers: {binaryNumbers.Length}");
            var numbers = new bool[_capacity];
            for (var idx = 0; idx < _capacity; idx++)
            {
                var number = int.Parse(binaryNumbers.Substring(idx, 1));
                numbers[idx] = number == 1;
                UpdateBinaryNumber(idx, number);
            }
            DiagnosticReport.Add(numbers);
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

        public class DiagnosticReportNumbers
        {
            public DiagnosticReportNumbers()
            {
                AllNumbers = new List<bool[]>();
            }
            public List<bool[]> AllNumbers { get; set; }

            public void Add(bool[] numbers)
            {
                AllNumbers.Add(numbers);
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