using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Lib
{
    public class Constants
    {
        public static char[] Alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public const string DataFileExtension = ".dat";
        public const string WordEndDelimiter = "^";
    }
}
