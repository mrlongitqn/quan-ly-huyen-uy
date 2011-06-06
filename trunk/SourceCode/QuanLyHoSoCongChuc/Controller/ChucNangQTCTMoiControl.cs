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
    public class ChucNangQTCTMoiControl
    {
        ChucNangQTCTMoiData m_ChucNangQTCTMoiData = new ChucNangQTCTMoiData();
        NhanVienControl m_NhanVienControl = new NhanVienControl();
        QuocGiaControl m_QuocGiaControl = new QuocGiaControl();
        CapUyControl m_CapUyControl = new CapUyControl();
        CapUyKiemControl m_CapUyKiemControl = new CapUyKiemControl();
        ChucVuChinhQuyenControl m_ChucVuChinhQuyenControl = new ChucVuChinhQuyenControl();


        public void HienThiQuocGia(ComboBox cmb)
        {
            m_QuocGiaControl.HienThiComboBox(cmb);
        }

        public void HienThiCapUy(ComboBox cmb)
        {
            m_CapUyControl.HienThiComboBox(cmb);
        }

        public void HienThiCapUyKiem(ComboBox cmb)
        {
            m_CapUyKiemControl.HienThiComboBox(cmb);
        }

        public void HienThiCapUyChucVuChinhQuyen(ComboBox cmb)
        {
            m_ChucVuChinhQuyenControl.HienThiComboBox(cmb);
        }

        public void HienThiThongTinNhanVien(ComboBox cmbNhanVien)
        {
            DataTable dt = m_NhanVienControl.LayDSNhanVien();
            cmbNhanVien.DataSource = dt;
            cmbNhanVien.DisplayMember = "HoTenKhaiSinh";
            cmbNhanVien.ValueMember = "MaNhanVien";
        }

        public void HienThiThongTinDang(string MaNhanVien, TextBox txtIDDang)
        {
            string IDDangVien = m_NhanVienControl.LayIDDangVienTheoMaNhanVien(MaNhanVien);
            txtIDDang.Text = IDDangVien;
            
        }

        

        public string LayIDDang(string MaNhanVien)
        {
            string IDDangVien = m_NhanVienControl.LayIDDangVienTheoMaNhanVien(MaNhanVien);
            return IDDangVien;
        }

        public void HienThiDataGridView(DataGridView dgv, string MaNhanVien)
        {
            DataTable dtDanhSachQTCT = m_ChucNangQTCTMoiData.LayDanhsachQuaTrinhCongTacTheoMaNhanVien(MaNhanVien);

            dgv.Rows.Clear();

            foreach (DataRow row in dtDanhSachQTCT.Rows)
            {
                Object[] objDatas = new Object[10];
                objDatas[0] = row["STT"];
                objDatas[1] = row["ThoiGianBatDau"];
                objDatas[2] = row["ThoiGianKetThuc"];
                objDatas[3] = row["MaQuaTrinhCongTac"];
                objDatas[4] = row["MoTaCongTac"];
                objDatas[5] = row["MaNuocCongTac"];
                objDatas[6] = row["MaCapUy"];
                objDatas[7] = row["ChucDanh"];
                objDatas[8] = row["MaCapUyKiem"];
                objDatas[9] = row["MaChucVuChinhQuyen"];                
                dgv.Rows.Add(objDatas);
            }
        }

        public QuaTrinhCongTacMoiInfo LayThongTinQuaTrinhCongTac(int MaQuaTrinhCongTac)
        {
            QuaTrinhCongTacMoiInfo qtct = m_ChucNangQTCTMoiData.LayThongTinQuaTrinhCongTac(MaQuaTrinhCongTac);
            return qtct;
        }

        public void ThemQuaTrinhCongTac(QuaTrinhCongTacMoiInfo qtct)
        {
            m_ChucNangQTCTMoiData.ThemQuaTrinhCongTac(qtct);
        }

        public void CapNhatQuaTrinhCongTac(QuaTrinhCongTacMoiInfo qtct)
        {
            m_ChucNangQTCTMoiData.CapNhatQuaTrinhCongTac(qtct);
        }

        public void XoaQuaTrinhCongTac(int MaQTCT)
        {
            m_ChucNangQTCTMoiData.XoaQuaTrinhCongTac(MaQTCT);
        }
    }
}
