using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace iDict
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
               new System.Globalization.CultureInfo(Properties.Settings.Default.Language);
            
            bool ownsMutex;
            using (Mutex mutex = new Mutex(true, "iDict", out ownsMutex))
            {
                if (ownsMutex)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainDict());
                    mutex.ReleaseMutex();
                }
                else MessageBox.Show("The application is running", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}