using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Lib
{
    /// <summary>
    /// The smaller distance is, the higher similarity gets
    /// </summary>
    public enum LevenshteinPrecisionDistances
    {
        NinetyPercent = 1,
        EightyPercent = 2,
        SeventyPercent = 3,
        SixtyPercent = 4,
        FiftyPercent = 5,
        FortyPercent = 6,
        ThirtyPercent = 7,
        TwentyPercent = 8
    }
}
