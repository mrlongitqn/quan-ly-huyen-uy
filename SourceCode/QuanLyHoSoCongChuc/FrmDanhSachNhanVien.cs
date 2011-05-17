using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyHoSoCongChuc.BusinessObject;
using QuanLyHoSoCongChuc.Controller;
using QuanLyHoSoCongChuc.DataLayer;

namespace QuanLyHoSoCongChuc
{
    public partial class FrmDanhSachNhanVien : Form
    {
        NhanVienControl m_NhanVienControl = new NhanVienControl();
        public FrmDanhSachNhanVien()
        {
            InitializeComponent();
        }

        private void FrmDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            DataService.OpenConnection();
            m_NhanVienControl.HienThiDanhSachNhanVien(DGVLuong);
        }

        private void DGVLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) //  is a linkcolumn: SYLL
            {
                String MaNV = DGVLuong[2, e.RowIndex].Value.ToString();
                //MessageBox.Show(MaNV);
                Report1 report = new Report1(MaNV);
                report.ShowDialog();
            }
            if (e.ColumnIndex == 1) //  is a linkcolumn: Nghi huu
            {
                String MaNV = DGVLuong[2, e.RowIndex].Value.ToString();
                //MessageBox.Show(MaNV);
                Report2 report = new Report2(MaNV);
                report.ShowDialog();
            }
        }
    }
}
