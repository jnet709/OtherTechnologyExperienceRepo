using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Wpf.Helpers.UI
{
    public static class WindowExtensions
    {
        public static void KevinCenterWindowOnScreen(this System.Windows.Window window)
        {
            var screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            var screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            var windowWidth = window.Width;
            var windowHeight = window.Height;
            window.Left = (screenWidth / 2) - (windowWidth / 2);
            window.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
