using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Data.OleDb;
// ...

namespace DataGrouping {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public XtraReport CreateDataGroupingReport() {
            // Create a report.
            XtraReport report = new XtraReport();

            // Create a data connection and data adapter.
            OleDbConnection connection = new
                OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\nwind.mdb");
            OleDbDataAdapter adapter = new
                OleDbDataAdapter("SELECT * FROM Products", connection);

            // Creata a dataset and fill it.
            DataSet dataSet1 = new DataSet();
            adapter.Fill(dataSet1, "Products");

            // Assign the data source to the report.
            report.DataSource = dataSet1;
	    report.DataMember = "Products";

            // Create a detail band and add it to the report.
            DetailBand detail = new DetailBand();
            report.Bands.Add(detail);

            // Create a group header band and add it to the report.
            GroupHeaderBand ghBand = new GroupHeaderBand();
            report.Bands.Add(ghBand);

            // Create a group field, 
            // and assign it to the group header band.
            GroupField groupField = new GroupField("CategoryID");
            ghBand.GroupFields.Add(groupField);

            // Create bound labels, and add them to the report's bands.
            XRLabel labelGroup = new XRLabel();
            labelGroup.DataBindings.Add("Text", report.DataSource, String.Format("{0}.{1}", report.DataMember, "CategoryID"));
            ghBand.Controls.Add(labelGroup);

            XRLabel labelDetail = new XRLabel();
            labelDetail.DataBindings.Add("Text", report.DataSource, String.Format("{0}.{1}", report.DataMember, "ProductName"));
            detail.Controls.Add(labelDetail);

            return report;
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create a grouping report and show its print preview.
            XtraReport report = CreateDataGroupingReport();
            report.ShowPreview();
        }

    }
}