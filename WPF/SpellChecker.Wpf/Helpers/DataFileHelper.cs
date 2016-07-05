using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SpellChecker.Lib;
using SpellChecker.Wpf.Models;

namespace SpellChecker.Wpf.Helpers
{
    public class DataFileHelper
    {
        public static List<DataFileViewModel> GetListOfBinaryFileViewModel(string assemblyDirectory)
        {
            var dir = new DirectoryInfo(assemblyDirectory);
            var list = new List<DataFileViewModel>();
            try
            {
                list = dir.GetFiles($"*{Constants.DataFileExtension}").Select(file => new DataFileViewModel
                {
                    Name = file.Name,
                    RootDirectory = file.DirectoryName,
                    Size = file.Length,
                    UpdatedDate = file.LastWriteTime
                }).ToList();
            }
            catch (Exception)
            {
                return list;
            }

            return list;
        }
    }
}



/*
----------------
http://www.codeproject.com/Questions/479424/C-plusbinaryplusfilesplusfindingplusstrings

C# binary files finding strings

byte[] ByteBuffer = File.ReadAllBytes("SomeFilePath");
byte[] StringBytes = Encoding.UTF8.GetBytes("StringToFind");
for (i = 0; i <= (ByteBuffer.Length - StringBytes.Length); i++)
{
    if (ByteBuffer[i] == StringBytes[0])
    {
        for (j = 1; j < StringBytes.Length && ByteBuffer[i + j] == StringBytes[j]; j++) ;
        if (j == StringBytes.Length)
            Console.WriteLine("String was found at offset {0}", i);
    }
}

 Please note that this is a case-sensitive search!

--------------------------------------------------------
  Write and Read binary file C#
  https://msdn.microsoft.com/en-us/library/yzxa6408(v=vs.110).aspx

    */
