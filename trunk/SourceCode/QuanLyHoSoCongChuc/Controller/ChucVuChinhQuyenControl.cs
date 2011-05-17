using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using QuanLyHoSoCongChuc.DataLayer;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc.Controller
{
    public class ChucVuChinhQuyenControl
    {
        private ChucVuChinhQuyenData m_ChucVuChinhQuyenData = new ChucVuChinhQuyenData();
        public DataTable LayDSChucVuChinhQuyen()
        {
            DataTable dt = m_ChucVuChinhQuyenData.LayDSChucVuChinhQuyen();
            return dt;
        }

        public void HienThiComboBox(ComboBox cmb)
        {
            DataTable dtDanhSachHuyenUy = LayDSChucVuChinhQuyen();
            cmb.DataSource = dtDanhSachHuyenUy;
            cmb.DisplayMember = "TenChucVuChinhQuyen";
            cmb.ValueMember = "MaChucVuChinhQuyen";
        }
    }
}
