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
    public partial class FrmBaoCaoLuong : Form
    {
        public FrmBaoCaoLuong()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoLuong_Load(object sender, EventArgs e)
        {
            CrBaoCaoLuong rpt = new CrBaoCaoLuong();
            this.crystalReportViewer1.ReportSource = rpt;
        }
    }
}
