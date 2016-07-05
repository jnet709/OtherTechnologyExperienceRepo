using System.Collections.Generic;

namespace SpellChecker.Lib.Extensions
{
    internal static class EnumerableExtensions
    {
        // http://stackoverflow.com/questions/17754777/reading-a-binary-file-and-using-new-line-as-a-delimiter-to-create-binary-chunks

        //For a source containing N delimiters, returns exactly N+1 lists
        public static IEnumerable<List<byte>> SplitOn(this IEnumerable<byte> source, byte delimiter)
        {
            var list = new List<byte>();
            foreach (var item in source)
            {
                if (delimiter.Equals(item))
                {
                    yield return list;
                    list = new List<byte>();
                }
                else
                {
                    list.Add(item);
                }
            }
            yield return list;
        }

        /*
        Usage:
            var path = "binary-file.bin";
            var delimiter = (byte)'\n';
            var chunks = File.ReadAllBytes(path)
                .SplitOn(delimiter)
                .ToList();
        */
    }
}
