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
    public class CapUyKiemControl
    {
        private CapUyKiemData m_CapUyKiemData = new CapUyKiemData();
        public DataTable LayDSCapUyKiem()
        {
            DataTable dt = m_CapUyKiemData.LayDSCapUyKiem();
            return dt;
        }

        public void HienThiComboBox(ComboBox cmb)
        {
            DataTable dtDanhSachCapUyKiem = LayDSCapUyKiem();
            cmb.DataSource = dtDanhSachCapUyKiem;
            cmb.DisplayMember = "TenCapUyKiem";
            cmb.ValueMember = "MaCapUyKiem";
        }
    }
}
