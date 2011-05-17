using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using WeifenLuo.WinFormsUI.Docking;
using QuanLyHoSoCongChuc.BusinessObject;
using QuanLyHoSoCongChuc.DataLayer;
using QuanLyHoSoCongChuc.Controller;

namespace QuanLyHoSoCongChuc
{
    public partial class FrmThemDanhMucHanhChinh : Office2007Form
    {

        ThemDanhMucHanhChinhControl m_ThemDanhMucHanhChinhControl = new ThemDanhMucHanhChinhControl();
        public FrmThemDanhMucHanhChinh()
        {
            InitializeComponent();
        }

        private void LoadFormTuPhuongXa(string MaQuanHuyen)
        {
            DataTable dtDanhSachPhuongXa = m_ThemDanhMucHanhChinhControl.PhuongXaData.LayDSPhuongXaTheoMaQuanHuyen(MaQuanHuyen);
            if (dtDanhSachPhuongXa != null)
            {
                m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbPhuongXa, dtDanhSachPhuongXa, ThemDanhMucHanhChinhControl.KieuHanhChinh.PhuongXa);
                if (cmbPhuongXa.SelectedValue != null)
                {
                    txtMaPhuongXa.Text = cmbPhuongXa.SelectedValue.ToString();

                    DataTable dtDanhSachKhoiXom = m_ThemDanhMucHanhChinhControl.KhoiXomData.LayDSKhoiXomTheoMaPhuongXa(cmbPhuongXa.SelectedValue.ToString());
                    if (dtDanhSachKhoiXom != null)
                    {
                        m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbKhoiXom, dtDanhSachKhoiXom, ThemDanhMucHanhChinhControl.KieuHanhChinh.KhoiXom);
                        if (cmbKhoiXom.SelectedValue != null)
                        {
                            txtMaKhoiXom.Text = cmbKhoiXom.SelectedValue.ToString();
                        }
                    }
                }
            }
        }
        private void LoadFormTuKhoiXom(string MaPhuongXa)
        {

        }

        private void FrmThemDanhMucHanhChinh_Load(object sender, EventArgs e)
        {
            DataTable dtDanhMucTinhThanh = m_ThemDanhMucHanhChinhControl.TinhThanhData.LayDSTinhThanh();
            m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbTinhThanh, dtDanhMucTinhThanh, ThemDanhMucHanhChinhControl.KieuHanhChinh.TinhThanh);
            
            if (cmbTinhThanh.SelectedValue != null)
            {
                txtMaTinhThanh.Text = cmbTinhThanh.SelectedValue.ToString();
                DataTable dtDanhSachQuanHuyen = m_ThemDanhMucHanhChinhControl.QuanHuyenData.LayDanhSachQuanHuyenThemMaTinh(cmbTinhThanh.SelectedValue.ToString());
                if (dtDanhSachQuanHuyen != null)
                {
                    m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbQuanHuyen, dtDanhSachQuanHuyen, ThemDanhMucHanhChinhControl.KieuHanhChinh.QuanHuyen);
                    if (cmbQuanHuyen.SelectedValue != null)
                    {
                        txtMaQuanHuyen.Text = cmbQuanHuyen.SelectedValue.ToString();

                        DataTable dtDanhSachPhuongXa = m_ThemDanhMucHanhChinhControl.PhuongXaData.LayDSPhuongXaTheoMaQuanHuyen(cmbQuanHuyen.SelectedValue.ToString());
                        if (dtDanhSachPhuongXa != null)
                        {
                            m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbPhuongXa, dtDanhSachPhuongXa, ThemDanhMucHanhChinhControl.KieuHanhChinh.PhuongXa);
                            if (cmbPhuongXa.SelectedValue != null)
                            {
                                txtMaPhuongXa.Text = cmbPhuongXa.SelectedValue.ToString();

                                DataTable dtDanhSachKhoiXom = m_ThemDanhMucHanhChinhControl.KhoiXomData.LayDSKhoiXomTheoMaPhuongXa(cmbPhuongXa.SelectedValue.ToString());
                                if (dtDanhSachKhoiXom != null)
                                {
                                    m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbKhoiXom, dtDanhSachKhoiXom, ThemDanhMucHanhChinhControl.KieuHanhChinh.KhoiXom);
                                    if (cmbKhoiXom.SelectedValue != null)
                                    {
                                        txtMaKhoiXom.Text = cmbKhoiXom.SelectedValue.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private void cmbTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cmbTinhThanh.SelectedValue != null)
            {
                txtMaTinhThanh.Text = cmbTinhThanh.SelectedValue.ToString();
                DataTable dtQuanHuyen = m_ThemDanhMucHanhChinhControl.QuanHuyenData.LayDanhSachQuanHuyenThemMaTinh(cmbTinhThanh.SelectedValue.ToString());
                
                if (dtQuanHuyen.Rows.Count == 0)
                {
                    txtMaQuanHuyen.Text = "";
                }

                m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbQuanHuyen, dtQuanHuyen, ThemDanhMucHanhChinhControl.KieuHanhChinh.QuanHuyen);
                if (cmbQuanHuyen.SelectedValue != null)
                {
                    txtMaQuanHuyen.Text = cmbQuanHuyen.SelectedValue.ToString();

                    DataTable dtDanhSachPhuongXa = m_ThemDanhMucHanhChinhControl.PhuongXaData.LayDSPhuongXaTheoMaQuanHuyen(cmbQuanHuyen.SelectedValue.ToString());
                    if (dtDanhSachPhuongXa != null)
                    {
                        m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbPhuongXa, dtDanhSachPhuongXa, ThemDanhMucHanhChinhControl.KieuHanhChinh.PhuongXa);
                        if (cmbPhuongXa.SelectedValue != null)
                        {
                            txtMaPhuongXa.Text = cmbPhuongXa.SelectedValue.ToString();

                            DataTable dtDanhSachKhoiXom = m_ThemDanhMucHanhChinhControl.KhoiXomData.LayDSKhoiXomTheoMaPhuongXa(cmbPhuongXa.SelectedValue.ToString());
                            if (dtDanhSachKhoiXom != null)
                            {
                                m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbKhoiXom, dtDanhSachKhoiXom, ThemDanhMucHanhChinhControl.KieuHanhChinh.KhoiXom);
                                if (cmbKhoiXom.SelectedValue != null)
                                {
                                    txtMaKhoiXom.Text = cmbKhoiXom.SelectedValue.ToString();
                                }
                            }
                        }
                        else
                        {
                            m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbKhoiXom, null, ThemDanhMucHanhChinhControl.KieuHanhChinh.KhoiXom);
                            txtMaKhoiXom.Text = "";
                        }
                    }
                }
                else
                {
                    m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbPhuongXa, null, ThemDanhMucHanhChinhControl.KieuHanhChinh.PhuongXa);
                    txtMaPhuongXa.Text = "";
                    m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbKhoiXom, null, ThemDanhMucHanhChinhControl.KieuHanhChinh.KhoiXom);
                    txtMaKhoiXom.Text = "";
                }                
            }
        }

        private void cmbQuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQuanHuyen.SelectedValue != null)
            {
                txtMaQuanHuyen.Text = cmbQuanHuyen.SelectedValue.ToString();
                DataTable dtPhuongXa = m_ThemDanhMucHanhChinhControl.PhuongXaData.LayDSPhuongXaTheoMaQuanHuyen(cmbQuanHuyen.SelectedValue.ToString());
                if (dtPhuongXa.Rows.Count > 0)
                {
                    m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbPhuongXa, dtPhuongXa, ThemDanhMucHanhChinhControl.KieuHanhChinh.PhuongXa);
                    txtMaPhuongXa.Text = cmbPhuongXa.SelectedValue.ToString();

                    DataTable dtDanhSachKhoiXom = m_ThemDanhMucHanhChinhControl.KhoiXomData.LayDSKhoiXomTheoMaPhuongXa(cmbPhuongXa.SelectedValue.ToString());                    
                    m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbKhoiXom, dtDanhSachKhoiXom, ThemDanhMucHanhChinhControl.KieuHanhChinh.KhoiXom);
                    if (cmbKhoiXom.SelectedValue != null)
                    {
                        txtMaKhoiXom.Text = cmbKhoiXom.SelectedValue.ToString();
                    }
                }
                else
                {
                    txtMaPhuongXa.Text = "";
                    m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbKhoiXom, null, ThemDanhMucHanhChinhControl.KieuHanhChinh.KhoiXom);
                    txtMaKhoiXom.Text = "";
                }
            }
            else
            {
                txtMaQuanHuyen.Text = "";
                m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbPhuongXa, null, ThemDanhMucHanhChinhControl.KieuHanhChinh.PhuongXa);
                txtMaPhuongXa.Text = "";
                m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbKhoiXom, null, ThemDanhMucHanhChinhControl.KieuHanhChinh.KhoiXom);
                txtMaKhoiXom.Text = "";
            }
            
        }

        private void cmbPhuongXa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPhuongXa.SelectedValue != null)
            {
                txtMaPhuongXa.Text = cmbPhuongXa.SelectedValue.ToString();
                DataTable dtKhoiXom = m_ThemDanhMucHanhChinhControl.KhoiXomData.LayDSKhoiXomTheoMaPhuongXa(cmbPhuongXa.SelectedValue.ToString());
                if (dtKhoiXom.Rows.Count > 0)
                {
                    m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbKhoiXom, dtKhoiXom, ThemDanhMucHanhChinhControl.KieuHanhChinh.KhoiXom);
                    if (cmbKhoiXom.SelectedValue != null)
                    {
                        txtMaKhoiXom.Text = cmbKhoiXom.SelectedValue.ToString();
                    }
                    else
                    {
                        txtMaKhoiXom.Text = "";
                    }
                }
                else
                {
                    txtMaKhoiXom.Text = "";
                    m_ThemDanhMucHanhChinhControl.HienThiComboBox(cmbKhoiXom, null, ThemDanhMucHanhChinhControl.KieuHanhChinh.KhoiXom);
                }
            }
            else
            {
                txtMaPhuongXa.Text = "";
            }
        }

        private void cmbKhoiXom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhoiXom.SelectedValue != null)
            {
                txtMaKhoiXom.Text = cmbKhoiXom.SelectedValue.ToString();
            }
            else
            {
                txtMaKhoiXom.Text = "";
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {

        }

        private void btnThemTinhThanh_Click(object sender, EventArgs e)
        {
            string MaTinh = txtMaTinhThanh.Text;
            if (string.IsNullOrWhiteSpace(MaTinh) == true)
            {
                MessageBox.Show("Mã tỉnh không được bỏ trống.");
            }
            else
            {
                string TenTinhThanh = cmbTinhThanh.Text;

                if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiTinhThanhTheoMa(txtMaTinhThanh.Text))
                {
                    MessageBox.Show("Tỉnh có mã " + txtMaTinhThanh.Text + " đã tồn tại!");
                }
                else
                {
                    TinhThanhInfo TinhThanhObj = new TinhThanhInfo();
                    TinhThanhObj.MaTinh = txtMaTinhThanh.Text;
                    TinhThanhObj.TenTinh = TenTinhThanh;
                    int result = m_ThemDanhMucHanhChinhControl.ThemTinhThanhMoi(TinhThanhObj);
                    if (result != 0)
                    {
                        MessageBox.Show("Thêm tỉnh thành mới thành công.");
                    }
                }
            }
            this.cmbTinhThanh_SelectedIndexChanged(sender, e);
        }

        private void btnThemQuanHuyen_Click(object sender, EventArgs e)
        {

            string TenQuanHuyen = cmbQuanHuyen.Text;
            string MaTinh = txtMaTinhThanh.Text;
            string MaQuanHuyen = txtMaQuanHuyen.Text;

            if (string.IsNullOrWhiteSpace(MaTinh) == true ||
                string.IsNullOrWhiteSpace(MaQuanHuyen) == true)
            {
                MessageBox.Show("Mã tỉnh và quận huyện không được bỏ trống.");
            }
            else
            {
                if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiTinhThanhTheoMa(MaTinh) == false)
                {
                    MessageBox.Show("Tỉnh có mã " + MaTinh + " không tồn tại!");
                }
                else
                {
                    if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiQuanHuyenTheoMa(MaQuanHuyen))
                    {
                        MessageBox.Show("Quận/Huyện có mã " + MaQuanHuyen + " đã tồn tại!");
                    }
                    else
                    {
                        QuanHuyenInfo QuanHuyenObj = new QuanHuyenInfo();
                        QuanHuyenObj.MaQuanHuyen = MaQuanHuyen;
                        QuanHuyenObj.TenQuanHuyen = TenQuanHuyen;
                        QuanHuyenObj.MaTinh = MaTinh;

                        int result = m_ThemDanhMucHanhChinhControl.ThemQuanHuyenMoi(QuanHuyenObj);
                        if (result != 0)
                        {
                            MessageBox.Show("Thêm quận/huyện mới thành công.");
                        }
                    }
                }
            }
            this.cmbTinhThanh_SelectedIndexChanged(sender, e);           
        }

        private void btnThemPhuongXa_Click(object sender, EventArgs e)
        {            
            string MaQuanHuyen = txtMaQuanHuyen.Text;
            string MaPhuongXa = txtMaPhuongXa.Text;
            string TenPhuongXa = cmbPhuongXa.Text;
            if (string.IsNullOrWhiteSpace(MaQuanHuyen) == true ||
                string.IsNullOrWhiteSpace(MaPhuongXa) == true)
            {
                MessageBox.Show("Ma quận huyện và phường xã không được bỏ trống.");
            }
            else
            {
                if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiQuanHuyenTheoMa(MaQuanHuyen) == false)
                {
                    MessageBox.Show("Quận/Huyện có mã " + MaQuanHuyen + " không tồn tại!");
                }
                else
                {
                    if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiPhuongXaTheoMa(MaPhuongXa))
                    {
                        MessageBox.Show("Phường/Xã có mã " + MaPhuongXa + " đã tồn tại!");
                    }
                    else
                    {
                        PhuongXaInfo PhuongXaObj = new PhuongXaInfo();
                        PhuongXaObj.MaPhuongXa = MaPhuongXa;
                        PhuongXaObj.TenPhuongXa = TenPhuongXa;
                        PhuongXaObj.MaQuanHuyen = MaQuanHuyen;

                        int result = m_ThemDanhMucHanhChinhControl.ThemPhuongXaMoi(PhuongXaObj);
                        if (result != 0)
                        {
                            MessageBox.Show("Thêm phường/xã mới thành công.");
                        }
                    }
                }
            }
            this.cmbTinhThanh_SelectedIndexChanged(sender, e);
        }

        private void btnThemKhoiXom_Click(object sender, EventArgs e)
        {
            string MaPhuongXa = txtMaPhuongXa.Text;
            string MaKhoiXom = txtMaKhoiXom.Text;
            string TenKhoiXom = cmbKhoiXom.Text;
            if (string.IsNullOrWhiteSpace(MaPhuongXa) == true ||
                string.IsNullOrWhiteSpace(MaKhoiXom) == true)
            {
                MessageBox.Show("Ma phường xã và khối xóm không được bỏ trống.");
            }
            else
            {
                if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiPhuongXaTheoMa(MaPhuongXa) == false)
                {
                    MessageBox.Show("Phường/Xã có mã " + MaPhuongXa + " không tồn tại!");
                }
                else
                {
                    if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiKhoiXomTheoMa(MaKhoiXom))
                    {
                        MessageBox.Show("Khối/Xóm có mã " + MaKhoiXom + " đã tồn tại!");
                    }
                    else
                    {
                        KhoiXomInfo KhoiXomObj = new KhoiXomInfo();
                        KhoiXomObj.MaKhoiXom = MaKhoiXom;
                        KhoiXomObj.TenKhoiXom = TenKhoiXom;
                        KhoiXomObj.MaPhuongXa = MaPhuongXa;

                        int result = m_ThemDanhMucHanhChinhControl.ThemKhoiXomMoi(KhoiXomObj);
                        if (result != 0)
                        {
                            MessageBox.Show("Thêm khối/xóm mới thành công.");
                        }
                    }
                }
            }

            this.cmbTinhThanh_SelectedIndexChanged(sender, e);
        }

        private void btnLuuTinhThanh_Click(object sender, EventArgs e)
        {
            string MaTinh = txtMaTinhThanh.Text;
            string TenTinh = cmbTinhThanh.Text;

            if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiTinhThanhTheoMa(MaTinh) == false)
            {
                MessageBox.Show("Tỉnh có mã " + MaTinh + " không tồn tại.");
            }
            else
            {
                TinhThanhInfo TinhThanhObj = new TinhThanhInfo();
                TinhThanhObj.MaTinh = MaTinh;
                TinhThanhObj.TenTinh = TenTinh;
                m_ThemDanhMucHanhChinhControl.CapNhatTinhThanh(TinhThanhObj);                
                MessageBox.Show("Cập nhật thông tinh tỉnh/thành thành công.");
                
            }

            FrmThemDanhMucHanhChinh_Load(sender, e);
        }

        private void btnLuuQuanHuyen_Click(object sender, EventArgs e)
        {
            string MaQuanHuyen = txtMaQuanHuyen.Text;
            string TenQuanHuyen = cmbQuanHuyen.Text;

            if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiQuanHuyenTheoMa(MaQuanHuyen) == false)
            {
                MessageBox.Show("Quận/Huyện có mã " + MaQuanHuyen + " không tồn tại.");
            }
            else
            {
                QuanHuyenInfo QuanHuyenObj = new QuanHuyenInfo();
                QuanHuyenObj.MaQuanHuyen = MaQuanHuyen;
                QuanHuyenObj.TenQuanHuyen = TenQuanHuyen;
                m_ThemDanhMucHanhChinhControl.CapNhatQuanHuyen(QuanHuyenObj);
                MessageBox.Show("Cập nhật thông tinh quận/huyện thành công.");

            }

            FrmThemDanhMucHanhChinh_Load(sender, e);
        }

        private void btnLuuPhuongXa_Click(object sender, EventArgs e)
        {
            string MaPhuongXa = txtMaPhuongXa.Text;
            string TenPhuongXa = cmbPhuongXa.Text;

            if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiPhuongXaTheoMa(MaPhuongXa) == false)
            {
                MessageBox.Show("Phường/Xã có mã " + MaPhuongXa + " không tồn tại.");
            }
            else
            {
                PhuongXaInfo PhuongXaObj = new PhuongXaInfo();
                PhuongXaObj.MaPhuongXa = MaPhuongXa;
                PhuongXaObj.TenPhuongXa = TenPhuongXa;
                m_ThemDanhMucHanhChinhControl.CapNhatPhuongXa(PhuongXaObj);
                MessageBox.Show("Cập nhật thông tinh phường/xã thành công.");

            }

            FrmThemDanhMucHanhChinh_Load(sender, e);
        }

        private void btnLuuKhoiXom_Click(object sender, EventArgs e)
        {
            string MaKhoiXom = txtMaKhoiXom.Text;
            string TenKhoiXom = cmbKhoiXom.Text;

            if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiKhoiXomTheoMa(MaKhoiXom) == false)
            {
                MessageBox.Show("Khối/Xóm có mã " + MaKhoiXom + " không tồn tại.");
            }
            else
            {
                KhoiXomInfo KhoiXomObj = new KhoiXomInfo();
                KhoiXomObj.MaKhoiXom = MaKhoiXom;
                KhoiXomObj.TenKhoiXom = TenKhoiXom;
                m_ThemDanhMucHanhChinhControl.CapNhatKhoiXom(KhoiXomObj);
                MessageBox.Show("Cập nhật thông tinh khối/xóm thành công.");

            }

            FrmThemDanhMucHanhChinh_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoaKhoiXom_Click(object sender, EventArgs e)
        {
            string MaKhoiXom = txtMaKhoiXom.Text;            

            if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiKhoiXomTheoMa(MaKhoiXom) == false)
            {
                MessageBox.Show("Khối/Xóm có mã " + MaKhoiXom + " không tồn tại.");
            }
            else
            {                      
                m_ThemDanhMucHanhChinhControl.XoaKhoiXom(MaKhoiXom);
                MessageBox.Show("Xóa thông tinh khối/xóm thành công.");

            }

            FrmThemDanhMucHanhChinh_Load(sender, e);
        }

        private void btnXoaPhuongXa_Click(object sender, EventArgs e)
        {
            string MaPhuongXa = txtMaPhuongXa.Text;

            if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiPhuongXaTheoMa(MaPhuongXa) == false)
            {
                MessageBox.Show("Phường/Xã có mã " + MaPhuongXa + " không tồn tại.");
            }
            else
            {
                m_ThemDanhMucHanhChinhControl.XoaPhuongXa(MaPhuongXa);
                MessageBox.Show("Xóa thông tinh phường/xã thành công.");

            }

            FrmThemDanhMucHanhChinh_Load(sender, e);
        }

        private void btnXoaQuanHuyen_Click(object sender, EventArgs e)
        {
            string MaQuanHuyen = txtMaQuanHuyen.Text;

            if (m_ThemDanhMucHanhChinhControl.KiemTraTonTaiQuanHuyenTheoMa(MaQuanHuyen) == false)
            {
                MessageBox.Show("Quận/Huyện có mã " + MaQuanHuyen + " không tồn tại.");
            }
            else
            {
                m_ThemDanhMucHanhChinhControl.XoaQuanHuyen(MaQuanHuyen);
                MessageBox.Show("Xóa thông tinh Quận/Huyện thành công.");
            }

            FrmThemDanhMucHanhChinh_Load(sender, e);
        }                                          

    }
}
