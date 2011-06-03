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
    /// tuansl added: manage historical charaterize info of nhanvien
    /// </summary>
    public partial class FrmThongTinNhanVien_DacDiemLichSu : DevComponents.DotNetBar.Office2007Form
    {
        private NhanVien _nhanvien;

        public FrmThongTinNhanVien_DacDiemLichSu(NhanVien nhanvien)
        {
            InitializeComponent();
            _nhanvien = nhanvien;
        }
    }
}