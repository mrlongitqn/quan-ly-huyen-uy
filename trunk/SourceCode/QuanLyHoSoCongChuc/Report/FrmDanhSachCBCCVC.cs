using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyHoSoCongChuc.Danh_muc;
using QuanLyHoSoCongChuc.Utils;
using System.Data.SqlClient;

namespace QuanLyHoSoCongChuc.Report
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
    public partial class FrmDanhSachCBCCVC : Form
    {
        public FrmDanhSachCBCCVC()
        {
            InitializeComponent();
        }
        String SelectedId;
        int Level;
        DataService dataService = new DataService();
        private void FrmDanhSachCBCCVC_Load(object sender, EventArgs e)
        {
            cbDoiTuong.SelectedIndex = 0;
            cbKy.SelectedIndex = 0;
        }
        

        private void btInBieu_Click(object sender, EventArgs e)
        {
            int type = cbDoiTuong.SelectedIndex;

            FrmPrintReport frm = new FrmPrintReport("4-"+type.ToString(), SelectedId, "");
            frm.Show();
        }

        private void btBaoBieu_Click(object sender, EventArgs e)
        {
            DGV.Rows.Clear();
            String sql = " select nv.*, cv.TenChucVu, t.TenTrinhDoChuyenMon, tt.TenTrinhDoChinhTri";
            sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
            sql += " left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
            sql += " left join TrinhDoChinhTri tt on nv.MaTrinhDoChinhTri = tt.MaTrinhDoChinhTri";
            sql += " where MaDonVi='" + SelectedId + "'";

            SqlCommand cmd = new SqlCommand(sql);
            dataService.Load(cmd);
            DataTable myDt = dataService;

            for (int i = 0; i < myDt.Rows.Count; i++)
            {
                DGV.Rows.Add();
                DGV.Rows[i].Cells["STT"].Value = i + 1;
                DGV.Rows[i].Cells["HoTenNhanVien"].Value = myDt.Rows[i]["HoTenNhanVien"].ToString();
                DateTime dt = (DateTime)myDt.Rows[i]["NgaySinh"];
                DGV.Rows[i].Cells["NgaySinh"].Value = dt.ToString("dd/MM/yyyy");
                DGV.Rows[i].Cells["QueQuan"].Value = myDt.Rows[i]["QueQuan"].ToString();
                DGV.Rows[i].Cells["NoiOHienTai"].Value = myDt.Rows[i]["NoiOHienTai"].ToString();
                DGV.Rows[i].Cells["TenChucVu"].Value = myDt.Rows[i]["TenChucVu"].ToString();
                DGV.Rows[i].Cells["TenTrinhDoChuyenMon"].Value = myDt.Rows[i]["TenTrinhDoChuyenMon"].ToString();
                DGV.Rows[i].Cells["TenTrinhDoChinhTri"].Value = myDt.Rows[i]["TenTrinhDoChinhTri"].ToString();
            }
            if (myDt.Rows.Count == 0)
            {
                MessageBox.Show("No data");
            }
        }
        public void GetDonVi(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            SelectedId = comp[0];
            txtDonVi.Text = comp[1];
            Level = int.Parse(comp[2]);
        }
        private void btnChonDonVi_Click(object sender, EventArgs e)
        {
            FrmDanhMuc frm = new FrmDanhMuc();
            frm.Handler += GetDonVi;
            frm.EnableButtonChon = true;
            frm.ShowDialog();
        }
    }
}
