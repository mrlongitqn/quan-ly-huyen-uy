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
            if (BaoCao == 0)
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
            else if (BaoCao == 1)
            {
                DataService.OpenConnection();
                String sql = " select nv.*, t.TenTrinhDoChuyenMon,";
                sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
                sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
                sql += " from NhanVien nv left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
                sql += " where MaDonVi='" + MaDV + "'";


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoLuong2 rpt = new CrBaoCaoLuong2();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;
            }
            else if (BaoCao == 2)
            {
                DataService.OpenConnection();
                String sql = " select nv.*, t.TenTrinhDoChuyenMon,";
                sql += " NgaySinhNam = case MaGioiTinh when 1 then NgaySinh end,";
                sql += " NgaySinhNu = case MaGioiTinh when 0 then NgaySinh end";
                sql += " from NhanVien nv left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
                sql += " where MaDonVi='" + MaDV + "'";


                SqlCommand cmd = new SqlCommand(sql);
                dataService.Load(cmd);
                DataTable myDt = dataService;
                CrBaoCaoLuong3 rpt = new CrBaoCaoLuong3();
                rpt.DataDefinition.FormulaFields["NgayThang"].Text = "'" + strDt + "'";

                rpt.SetDataSource(myDt);
                this.crystalReportViewer1.ReportSource = rpt;

            }
        }
    }
}
