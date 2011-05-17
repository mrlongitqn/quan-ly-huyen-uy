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
    public class CapUyControl
    {
        private CapUyData m_CapUyData = new CapUyData();
        public DataTable LayDSCapUy()
        {
            DataTable dt = m_CapUyData.LayDSCapUy();
            return dt;
        }

        public void HienThiComboBox(ComboBox cmb)
        {
            DataTable dtDanhSachCapUy = LayDSCapUy();
            cmb.DataSource = dtDanhSachCapUy;
            cmb.DisplayMember = "TenCapUy";
            cmb.ValueMember = "MaCapUy";
        }
    }
}
