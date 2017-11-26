// ===============================
// AUTHOR       : Maaike Burghoorn, Wouter van 't Hof
// CREATE DATE  : November 2017
// COURSE       : Multi-agent systems - Utrecht University 2017/2018
// PURPOSE      : Creation of application
// ===============================

using System;
using System.Windows.Forms;

namespace RLMAL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CasinoForm() { Text = "MAL - RL in Casino"});
        }
    }
}
