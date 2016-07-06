using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using NGVSCAN.EXEC.Common;

namespace NGVSCAN.EXEC
{
    static class NGVSCAN
    {
        private static Mutex mutex;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            mutex = new Mutex(true, assembly.GetType().GUID.ToString());

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                mutex.ReleaseMutex();
            }
            else
            {
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero
                    );
            }
        }
    }
}
