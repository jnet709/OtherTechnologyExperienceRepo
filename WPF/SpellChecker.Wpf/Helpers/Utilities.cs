using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Wpf.Helpers
{
    public static class Utilities
    {
        public static string GetUserMachineName()
        {
            return System.Environment.MachineName;
        }

        public static string GetUserName()
        {
            return Environment.UserName;
        }

        public static System.Version GetVersion()
        {
            Assembly a = Assembly.GetEntryAssembly();

            // The GetEntryAssembly method can return nullNothingnullptra null reference 
            // when a managed assembly has been loaded from an unmanaged application. 
            if (a == null)
                a = Assembly.GetExecutingAssembly();

            return a.GetName().Version;
        }
    }
}
