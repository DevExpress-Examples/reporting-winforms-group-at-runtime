using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataGrouping {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //Uncomment this line to switch to the legacy binding mode.  
            //DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode =
            //    DevExpress.XtraReports.UI.DataBindingMode.Bindings;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}