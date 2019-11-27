using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace maximum_path
{
   public static class GFG
    {
        public static Dictionary<int, bool> PrimeCache = new Dictionary<int, bool>();
        public static string GetInput()
        {

            const string Question3Data = @"   1
                                             8 4
                                            2 6 9
                                           8 5 9 3";



            const string Question4Data =
                                    @"215
                                     193 124
                                     117 237 442
                                     218 935 347 235
                                     320 804 522 417 345
                                     229 601 723 835 133 124
                                     248 202 277 433 207 263 257
                                     359 464 504 528 516 716 871 182
                                     461 441 426 656 863 560 380 171 923
                                     381 348 573 533 447 632 387 176 975 449
                                     223 711 445 645 245 543 931 532 937 541 444
                                     330 131 333 928 377 733 017 778 839 168 197 197
                                     131 171 522 137 217 224 291 413 528 520 227 229 928
                                     223 626 034 683 839 053 627 310 713 966 629 817 410 121
                                     924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";


            return Question4Data;
        }
        public static string[] TransformInputToArray(this string input)
        {
            return input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static int[,] TransformTo2Darray(this string[] arrayOfRowsByNewlines)
        {
            var tableHolder = new int[arrayOfRowsByNewlines.Length, arrayOfRowsByNewlines.Length + 1];

            for (var row = 0; row < arrayOfRowsByNewlines.Length; row++)
            {
                var eachCharactersInRow = arrayOfRowsByNewlines[row].ExtractNumber();

                for (var column = 0; column < eachCharactersInRow.Length; column++)
                    tableHolder[row, column] = eachCharactersInRow[column];
            }
            return tableHolder;
        }
        private static int[] ExtractNumber(this string rows)
        {
            return
                Regex
                    .Matches(rows, "[0-9]+")
                    .Cast<Match>()
                    .Select(m => int.Parse(m.Value)).ToArray();
        }
        public static int[,] ResetAllPrimeNumbers(this int[,] tableHolder)
        {
            var length = tableHolder.GetLength(0);
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    if (tableHolder[i, j] == 0) continue;
                    if (IsPrime(tableHolder[i, j]))
                        tableHolder[i, j] = 0;

                }
            }
            return tableHolder;
        }
        public static int WalkThroughTheNode(this int[,] tableHolder)
        {
            var tempresult = tableHolder;
            var length = tableHolder.GetLength(0);
            var count = 0;
            // walking through the non-prime node

            for (var i = length - 2; i >= 0; i--)
            {
                for (var j = 0; j < length; j++)
                {




                    if (tableHolder[i, j] == 0) continue;

                    else tableHolder[i, j] = tempresult[i, j] + Math.Max(tempresult[i + 1, j], tempresult[i + 1, j + 1]); count++;

                }
            }
            return tableHolder[0, 0];
        }
        private static bool IsPrime(this int number)
        {
            // Test whether the parameter is a prime number.
            if (PrimeCache.ContainsKey(number))
            {
                bool value;
                PrimeCache.TryGetValue(number, out value);
                return value;
            }
            if ((number & 1) == 0)
            {
                if (number == 2)
                {
                    if (!PrimeCache.ContainsKey(number)) PrimeCache.Add(number, true);
                    return true;
                }
                if (!PrimeCache.ContainsKey(number)) PrimeCache.Add(number, false);
                return false;
            }

            for (var i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0)
                {
                    if (!PrimeCache.ContainsKey(number)) PrimeCache.Add(number, false);
                    return false;
                }
            }
            var check = number != 1;
            if (!PrimeCache.ContainsKey(number)) PrimeCache.Add(number, check);
            return check;
        }

    }
}
