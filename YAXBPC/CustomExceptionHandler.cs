using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace YAXBPC
{
    internal class CustomExceptionHandler
    {

        // Handles the exception event.
        public void OnThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = this.ShowThreadExceptionDialog(t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Error", "Fatal Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        // Creates the error message and displays it.
        private DialogResult ShowThreadExceptionDialog(Exception e)
        {
            string errorMsg = "An error occurred please contact the adminstrator with the following information:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
        }
    }
}
