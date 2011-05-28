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
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
    public partial class FrmDanhSachNghiHuu : Form
    {
        DataService dataService = new DataService();
        public FrmDanhSachNghiHuu()
        {
            InitializeComponent();
        }

        private void FrmDanhSachNghiHuu_Load(object sender, EventArgs e)
        {
            loadDonVi();
            loadNam();
        }
        void loadDonVi()
        {
            var lstDonVi = DonViRepository.SelectAll();
            for (int i = 0; i < lstDonVi.Count; i++)
            {
                cbDonVi.Items.Add(new ListItem(lstDonVi[i].MaDonVi, lstDonVi[i].TenDonVi));
            }
            if (lstDonVi.Count > 0)
                cbDonVi.SelectedIndex = 0;
        }
        void loadNam()
        {
            for (int i = 0; i < 100; i++)
            {
                dupNam.Items.Add(1950 + i);
            }
            dupNam.SelectedIndex = 50;
        }

        private void btInBieu_Click(object sender, EventArgs e)
        {
            String strDt = cboKy.Text + " năm " + dupNam.Text;
            ListItem DV = (ListItem)cbDonVi.SelectedItem;

            FrmPrintReport frm = new FrmPrintReport("5", DV.ID, "");
            frm.Show();
        }

        private void btBaoBieu_Click(object sender, EventArgs e)
        {
            DGV.Rows.Clear();
            ListItem DV = (ListItem)cbDonVi.SelectedItem;
            String sql = " select nv.*, cv.TenChucVu, t.TenTrinhDoChuyenMon, tt.TenTrinhDoChinhTri, dv.TenDonVi";
            sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
            sql += " left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
            sql += " left join TrinhDoChinhTri tt on nv.MaTrinhDoChinhTri = tt.MaTrinhDoChinhTri";
            sql += " left join DonVi dv on nv.MaDonVi = dv.MaDonVi";
            sql += " where nv.MaDonVi='" + DV.ID + "'";

            SqlCommand cmd = new SqlCommand(sql);
            dataService.Load(cmd);
            DataTable myDt = dataService;

            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                DGV.Rows.Add();
                DGV.Rows[i].Cells["STT"].Value = i + 1;
                DGV.Rows[i].Cells["HoTenNhanVien"].Value = myDt.Rows[i]["HoTenNhanVien"].ToString();
                DGV.Rows[i].Cells["TenDonVi"].Value = myDt.Rows[i]["TenDonVi"].ToString();
                DateTime dt = (DateTime)myDt.Rows[i]["NgaySinh"];
                DGV.Rows[i].Cells["NgaySinh"].Value = dt.ToString("dd/MM/yyyy");
                DGV.Rows[i].Cells["QueQuan"].Value = myDt.Rows[i]["QueQuan"].ToString();
                DGV.Rows[i].Cells["TuoiDoi"].Value = DateTime.Now.Year - dt.Year;
                dt = (DateTime)myDt.Rows[i]["NgayHopDong"];
                DGV.Rows[i].Cells["NamCongTac"].Value = dt.ToString("dd/MM/yyyy");
                DGV.Rows[i].Cells["TenTrinhDoChuyenMon"].Value = myDt.Rows[i]["TenTrinhDoChuyenMon"].ToString();
                DGV.Rows[i].Cells["TenTrinhDoChinhTri"].Value = myDt.Rows[i]["TenTrinhDoChinhTri"].ToString();
            }
        }
    }
}
