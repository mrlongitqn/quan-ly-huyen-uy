using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Models;
using QuanLyHoSoCongChuc.Repositories;

namespace QuanLyHoSoCongChuc.NhanVienManager
{
    /// <summary>
    /// tuansl added: manage sumary info of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien_LuongPhuCap : DevComponents.DotNetBar.Office2007Form
    {
        private NhanVien _nhanvien;

        public FrmThongTinNhanVien_LuongPhuCap(NhanVien nhanvien)
        {
            InitializeComponent();
            _nhanvien = nhanvien;
        }

        private void FrmThongTinNhanVien_TomTat_Load(object sender, EventArgs e)
        {
        }
    }
}