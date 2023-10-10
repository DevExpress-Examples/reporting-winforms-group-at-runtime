using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.Configuration;
// ...

namespace DataGrouping {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public XtraReport CreateDataGroupingReport() {
            // Create a report.
            XtraReport report = new XtraReport();

            // Create a data source with the required connection parameters.  
            Access97ConnectionParameters connectionParameters =
                new Access97ConnectionParameters("../../nwind.mdb", "", "");
            SqlDataSource ds = new SqlDataSource(connectionParameters);   
            CustomSqlQuery query = new CustomSqlQuery();
            query.Name = "customQuery";
            query.Sql = "SELECT * FROM CategoryProducts";
            ds.Queries.Add(query);
            ds.RebuildResultSchema();

            // Assign the data source to the report.
            report.DataSource = ds;
            report.DataMember = "customQuery";

            // Create a detail band and add it to the report.
            DetailBand detail = new DetailBand { HeightF = 20 };
            report.Bands.Add(detail);

            // Create a group header band and add it to the report.
            GroupHeaderBand ghBand = new GroupHeaderBand { HeightF = 20 };
            report.Bands.Add(ghBand);

            // Create a group field and assign it to the group header band.
            GroupField groupField = new GroupField("CategoryName");
            ghBand.GroupFields.Add(groupField);

            // Create new labels.
            XRLabel labelGroup = new XRLabel { ForeColor = System.Drawing.Color.Blue };
            XRLabel labelDetail = new XRLabel { LocationF = new System.Drawing.PointF(30, 0) };
            labelDetail.WordWrap = false;
            labelDetail.AutoWidth = true;

            // Specify labels' bindings depending on the report's data binding mode.
            if (Settings.Default.UserDesignerOptions.DataBindingMode == DataBindingMode.Bindings) {
                labelGroup.DataBindings.Add("Text", null, "customQuery.CategoryName");
                labelDetail.DataBindings.Add("Text", null, "customQuery.ProductName");
            } else {
                labelGroup.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[CategoryName]"));
                labelDetail.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[ProductName]"));
            }
            // Add these labels to the report's bands.    
            ghBand.Controls.Add(labelGroup);          
            detail.Controls.Add(labelDetail);

            return report;
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create a grouping report and show its print preview.
            XtraReport report = CreateDataGroupingReport();
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreview(); 
        }

    }
}

