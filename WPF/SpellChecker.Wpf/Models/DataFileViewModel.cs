using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Wpf.Models
{
    public class DataFileViewModel
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string RootDirectory { get; set; }
    }
}
