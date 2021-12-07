namespace Aoc2021.Lib.Helper
{
    public static class BooleanArrayHelper
    {
        public static int ToInt(this bool[] values)
        {
            var result = 0;
            var lenght = values.Length;
            for (var idx = 0; idx < lenght; idx++)
            {
                if (values[idx])
                {
                    var weigth = 1 << (lenght - idx - 1);
                    result += weigth;
                }
            }

            return result;
        }        
    }
}