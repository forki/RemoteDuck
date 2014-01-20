using System;
using System.IO;
using System.Windows.Forms;
using RemoteDuck.Model;

namespace RemoteDuck
{
    static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Loader.Load(Path.Combine(Path.GetTempPath(), "RemoteDuck"))) 
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RemoteDuckForm());
        }
    }
}