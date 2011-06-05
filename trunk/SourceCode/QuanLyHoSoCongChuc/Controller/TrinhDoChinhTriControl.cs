using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuanLyHoSoCongChuc.DataLayer;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc.Controller
{
    public class BangLyLuanChinhTriControl
    {
        BangLyLuanChinhTriData m_BangLyLuanChinhTriData = new BangLyLuanChinhTriData();


        public void HienThiComboBox(ComboBox cmb)
        {
            cmb.DataSource = m_BangLyLuanChinhTriData.LayDanhSachBangLyLuanChinhTri();
            cmb.DisplayMember = "TenBangLyLuanChinhTri";
            cmb.ValueMember = "MaBangLyLuanChinhTri";
        }

        //        
        public void HienThiDataGridViewComboBoxColumnBangLyLuanChinhTri(DataGridViewComboBoxColumn cmbColumnBangLyLuanChinhTri)
        {
            cmbColumnBangLyLuanChinhTri.DataSource = m_BangLyLuanChinhTriData.LayDanhSachBangLyLuanChinhTri();
            cmbColumnBangLyLuanChinhTri.DisplayMember = "TenBangLyLuanChinhTri";
            cmbColumnBangLyLuanChinhTri.ValueMember = "MaBangLyLuanChinhTri";
        }

        public void HienThi(DataGridView dGV, BindingNavigator bN)
        {
            BindingSource bS = new BindingSource();
            DataTable tbl = m_BangLyLuanChinhTriData.LayDanhSachBangLyLuanChinhTri();
            bS.DataSource = tbl;
            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }
        //Hien thi DataGirdView     
        public void HienThi(DataGridView dGV, BindingNavigator bN, TextBox txtMaBangLyLuanChinhTri, TextBox txtTenBangLyLuanChinhTri)
        {
            BindingSource bS = new BindingSource();
            DataTable tbl = m_BangLyLuanChinhTriData.LayDanhSachBangLyLuanChinhTri();
            bS.DataSource = tbl;

            txtMaBangLyLuanChinhTri.DataBindings.Clear();
            txtMaBangLyLuanChinhTri.DataBindings.Add("Text", bS, "MaBangLyLuanChinhTri");
            txtTenBangLyLuanChinhTri.DataBindings.Clear();
            txtTenBangLyLuanChinhTri.DataBindings.Add("Text", bS, "TenBangLyLuanChinhTri");

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }
        public DataRow ThemDongMoi()
        {
            return m_BangLyLuanChinhTriData.ThemDongMoi();
        }

        public void ThemBangLyLuanChinhTri(DataRow m_Row)
        {
            m_BangLyLuanChinhTriData.ThemBangLyLuanChinhTri(m_Row);
        }

        public bool LuuBangLyLuanChinhTri()
        {
            return m_BangLyLuanChinhTriData.LuuBangLyLuanChinhTri();
        }
    }


}


