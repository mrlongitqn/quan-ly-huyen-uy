using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Models;

namespace QuanLyHoSoCongChuc.NhanVienManager
{
    /// <summary>
    /// tuansl added: manage family info of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien_GiaDinh : DevComponents.DotNetBar.Office2007Form
    {
        private NhanVien _nhanvien;

        public FrmThongTinNhanVien_GiaDinh(NhanVien nhanvien)
        {
            InitializeComponent();
            _nhanvien = nhanvien;
        }
    }
}