using System;
using IWshRuntimeLibrary;

namespace ContunuedDesktop
{
    internal static class controlWindows
    {
     
        public static void controlW(string keys, bool wait)
        {
            WshShell shell = new WshShellClass();
            object wObj = wait;

            shell.SendKeys(keys, ref wObj);
        }
        public static void controlW(string keys)
        {
            WshShell shell = new WshShellClass();
            shell.SendKeys(keys, false);
        }

        public static void controlWindowsWait(string keys)
        {
            WshShell shell = new WshShellClass();
            shell.SendKeys(keys, true);
        }
    }
}
