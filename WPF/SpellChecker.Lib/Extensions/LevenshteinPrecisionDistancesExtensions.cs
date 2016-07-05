using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellChecker.Lib.Models;

namespace SpellChecker.Lib.Extensions
{
    public static class LevenshteinPrecisionDistancesExtensions
    {
        /// <summary>
        /// get all branch types in list of TextValue objects
        /// </summary>
        /// <returns></returns>
        public static List<TextValue> ToList()
        {
            return (from LevenshteinPrecisionDistances type in Enum.GetValues(typeof (LevenshteinPrecisionDistances))
                    select new TextValue {text = GetNameByEnum(type), value = (int) type}).ToList();
        }

        /// <summary>
        /// get name of an enum object
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static string GetNameByEnum(this LevenshteinPrecisionDistances distance)
        {
            return new GenericTypeExtensions().GetNameByEnum(distance);
        }

    }
}
