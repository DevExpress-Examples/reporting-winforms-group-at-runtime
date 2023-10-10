Imports System
Imports System.Windows.Forms

Namespace DataGrouping

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            'Uncomment this line to switch to the legacy binding mode.  
            'DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode =
            '    DevExpress.XtraReports.UI.DataBindingMode.Bindings;
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Call Application.Run(New Form1())
        End Sub
    End Module
End Namespace
