using System;

namespace SpellChecker.Lib.Helpers
{
    internal class DamerauLevenshtein
    {
        public static int ComputeEditDistance(string compareString, string targetString)
        {
            // http://www.schiffhauer.com/c-levenshtein-distance/

            var compareLength = compareString.Length;
            var targetLength = targetString.Length;
            var difference = new int[compareLength + 1, targetLength + 1];

            if (compareLength == 0)
            {
                return targetLength;
            }

            if (targetLength == 0)
            {
                return compareLength;
            }

            for (var i = 0; i <= compareLength; difference[i, 0] = i++)
            {
            }

            for (var j = 0; j <= targetLength; difference[0, j] = j++)
            {
            }

            for (var i = 1; i <= compareLength; i++)
            {
                for (var j = 1; j <= targetLength; j++)
                {
                    var cost = (targetString[j - 1] == compareString[i - 1]) ? 0 : 1;
                    difference[i, j] = Math.Min(Math.Min(difference[i - 1, j] + 1, difference[i, j - 1] + 1), difference[i - 1, j - 1] + cost);
                }
            }
            return difference[compareLength, targetLength];
        }
    }
}
