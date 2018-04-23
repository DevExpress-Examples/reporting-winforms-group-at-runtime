Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports DevExpress.XtraReports.Configuration
' ...

Namespace DataGrouping
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Function CreateDataGroupingReport() As XtraReport
            ' Create a report.
            Dim report As New XtraReport()

            ' Create a data source with the required connection parameters.  
            Dim connectionParameters As New Access97ConnectionParameters("../../nwind.mdb", "", "")
            Dim ds As New SqlDataSource(connectionParameters)
            Dim query As New CustomSqlQuery()
            query.Name = "customQuery"
            query.Sql = "SELECT * FROM CategoryProducts"
            ds.Queries.Add(query)
            ds.RebuildResultSchema()

            ' Assign the data source to the report.
            report.DataSource = ds
            report.DataMember = "customQuery"

            ' Create a detail band and add it to the report.
            Dim detail As DetailBand = New DetailBand With {.HeightF = 40}
            report.Bands.Add(detail)

            ' Create a group header band and add it to the report.
            Dim ghBand As GroupHeaderBand = New GroupHeaderBand With {.HeightF = 40}
            report.Bands.Add(ghBand)

            ' Create a group field and assign it to the group header band.
            Dim groupField As New GroupField("CategoryName")
            ghBand.GroupFields.Add(groupField)

            ' Create new labels.
            Dim labelGroup As XRLabel = New XRLabel With {.ForeColor = System.Drawing.Color.Blue}
            Dim labelDetail As XRLabel = New XRLabel With {.LocationF = New System.Drawing.PointF(30, 0)}

            ' Specify labels' bindings depending on the report's data binding mode.
            If Settings.Default.UserDesignerOptions.DataBindingMode = DataBindingMode.Bindings Then
                labelGroup.DataBindings.Add("Text", Nothing, "customQuery.CategoryName")
                labelDetail.DataBindings.Add("Text", Nothing, "customQuery.ProductName")
            Else
                labelGroup.ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", "[CategoryName]"))
                labelDetail.ExpressionBindings.Add(New ExpressionBinding("BeforePrint", "Text", "[ProductName]"))
            End If
            ' Add these labels to the report's bands.    
            ghBand.Controls.Add(labelGroup)
            detail.Controls.Add(labelDetail)

            Return report
        End Function

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a grouping report and show its print preview.
            Dim report As XtraReport = CreateDataGroupingReport()
            Dim printTool As New ReportPrintTool(report)
            printTool.ShowPreview()
        End Sub

    End Class
End Namespace

