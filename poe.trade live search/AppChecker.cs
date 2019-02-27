using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace poe.trade_live_search
{
    class AppChecker
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
        public static bool IsApplicationActivated(string processName)
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
                return false;

            GetWindowThreadProcessId(activatedHandle, out int activeProcId);
            foreach (Process s in Process.GetProcessesByName(processName))
            {
                if (s.Id == activeProcId)
                    return true;
            }
            return false;
        }
    }
}
