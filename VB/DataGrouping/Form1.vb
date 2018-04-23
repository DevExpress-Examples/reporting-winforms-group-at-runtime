Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
Imports System.Data.OleDb
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

			' Create a data connection and data adapter.
			Dim connection As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\nwind.mdb")
			Dim adapter As New OleDbDataAdapter("SELECT * FROM Products", connection)

			' Creata a dataset and fill it.
			Dim dataSet1 As New DataSet()
			adapter.Fill(dataSet1, "Products")

			' Assign the data source to the report.
			report.DataSource = dataSet1
			report.DataMember = "Products"

			' Create a detail band and add it to the report.
			Dim detail As New DetailBand()
			report.Bands.Add(detail)

			' Create a group header band and add it to the report.
			Dim ghBand As New GroupHeaderBand()
			report.Bands.Add(ghBand)

			' Create a group field, 
			' and assign it to the group header band.
			Dim groupField As New GroupField("CategoryID")
			ghBand.GroupFields.Add(groupField)

			' Create bound labels, and add them to the report's bands.
			Dim labelGroup As New XRLabel()
			labelGroup.DataBindings.Add("Text", report.DataSource, String.Format("{0}.{1}", report.DataMember, "CategoryID"))
			ghBand.Controls.Add(labelGroup)

			Dim labelDetail As New XRLabel()
			labelDetail.DataBindings.Add("Text", report.DataSource, String.Format("{0}.{1}", report.DataMember, "ProductName"))
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