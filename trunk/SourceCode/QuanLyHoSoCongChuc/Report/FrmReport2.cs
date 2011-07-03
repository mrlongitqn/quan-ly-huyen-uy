using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WebForms;

namespace QuanLyHoSoCongChuc.Report
{
    public partial class FrmReport2 : Form
    {
        public FrmReport2()
        {
            InitializeComponent();
        }

        private void FrmReport2_Load(object sender, EventArgs e)
        {
            string reportPath = "RptSYLL.rdlc";
            DataSet dsHesapPlan = new DataSet();
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "Reports_GetAttendanceTotalsReport";
            //reportDataSource.Value = this.GetAttendanceTotalsReportBindingSource;
            //this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource());
            reportViewer1.LocalReport.ReportEmbeddedResource = "AttendanceTracking.AttendanceTotals.rdlc";

            this.reportViewer1.LocalReport.ReportPath = reportPath;
            this.reportViewer1.RefreshReport();
        }
    }
}
