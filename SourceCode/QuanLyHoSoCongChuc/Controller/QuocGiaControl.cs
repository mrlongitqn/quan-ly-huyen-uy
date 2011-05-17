using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using QuanLyHoSoCongChuc.DataLayer;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc.Controller
{
    class QuocGiaControl
    {
        QuocGiaData m_QuocGiaData = new QuocGiaData();
        public DataTable LayDanhSachQuocGia()
        {
            DataTable dt = m_QuocGiaData.LayDanhSachQuocGia();
            return dt;
        }

        public void HienThiComboBox(ComboBox cmb)
        {
            DataTable dtDanhSachQuocGia = LayDanhSachQuocGia();
            cmb.DataSource = dtDanhSachQuocGia;
            cmb.DisplayMember = "TenQuocGia";
            cmb.ValueMember = "MaQuocGia";
        }

    }
}
