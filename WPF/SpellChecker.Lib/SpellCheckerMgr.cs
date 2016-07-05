using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SpellChecker.Lib.Extensions;
using SpellChecker.Lib.Helpers;

namespace SpellChecker.Lib
{
    public class SpellCheckerMgr
    {

        #region property
        /// <summary>
        /// Get the path of the assembly the code is in
        /// http://stackoverflow.com/questions/52797/how-do-i-get-the-path-of-the-assembly-the-code-is-in
        /// </summary>
        public static string ResourceFilePath
        {
            get { return "SpellChecker.Lib.BinFiles."; }
        }

        public static Assembly LibAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        #endregion

        /// <summary>
        /// Search a word to see if it is in a specific binary file. Example, if given word is "yellow", this method searches it in bin file named "y.bin"
        /// </summary>
        /// <param name="checkedWord">given word to be checked</param>
        /// <returns></returns>
        public static bool SearchWord(string checkedWord)
        {
            if (string.IsNullOrWhiteSpace(checkedWord))
            {
                return true;
            }

            checkedWord = checkedWord.ToLower(); // important
            checkedWord = trimParenthesisese(checkedWord);

            // numeric string
            // http://stackoverflow.com/questions/6733652/how-can-i-check-if-a-string-is-a-number
            if (isNumericWord(checkedWord))
            {
                return true;
            }

            
            if (isSpecialWord(checkedWord))
            {
                return false;
            }

            // important steps:
            // . or ; in the last char like "father." (period) | "me," (comma)  | "table;" (semicolon)
            var cleanedSw = Regex.Replace(checkedWord, "[^A-Za-z]", ""); // http://stackoverflow.com/questions/15837180/replace-all-non-word-characters-with-a-space           
            
            // http://stackoverflow.com/questions/3314140/how-to-read-embedded-resource-text-file
            var assembly = LibAssembly;
            var resourceName = getResourceFileName(cleanedSw);

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    var dbwords = result.Split(new char[] { Constants.WordEndDelimiter[0] });
                    return dbwords.Any(w => w.Equals(cleanedSw, StringComparison.InvariantCultureIgnoreCase));
                }
            }
        }
        

        /// <summary>
        /// Get list of suggested (nearest) words based on wanted levenshteinPrecisionDistance.
        /// </summary>
        /// <param name="checkedWord">given word to be checked</param>
        /// <param name="levenshteinPrecisionDistance">The smaller distance is, the higher similarity gets</param>
        /// <returns></returns>
        public static List<string> GetSuggestedWords(string checkedWord, int levenshteinPrecisionDistance)
        {
            if (string.IsNullOrWhiteSpace(checkedWord) || isSpecialWord(checkedWord))
            {
                return new List<string>();
            }

            checkedWord = checkedWord.ToLower(); // important
            checkedWord = Regex.Replace(checkedWord, "[^A-Za-z]", ""); // http://stackoverflow.com/questions/15837180/replace-all-non-word-characters-with-a-space
            var assembly = LibAssembly;
            var resourceName = getResourceFileName(checkedWord);
            var list = new List<string>();
            var delimiter = (byte)(Constants.WordEndDelimiter[0]);

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    var dbwords = result.Split(new char[] { Constants.WordEndDelimiter[0] });

                    foreach (var word in dbwords)
                    {
                        var dist = DamerauLevenshtein.ComputeEditDistance(word, checkedWord);
                        if (dist <= levenshteinPrecisionDistance && !string.IsNullOrWhiteSpace(word))
                        {
                            list.Add(word.Trim());
                        }
                    }
                    return list;
                }
            }
        }


        #region private methods


        private static string getResourceFileName(string checkedWord)
        {
            string fileName = $"{ResourceFilePath}{checkedWord.First()}{Constants.DataFileExtension}";
            return fileName;
        }

        /// <summary>
        /// 74gh, %^ehfk, -book, *&fl78, +98 --> found = false (because we cannot find out BIN file with first letter is numeric or special keys on keyboard
        /// </summary>
        /// <param name="checkedWord"></param>
        /// <returns></returns>
        private static bool isSpecialWord(string checkedWord)
        {
            var firstChar = checkedWord.ToLower()[0];
            var found = Constants.Alphabet.Any(c => c == firstChar);
            return !found;
        }

        /// <summary>
        /// If so, it is numeric: 56, 387.10 --> found = true
        /// </summary>
        /// <param name="checkedWord"></param>
        /// <returns></returns>
        private static bool isNumericWord(string checkedWord)
        {
            double num;
            if (double.TryParse(checkedWord, out num))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// trim "(days" into "days"
        /// </summary>
        /// <param name=""></param>
        /// <param name="checkedWord"></param>
        /// <returns></returns>
        private static string trimParenthesisese(string checkedWord)
        {
            var ca = new char[] {'(', ')'};
            checkedWord = checkedWord.Trim(ca);
            return checkedWord;
        }

        #endregion
    }
}

