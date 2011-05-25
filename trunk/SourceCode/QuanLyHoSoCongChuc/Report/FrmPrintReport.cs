using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyHoSoCongChuc.Report
{
    public partial class FrmPrintReport : Form
    {
        int BaoCao = -1;
        DataService dataService = new DataService();
        public FrmPrintReport(int _BC)
        {
            InitializeComponent();
            BaoCao = _BC;
        }

        private void FrmPrintReport_Load(object sender, EventArgs e)
        {
            if (BaoCao == 1)
            {
                DataService.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DonVi");
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoLuong rpt = new CrBaoCaoLuong();

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;

            }
        }
    }
}
