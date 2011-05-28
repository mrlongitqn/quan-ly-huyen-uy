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
    public partial class FrmDanhSachCBCCVC : Form
    {
        public FrmDanhSachCBCCVC()
        {
            InitializeComponent();
        }

        DataService dataService = new DataService();
        private void FrmDanhSachCBCCVC_Load(object sender, EventArgs e)
        {
            loadDonVi();
            cbDoiTuong.SelectedIndex = 0;
            cbKy.SelectedIndex = 0;
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

        private void btInBieu_Click(object sender, EventArgs e)
        {
            ListItem DV = (ListItem)cbDonVi.SelectedItem;
            int type = cbDoiTuong.SelectedIndex;

            FrmPrintReport frm = new FrmPrintReport("3-"+type.ToString(), DV.ID, "");
            frm.Show();
        }

        private void btBaoBieu_Click(object sender, EventArgs e)
        {
            ListItem DV = (ListItem)cbDonVi.SelectedItem;
            String sql = " select nv.*, cv.TenChucVu, t.TenTrinhDoChuyenMon, tt.TenTrinhDoChinhTri";
            sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
            sql += " left join TrinhDoChuyenMon t on nv.MaTrinhDoChuyenMon = t.MaTrinhDoChuyenMon";
            sql += " left join TrinhDoChinhTri tt on nv.MaTrinhDoChinhTri = tt.MaTrinhDoChinhTri";
            sql += " where MaDonVi='" + DV.ID + "'";

            SqlCommand cmd = new SqlCommand(sql);
            dataService.Load(cmd);
            DataTable myDt = dataService;

        }
    }
}
