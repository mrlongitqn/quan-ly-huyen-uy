using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using WeifenLuo.WinFormsUI;
using QuanLyHoSoCongChuc.Controller;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc
{
    public partial class FrmChucNangQTCTMoi : Office2007Form
    {
        ChucNangQTCTMoiControl m_ChucNangQTCTMoiControl = new ChucNangQTCTMoiControl();

        public FrmChucNangQTCTMoi()
        {
            InitializeComponent();
        }

        private void FrmChucNangQTCTMoi_Load(object sender, EventArgs e)
        {
            DataService.OpenConnection();
            m_ChucNangQTCTMoiControl.HienThiThongTinNhanVien(cmbHoTen);            
            if (cmbHoTen.SelectedValue != null)
            {
                m_ChucNangQTCTMoiControl.HienThiThongTinDang(cmbHoTen.SelectedValue.ToString(), txtIdDangVien);
                m_ChucNangQTCTMoiControl.HienThiDataGridView(dgvQuaTrinhCongTac, cmbHoTen.SelectedValue.ToString());
                m_ChucNangQTCTMoiControl.HienThiQuocGia(cmbNuocCongTac);
                m_ChucNangQTCTMoiControl.HienThiCapUy(cmbCapUy);
                m_ChucNangQTCTMoiControl.HienThiCapUyKiem(cmbCapUyKiem);
                m_ChucNangQTCTMoiControl.HienThiCapUyChucVuChinhQuyen(cmbChucVuChinhQuyen);
            }
        }

        private void cmbHoTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MaNhanVien = ((ComboBox)sender).SelectedValue.ToString();
            string TenNhanVien = ((ComboBox)sender).Text.ToString();

            if (string.IsNullOrEmpty(MaNhanVien) == false)
            {
                m_ChucNangQTCTMoiControl.HienThiThongTinDang(MaNhanVien, txtIdDangVien);                                
                m_ChucNangQTCTMoiControl.HienThiDataGridView(dgvQuaTrinhCongTac, MaNhanVien);
            }
            
        }

        private void dgvQuaTrinhCongTac_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            if (row != null && row.Cells["STT"].Value != null)
            {
                txtSTT.Text = row.Cells["STT"].Value.ToString();
                dtpThoiGianBatdau.Value = (DateTime)row.Cells["ThoiGianBatDau"].Value;
                dtpThoiGianKetThuc.Value = (DateTime)row.Cells["ThoiGianKetThuc"].Value;
                txtMoTaCongTac.Text = row.Cells["MoTaCongTac"].Value.ToString();
                txtChucDanh.Text = row.Cells["ChucDanh"].Value.ToString();


                foreach (DataRowView rvTemp in cmbNuocCongTac.Items)
                {
                    if (rvTemp["MaQuocGia"].ToString() == row.Cells["MaNuocCongTac"].Value.ToString())
                    {
                        cmbNuocCongTac.SelectedItem = rvTemp;
                    }
                }

                foreach (DataRowView rvTemp in cmbCapUy.Items)
                {
                    if (rvTemp["MaCapUy"].ToString() == row.Cells["MaCapUy"].Value.ToString())
                    {
                        cmbCapUy.SelectedItem = rvTemp;
                    }
                }

                foreach (DataRowView rvTemp in cmbCapUyKiem.Items)
                {
                    if (rvTemp["MaCapUyKiem"].ToString() == row.Cells["MaCapUyKiem"].Value.ToString())
                    {
                        cmbCapUyKiem.SelectedItem = rvTemp;
                    }
                }

                foreach (DataRowView rvTemp in cmbChucVuChinhQuyen.Items)
                {
                    if (rvTemp["MaChucVuChinhQuyen"].ToString() == row.Cells["MaChucVuChinhQuyen"].Value.ToString())
                    {
                        cmbChucVuChinhQuyen.SelectedItem = rvTemp;
                    }
                }
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            QuaTrinhCongTacMoiInfo qtct = new QuaTrinhCongTacMoiInfo();
            qtct.MaNhanVien = cmbHoTen.SelectedValue.ToString();
            qtct.MoTaCongTac = txtMoTaCongTac.Text;
            qtct.MaNuocCongTac = int.Parse(cmbNuocCongTac.SelectedValue.ToString());
            qtct.MaCapUy = int.Parse(cmbCapUy.SelectedValue.ToString());
            qtct.MaCapUyKiem = int.Parse(cmbCapUyKiem.SelectedValue.ToString());
            qtct.ChucDanh = txtChucDanh.Text;
            qtct.MaChucVuChinhQuyen = int.Parse(cmbChucVuChinhQuyen.SelectedValue.ToString());
            qtct.ThoiGianBatDau = dtpThoiGianBatdau.Value;
            qtct.ThoiGianKetThuc = dtpThoiGianKetThuc.Value;

            m_ChucNangQTCTMoiControl.ThemQuaTrinhCongTac(qtct);
            m_ChucNangQTCTMoiControl.HienThiDataGridView(dgvQuaTrinhCongTac, qtct.MaNhanVien);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            QuaTrinhCongTacMoiInfo qtct = new QuaTrinhCongTacMoiInfo();
            qtct.MaNhanVien = cmbHoTen.SelectedValue.ToString();
            qtct.MoTaCongTac = txtMoTaCongTac.Text;
            qtct.MaNuocCongTac = int.Parse(cmbNuocCongTac.SelectedValue.ToString());
            qtct.MaCapUy = int.Parse(cmbCapUy.SelectedValue.ToString());
            qtct.MaCapUyKiem = int.Parse(cmbCapUyKiem.SelectedValue.ToString());
            qtct.ChucDanh = txtChucDanh.Text;
            qtct.MaChucVuChinhQuyen = int.Parse(cmbChucVuChinhQuyen.SelectedValue.ToString());
            qtct.ThoiGianBatDau = dtpThoiGianBatdau.Value;
            qtct.ThoiGianKetThuc = dtpThoiGianKetThuc.Value;

            if (dgvQuaTrinhCongTac.CurrentRow.Cells["MaQTCT"].Value != null)
            {
                qtct.MaQuaTrinhCongTac = int.Parse(dgvQuaTrinhCongTac.CurrentRow.Cells["MaQTCT"].Value.ToString());
            }

            m_ChucNangQTCTMoiControl.CapNhatQuaTrinhCongTac(qtct);
            m_ChucNangQTCTMoiControl.HienThiDataGridView(dgvQuaTrinhCongTac, qtct.MaNhanVien);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {            
            if (dgvQuaTrinhCongTac.CurrentRow.Cells["MaQTCT"].Value != null)
            {
                int MaQTCT;
                MaQTCT = int.Parse(dgvQuaTrinhCongTac.CurrentRow.Cells["MaQTCT"].Value.ToString());
                m_ChucNangQTCTMoiControl.XoaQuaTrinhCongTac(MaQTCT);
            }
            
            m_ChucNangQTCTMoiControl.HienThiDataGridView(dgvQuaTrinhCongTac, cmbHoTen.SelectedValue.ToString());
        }


    }
}
