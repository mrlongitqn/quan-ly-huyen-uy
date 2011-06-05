﻿using System;
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
    public partial class FrmDanhSachNghiHuu : Form
    {
        DataService dataService = new DataService();
        String SelectedId;
        int Level;
        public FrmDanhSachNghiHuu()
        {
            InitializeComponent();
        }

        private void FrmDanhSachNghiHuu_Load(object sender, EventArgs e)
        {
            loadNam();
            cboKy.SelectedIndex = 0;
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
            List<String> ChuKi = new List<string>();
            ChuKi.Add(txtNLB1.Text);
            ChuKi.Add(txtNLB2.Text);
            ChuKi.Add(txtNLB3.Text);
            ChuKi.Add(txtNK1.Text);
            ChuKi.Add(txtNK2.Text);
            ChuKi.Add(txtNK3.Text);
            FrmPrintReport frm = new FrmPrintReport("5", SelectedId, "", ChuKi);
            frm.Show();
        }

        private void btBaoBieu_Click(object sender, EventArgs e)
        {
            DGV.Rows.Clear();
            String sql = " select nv.*, cv.TenChucVu, t.TenBangChuyenMonNghiepVu, tt.TenBangLyLuanChinhTri, dv.TenDonVi";
            sql += " from NhanVien nv left join ChucVu cv on nv.MaChucVu = cv.MaChucVu";
            sql += " left join BangChuyenMonNghiepVu t on nv.MaBangChuyenMonNghiepVu = t.MaBangChuyenMonNghiepVu";
            sql += " left join BangLyLuanChinhTri tt on nv.MaBangLyLuanChinhTri = tt.MaBangLyLuanChinhTri";
            sql += " left join DonVi dv on nv.MaDonVi = dv.MaDonVi";
            sql += " where nv.MaDonVi='" + SelectedId + "'";

            sql += " and (DATEDIFF(YYYY, NgaySinh, GETDATE()) > ";
            sql += " case MaGioiTinh";
            sql += " when 1 then 60";
            sql += " else 55";
            sql += " end)";
            sql += " or";
            sql += " ((DATEDIFF(YYYY, NgaySinh, GETDATE()) = ";
            sql += " case MaGioiTinh";
            sql += " when 1 then 60";
            sql += " else 55";
            sql += " end)";
            sql += " and";
            sql += " (datepart(mm,getdate()) - datepart(mm,NgaySinh) ) >= 6";
            sql += " )";

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
                DGV.Rows[i].Cells["HeSoLuong"].Value = myDt.Rows[i]["HeSoLuong"].ToString();
                DGV.Rows[i].Cells["TenChucVu"].Value = myDt.Rows[i]["TenChucVu"].ToString();
                DGV.Rows[i].Cells["TenBangChuyenMonNghiepVu"].Value = myDt.Rows[i]["TenBangChuyenMonNghiepVu"].ToString();
                DGV.Rows[i].Cells["TenBangLyLuanChinhTri"].Value = myDt.Rows[i]["TenBangLyLuanChinhTri"].ToString();
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

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}