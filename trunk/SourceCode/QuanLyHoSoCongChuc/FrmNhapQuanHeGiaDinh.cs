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
    public partial class FrmNhapQuanHeGiaDinh : Office2007Form
    {
        string m_MaNhanVien;
        QuanHeGiaDinhControl m_QuanHeGiaDinhControl = new QuanHeGiaDinhControl();
        QuanHeControl m_QuanHeControl = new QuanHeControl();
        ThanNhanMoiControl m_ThanNhanMoiControl = new ThanNhanMoiControl();

        public string MaNhanVien
        {
            get { return m_MaNhanVien; }
            set { m_MaNhanVien = value; }
        }

        public FrmNhapQuanHeGiaDinh()
        {
            InitializeComponent();
        }

        private void FrmNhapQuanHeGiaDinh_Load(object sender, EventArgs e)
        {
            string HoTenNhanVien = m_QuanHeGiaDinhControl.LayTenNhanVien(MaNhanVien);
            string IDDangVien = m_QuanHeGiaDinhControl.LayIDDangVien(MaNhanVien);
            txtHoTen.Text = HoTenNhanVien;
            txtIDDangVien.Text = IDDangVien;
            m_QuanHeControl.HienThiDanhSachQuanHe(cmbQuanHe);

            m_ThanNhanMoiControl.HienThiDanhSachThanNhan(dgvThanNhan, MaNhanVien);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            ThanNhanMoiInfo tn = new ThanNhanMoiInfo();
            tn.TenThanNhan = txtHoTenThanNhan.Text;
            tn.MaQuanHe = cmbQuanHe.SelectedValue.ToString();
            tn.NamSinh = int.Parse(txtNamSinh.Text);
            tn.ThongTinCaNhan = txtThongTinCaNhan.Text;
            tn.MaNhanVien = MaNhanVien;

            m_ThanNhanMoiControl.ThemThanNhan(tn);
            m_ThanNhanMoiControl.HienThiDanhSachThanNhan(dgvThanNhan, MaNhanVien);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dgvThanNhan.CurrentRow.Cells["MaThanNhan"].Value != null)
            {
                int MaThanNhan;
                MaThanNhan = int.Parse(dgvThanNhan.CurrentRow.Cells["MaThanNhan"].Value.ToString());
                m_ThanNhanMoiControl.XoaThanNhan(MaThanNhan);
            }

            m_ThanNhanMoiControl.HienThiDanhSachThanNhan(dgvThanNhan, MaNhanVien);
        }

        private void dgvThanNhan_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            if (row != null && row.Cells["STT"].Value != null)
            {
                ThanNhanMoiInfo tn = m_ThanNhanMoiControl.LayThongTinThanNhan(int.Parse(row.Cells["MaThanNhan"].Value.ToString()));
                txtSTT.Text = row.Cells["STT"].Value.ToString();

                foreach (DataRowView rvTemp in cmbQuanHe.Items)
                {
                    if (rvTemp["MaQuanHe"].ToString() == tn.MaQuanHe)
                    {
                        cmbQuanHe.SelectedItem = rvTemp;
                    }
                }

                txtHoTenThanNhan.Text = tn.TenThanNhan;
                txtNamSinh.Text = tn.NamSinh.ToString();
                txtThongTinCaNhan.Text = tn.ThongTinCaNhan;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvThanNhan.CurrentRow;
            if (row != null && row.Cells["STT"].Value != null)
            {
                ThanNhanMoiInfo tn = new ThanNhanMoiInfo();
                tn.MaThanNhan = int.Parse(row.Cells["MaThanNhan"].Value.ToString());
                tn.TenThanNhan = txtHoTenThanNhan.Text;
                tn.MaQuanHe = cmbQuanHe.SelectedValue.ToString();
                tn.NamSinh = int.Parse(txtNamSinh.Text);
                tn.ThongTinCaNhan = txtThongTinCaNhan.Text;
                tn.MaNhanVien = MaNhanVien;

                m_ThanNhanMoiControl.CapNhatThanNhan(tn);
            }
            m_ThanNhanMoiControl.HienThiDanhSachThanNhan(dgvThanNhan, MaNhanVien);
        }


    }
}
