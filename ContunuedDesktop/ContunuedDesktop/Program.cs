using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ContunuedDesktop
{
    static class Program
    {
        /// <summary>
        /// Keep the Desktop Area "alive" to prevent screensaver from interrupting file parsing.
        /// This program spoofs the excape key being pressed to circumvent the 
        /// inaccessable (due to access control policies) screen saver from kicking in.  
        /// This behavior was problematic when trying to view large data files being parsed 
        /// prgramatically and having the screen time out ...  
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ContinuedDesktopMain Desktop = new ContinuedDesktopMain();

            controlTimer();
            Application.Run(Desktop);
        }


        public static void controlTimer()
        {
            Timer timer = new Timer();
            //timer Interval in minutes
            timer.Interval = (int)(TimeSpan.TicksPerMinute * 14 / TimeSpan.TicksPerMillisecond);
            timer.Tick += (sender, args) => { Cursor.Position = new System.Drawing.Point(Cursor.Position.X + 10, Cursor.Position.Y + 10); };
            timer.Tick += (sender, args) => { controlWindows.controlW("^{ESC}"); };
            timer.Start();
        }
    }
}

