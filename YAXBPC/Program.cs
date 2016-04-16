using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YAXBPC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //CustomExceptionHandler eh = new CustomExceptionHandler();
            //Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(eh.OnThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
