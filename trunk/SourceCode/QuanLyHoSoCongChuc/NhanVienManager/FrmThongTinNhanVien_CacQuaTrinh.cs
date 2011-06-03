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
    /// tuansl added: manage progress of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien_CacQuaTrinh : DevComponents.DotNetBar.Office2007Form
    {
        private NhanVien _nhanvien;

        public FrmThongTinNhanVien_CacQuaTrinh(NhanVien nhanvien)
        {
            InitializeComponent();
            _nhanvien = nhanvien;
        }
    }
}