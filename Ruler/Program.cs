using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruler
{
    internal static class Program
    {
        internal static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Ruler";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Window());
        }
    }
}
