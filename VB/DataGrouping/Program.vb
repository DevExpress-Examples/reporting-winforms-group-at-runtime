Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace DataGrouping
    Friend NotInheritable Class Program

        Private Sub New()
        End Sub

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread> _
        Shared Sub Main()
            'Uncomment this line to switch to the legacy binding mode.  
            'DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode =
            '    DevExpress.XtraReports.UI.DataBindingMode.Bindings;
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New Form1())
        End Sub
    End Class
End Namespace