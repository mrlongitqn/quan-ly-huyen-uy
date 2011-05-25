using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyHoSoCongChuc.Report
{
    public partial class FrmPrintReport : Form
    {
        int BaoCao = -1;
        public FrmPrintReport(int _BC)
        {
            InitializeComponent();
            BaoCao = _BC;
        }

        private void FrmPrintReport_Load(object sender, EventArgs e)
        {
            if (BaoCao == 1)
            {
                CrBaoCaoLuong rpt = new CrBaoCaoLuong();
                this.crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}
