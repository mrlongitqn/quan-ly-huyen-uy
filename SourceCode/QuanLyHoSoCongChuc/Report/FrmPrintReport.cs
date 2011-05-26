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
        String MaDV;
        String strDt;
        DataService dataService = new DataService();
        public FrmPrintReport(int _BC, String _MaDV, String _dt)
        {
            InitializeComponent();
            BaoCao = _BC;
            MaDV = _MaDV;
            strDt = _dt;
        }

        private void FrmPrintReport_Load(object sender, EventArgs e)
        {
            if (BaoCao == 1)
            {
                DataService.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DonVi where MaDonVi='" + MaDV + "'");
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoLuong rpt = new CrBaoCaoLuong();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;

            }
        }
    }
}
