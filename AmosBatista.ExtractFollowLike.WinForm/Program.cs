﻿using System;
using System.Windows.Forms;

namespace AmosBatista.ExtractFollowLike.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new frmExtractRTFromUser());
            //System.Windows.Forms.Application.Run(new frmStatusList());
        }
    }
}
