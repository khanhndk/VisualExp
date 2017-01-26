using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VisualExp
{
    static class Config
    {
        public static List<string> args;
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Config.args = new List<string>(args);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm());
        }
    }
}
