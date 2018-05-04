using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Crystal
{
    static class Program
    {
        public static Settings settings;

        public static Book book;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{
            //    var dllDirectory = Path.GetDirectoryName(Application.ExecutablePath) + @"\Plugins";
            //    Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + dllDirectory);
            //}
            //catch (Exception e)
            //{

            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
