using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QuanLyHoSoCongChuc.NhanVienManager
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Utils;
    using QuanLyHoSoCongChuc.Repositories;
    using QuanLyHoSoCongChuc.OtherForms;
    #endregion

    /// <summary>
    /// tuansl added: insert new daotao progress
    /// </summary>
    public partial class FrmNhapQuaTrinhDaoTao : DevComponents.DotNetBar.Office2007Form
    {
        public EventHandler Handler { get; set; }
        private bool Updated = false;
        private NhanVien _nhanvien;
        private EnumUpdateMode UpdateMode = EnumUpdateMode.INSERT;
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaQuaTrinhDaoTao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaNuocDaoTao;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHinhThucHoc;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaBangGDPT;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaBangLLCT;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaBangNN;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaBangCMNV;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHocHam;

        public FrmNhapQuaTrinhDaoTao(NhanVien nhanvien)
        {
            InitializeComponent();
            InitHiddenFields();
            _nhanvien = nhanvien;
            txtHoTen.Text = _nhanvien.HoTenKhaiSinh;
            txtMaNhanVien.Text = _nhanvien.MaNhanVien;
            LoadData();
        }

        /// <summary>
        /// Init hidden fields
        /// </summary>
        public void InitHiddenFields()
        {
            // Add a new textbox
            txtMaQuaTrinhDaoTao = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaQuaTrinhDaoTao",
                Text = ""
            };
            txtMaQuaTrinhDaoTao.Visible = false;

            // Add a new textbox
            txtMaNuocDaoTao = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaNuocDaoTao",
                Text = ""
            };
            txtMaNuocDaoTao.Visible = false;

            // Add a new textbox
            txtMaHinhThucHoc = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHinhThucHoc",
                Text = ""
            };
            txtMaHinhThucHoc.Visible = false;

            // Add a new textbox
            txtMaBangGDPT = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaBangGDPT",
                Text = ""
            };
            txtMaBangGDPT.Visible = false;

            // Add a new textbox
            txtMaBangLLCT = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaBangLLCT",
                Text = ""
            };
            txtMaBangLLCT.Visible = false;

            // Add a new textbox
            txtMaBangNN = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaBangNN",
                Text = ""
            };
            txtMaBangNN.Visible = false;

            // Add a new textbox
            txtMaBangCMNV = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaBangCMNV",
                Text = ""
            };
            txtMaBangCMNV.Visible = false;

            // Add a new textbox
            txtMaHocHam = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaHocHam",
                Text = ""
            };
            txtMaHocHam.Visible = false;
        }

        /// <summary>
        /// Load list of congtac progresses of specified nhanvien
        /// </summary>
        public void LoadData()
        {
            if (_nhanvien != null)
            {
                var lstItem = QuaTrinhDaoTaoRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
                lstvData.Items.Clear();
                for (int i = 0; i < lstItem.Count; i++)
                {
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];
                    objListViewItem.Text = (i + 1).ToString();
                    objListViewItem.SubItems.Add(String.Format("{0:MM/yyyy}", lstItem[i].ThoiGianBatDau.Value));
                    objListViewItem.SubItems.Add(String.Format("{0:MM/yyyy}", lstItem[i].ThoiGianKetThuc.Value));
                    lstvData.Items.Add(objListViewItem);
                }
            }
        }

        private void btnChonNuocDaoTao_Click(object sender, EventArgs e)
        {
            FrmQuanLyQuocGia frm = new FrmQuanLyQuocGia();
            frm.Handler += GetNuocDT;
            frm.ShowDialog();
        }

        public void GetNuocDT(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaNuocDaoTao.Text = comp[0];
            txtNuocDaoTao.Text = comp[1];
        }

        private void btnChonHinhThucHoc_Click(object sender, EventArgs e)
        {
            FrmQuanLyHinhThucDaoTao frm = new FrmQuanLyHinhThucDaoTao();
            frm.Handler += GetHinhThucHoc;
            frm.ShowDialog();
        }

        public void GetHinhThucHoc(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaHinhThucHoc.Text = comp[0];
            txtHinhThucHoc.Text = comp[1];
        }

        private void btnChonGDPT_Click(object sender, EventArgs e)
        {
            FrmQuanLyBangGiaoDucPhoThong frm = new FrmQuanLyBangGiaoDucPhoThong();
            frm.Handler += GetGDPT;
            frm.ShowDialog();
        }

        public void GetGDPT(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaBangGDPT.Text = comp[0];
            txtBangGDPT.Text = comp[1];
        }

        private void btnChonLLCT_Click(object sender, EventArgs e)
        {
            FrmQuanLyBangLyLuanChinhTri frm = new FrmQuanLyBangLyLuanChinhTri();
            frm.Handler += GetLLCT;
            frm.ShowDialog();
        }

        public void GetLLCT(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaBangLLCT.Text = comp[0];
            txtBangLLCT.Text = comp[1];
        }

        private void btnChonNN_Click(object sender, EventArgs e)
        {
            FrmQuanLyBangNgoaiNgu frm = new FrmQuanLyBangNgoaiNgu();
            frm.Handler += GetNN;
            frm.ShowDialog();
        }

        public void GetNN(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaBangNN.Text = comp[0];
            txtBangNN.Text = comp[1];
        }

        private void btnChonCMNV_Click(object sender, EventArgs e)
        {
            FrmQuanLyBangChuyenMonNghiepVu frm = new FrmQuanLyBangChuyenMonNghiepVu();
            frm.Handler += GetCMNV;
            frm.ShowDialog();
        }

        public void GetCMNV(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaBangCMNV.Text = comp[0];
            txtBangCMNV.Text = comp[1];
        }

        private void btnChonHocHam_Click(object sender, EventArgs e)
        {
            FrmQuanLyHocHam frm = new FrmQuanLyHocHam();
            frm.Handler += GetHocHam;
            frm.ShowDialog();
        }

        public void GetHocHam(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaHocHam.Text = comp[0];
            txtHocHam.Text = comp[1];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UpdateMode = EnumUpdateMode.INSERT;
            EraseTextboxes();
            SetDefaultMode(false);
            DisableCmdButtons();
            txtTuThangNam.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaQuaTrinhDaoTao.Text != "")
            {
                UpdateMode = EnumUpdateMode.UPDATE;
                SetDefaultMode(false);
                DisableCmdButtons();
                txtTuThangNam.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaQuaTrinhDaoTao.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (QuaTrinhCongTacRepository.Delete(int.Parse(txtMaQuaTrinhDaoTao.Text)))
                    {
                        MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EraseTextboxes();
                        txtMaQuaTrinhDaoTao.Text = "";
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            string errorText = "";
            if (!ValidateUserInput(ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UpdateMode == EnumUpdateMode.INSERT)
            {
                if (ActionAdd())
                {
                    MessageBox.Show("Lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetDefaultMode(true);
                    Updated = true;
                }
                else
                {
                    MessageBox.Show("Lưu dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (UpdateMode == EnumUpdateMode.UPDATE)
            {
                if (ActionUpdate())
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetDefaultMode(true);
                    Updated = true;
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Case 1
            if (txtMaQuaTrinhDaoTao.Text != "")
                LoadCurrentQuaTrinhInfo(int.Parse(txtMaQuaTrinhDaoTao.Text));
            else
                EraseTextboxes();

            SetDefaultMode(true);
            btnThem.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvData.SelectedItems.Count > 0)
            {
                var item = (QuaTrinhDaoTao)lstvData.SelectedItems[0].Tag;

                txtMaQuaTrinhDaoTao.Text = item.MaQuaTrinhDaoTao.ToString();
                txtTuThangNam.Text = String.Format("{0:MM/yyyy}", item.ThoiGianBatDau.Value);
                txtDenThangNam.Text = String.Format("{0:MM/yyyy}", item.ThoiGianKetThuc.Value);
                txtTenTruong.Text = item.TenTruong;
                txtNganhHoc.Text = item.NganhHoc;

                txtNuocDaoTao.Text = item.MaNuocDaoTao == null ? "" : item.QuocGia.TenQuocGia;
                txtMaNuocDaoTao.Text = item.MaNuocDaoTao == null ? "" : item.MaNuocDaoTao.ToString();

                txtHinhThucHoc.Text = item.MaHinhThucDaoTao == null ? "" : item.HinhThucDaoTao.TenHinhThucDaoTao;
                txtMaHinhThucHoc.Text = item.MaHinhThucDaoTao == null ? "" : item.MaHinhThucDaoTao.ToString();

                txtBangGDPT.Text = item.MaBangGiaoDucPhoThong == null ? "" : item.BangGiaoDucPhoThong.TenBangGiaoDucPhoThong;
                txtMaBangGDPT.Text = item.MaBangGiaoDucPhoThong == null ? "" : item.MaBangGiaoDucPhoThong.ToString();

                txtBangLLCT.Text = item.MaBangLyLuanChinhTri == null ? "" : item.BangLyLuanChinhTri.TenBangLyLuanChinhTri;
                txtMaBangLLCT.Text = item.MaBangLyLuanChinhTri == null ? "" : item.MaBangLyLuanChinhTri.ToString();

                txtBangNN.Text = item.MaBangNgoaiNgu == null ? "" : item.BangNgoaiNgu.TenBangNgoaiNgu;
                txtBangNN.Text = item.MaBangNgoaiNgu == null ? "" : item.MaBangNgoaiNgu.ToString();

                txtBangCMNV.Text = item.MaBangChuyenMonNghiepVu == null ? "" : item.BangChuyenMonNghiepVu.TenBangChuyenMonNghiepVu;
                txtMaBangCMNV.Text = item.MaBangChuyenMonNghiepVu == null ? "" : item.MaBangChuyenMonNghiepVu.ToString();

                txtHocHam.Text = item.MaHocHam == null ? "" : item.HocHam.TenHocHam;
                txtMaHocHam.Text = item.MaHocHam == null ? "" : item.MaHocHam.ToString();
            }
        }

        private void FrmNhapQuaTrinhDaoTao_Load(object sender, EventArgs e)
        {
            EraseTextboxes();
            SetDefaultMode(true);
        }

        /// <summary>
        /// Validate user inputs
        /// </summary>
        /// <returns></returns>
        public bool ValidateUserInput(ref string errorText)
        {
            var strNgay = txtTuThangNam.Text.Replace('/', ' ');
            if (!Validations.IsValidaDateTime(txtTuThangNam.Text))
            {
                errorText = "Vui lòng nhập thời gian bắt đầu";
                return false;
            }
            if (!Validations.IsValidaDateTime(txtDenThangNam.Text))
            {
                errorText = "Vui lòng nhập thời gian kết thúc";
                return false;
            }
            if (txtTenTruong.Text == "")
            {
                errorText = "Vui lòng nhập tên trường";
                return false;
            }
            if (txtNganhHoc.Text == "")
            {
                errorText = "Vui lòng nhập ngành học";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Update foreign keys need to insert
        /// </summary>
        /// <param name="quatrinhcongtac"></param>
        public void UpdateForeignKeys(ref QuaTrinhDaoTao quatrinh)
        {
            if (txtMaNuocDaoTao.Text != "")
            {
                quatrinh.MaNuocDaoTao = int.Parse(txtMaNuocDaoTao.Text);
            }
            if (txtMaHinhThucHoc.Text != "")
            {
                quatrinh.MaHinhThucDaoTao = int.Parse(txtMaHinhThucHoc.Text);
            }
            if (txtMaBangGDPT.Text != "")
            {
                quatrinh.MaBangGiaoDucPhoThong = int.Parse(txtMaBangGDPT.Text);
            }
            if (txtMaBangLLCT.Text != "")
            {
                quatrinh.MaBangLyLuanChinhTri = int.Parse(txtMaBangLLCT.Text);
            }
            if (txtMaBangNN.Text != "")
            {
                quatrinh.MaBangNgoaiNgu = int.Parse(txtMaBangNN.Text);
            }
            if (txtMaBangCMNV.Text != "")
            {
                quatrinh.MaBangChuyenMonNghiepVu = int.Parse(txtMaBangCMNV.Text);
            }
            if (txtMaHocHam.Text != "")
            {
                quatrinh.MaHocHam = int.Parse(txtMaHocHam.Text);
            }
        }

        /// <summary>
        /// Add a new item to DB
        /// </summary>
        /// <returns></returns>
        private bool ActionAdd()
        {
            try
            {
                var newItem = new QuaTrinhDaoTao
                {
                    MaNhanVien = _nhanvien.MaNhanVien,
                    ThoiGianBatDau = DateTime.Parse(txtTuThangNam.Text),
                    ThoiGianKetThuc = DateTime.Parse(txtDenThangNam.Text),
                    TenTruong = txtTenTruong.Text,
                    NganhHoc = txtNganhHoc.Text
                };

                UpdateForeignKeys(ref newItem);

                if (!QuaTrinhDaoTaoRepository.Insert(newItem))
                {
                    return false;
                }
                RefreshQuaTrinh(newItem.MaQuaTrinhDaoTao.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update an item in DB
        /// </summary>
        /// <returns></returns>
        private bool ActionUpdate()
        {
            try
            {
                var quatrinh = QuaTrinhDaoTaoRepository.SelectByID(int.Parse(txtMaQuaTrinhDaoTao.Text));
                quatrinh.MaNhanVien = _nhanvien.MaNhanVien;
                quatrinh.ThoiGianBatDau = DateTime.Parse(txtTuThangNam.Text);
                quatrinh.ThoiGianKetThuc = DateTime.Parse(txtDenThangNam.Text);
                quatrinh.TenTruong = txtTenTruong.Text;
                quatrinh.NganhHoc = txtNganhHoc.Text;

                UpdateForeignKeys(ref quatrinh);

                return QuaTrinhCongTacRepository.Save();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load info of current quatrinh
        /// If mode is insert: update txtMaQuaTrinh
        /// Else: not change
        /// </summary>
        public void LoadCurrentQuaTrinhInfo(int id)
        {
            var item = QuaTrinhDaoTaoRepository.SelectByID(id);

            txtMaQuaTrinhDaoTao.Text = id.ToString();
            txtTuThangNam.Text = String.Format("{0:MM/yyyy}", item.ThoiGianBatDau.Value);
            txtDenThangNam.Text = String.Format("{0:MM/yyyy}", item.ThoiGianKetThuc.Value);
            txtTenTruong.Text = item.TenTruong;
            txtNganhHoc.Text = item.NganhHoc;

            txtNuocDaoTao.Text = item.MaNuocDaoTao == null ? "" : item.QuocGia.TenQuocGia;
            txtMaNuocDaoTao.Text = item.MaNuocDaoTao == null ? "" : item.MaNuocDaoTao.ToString();

            txtHinhThucHoc.Text = item.MaHinhThucDaoTao == null ? "" : item.HinhThucDaoTao.TenHinhThucDaoTao;
            txtMaHinhThucHoc.Text = item.MaHinhThucDaoTao == null ? "" : item.MaHinhThucDaoTao.ToString();

            txtBangGDPT.Text = item.MaBangGiaoDucPhoThong == null ? "" : item.BangGiaoDucPhoThong.TenBangGiaoDucPhoThong;
            txtMaBangGDPT.Text = item.MaBangGiaoDucPhoThong == null ? "" : item.MaBangGiaoDucPhoThong.ToString();

            txtBangLLCT.Text = item.MaBangLyLuanChinhTri == null ? "" : item.BangLyLuanChinhTri.TenBangLyLuanChinhTri;
            txtMaBangLLCT.Text = item.MaBangLyLuanChinhTri == null ? "" : item.MaBangLyLuanChinhTri.ToString();

            txtBangNN.Text = item.MaBangNgoaiNgu == null ? "" : item.BangNgoaiNgu.TenBangNgoaiNgu;
            txtMaBangNN.Text = item.MaBangNgoaiNgu == null ? "" : item.MaBangNgoaiNgu.ToString();

            txtBangCMNV.Text = item.MaBangChuyenMonNghiepVu == null ? "" : item.BangChuyenMonNghiepVu.TenBangChuyenMonNghiepVu;
            txtMaBangCMNV.Text = item.MaBangChuyenMonNghiepVu == null ? "" : item.MaBangChuyenMonNghiepVu.ToString();

            txtHocHam.Text = item.MaHocHam == null ? "" : item.HocHam.TenHocHam;
            txtMaHocHam.Text = item.MaHocHam == null ? "" : item.MaHocHam.ToString();
        }

        /// <summary>
        /// Disable them, xoa, sua
        /// </summary>
        public void DisableCmdButtons()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        /// <summary>
        /// Store ma qua trinh cong tac
        /// </summary>
        /// <param name="val"></param>
        public void RefreshQuaTrinh(string val)
        {
            txtMaQuaTrinhDaoTao.Text = val;
        }

        /// <summary>
        /// Erase data in textboxes when mode is insert
        /// </summary>
        public void EraseTextboxes()
        {
            txtTuThangNam.Text = "";
            txtDenThangNam.Text = "";
            txtTenTruong.Text = "";
            txtNganhHoc.Text = "";

            txtNuocDaoTao.Text = "";
            txtMaNuocDaoTao.Text = "";

            txtHinhThucHoc.Text = "";
            txtMaHinhThucHoc.Text = "";

            txtBangGDPT.Text = "";
            txtMaBangGDPT.Text = "";

            txtBangLLCT.Text = "";
            txtMaBangLLCT.Text = "";

            txtBangNN.Text = "";
            txtMaBangNN.Text = "";

            txtBangCMNV.Text = "";
            txtMaBangCMNV.Text = "";

            txtHocHam.Text = "";
            txtMaHocHam.Text = "";
        }

        /// <summary>
        /// Set default status
        /// </summary>
        /// <param name="val">default is true</param>
        public void SetDefaultMode(bool val = true)
        {
            txtTuThangNam.ReadOnly = val;
            txtDenThangNam.ReadOnly = val;
            txtTenTruong.ReadOnly = val;
            txtNganhHoc.ReadOnly = val;

            btnChonNuocDaoTao.Enabled = !val;
            btnChonHinhThucHoc.Enabled = !val;
            btnChonGDPT.Enabled = !val;
            btnChonCMNV.Enabled = !val;
            btnChonNN.Enabled = !val;
            btnChonLLCT.Enabled = !val;
            btnChonHocHam.Enabled = !val;

            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnGhi.Enabled = !val;
            btnHuy.Enabled = !val;
        }

        private void FrmNhapQuaTrinhDaoTao_FormClosed(object sender, FormClosedEventArgs e)
        {
            TransferDataInfo(this, new MyEvent(Updated ? "true" : "false"));
        }

        /// <summary>
        /// tuansl added: function is used to transfer data when event would be raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TransferDataInfo(object sender, MyEvent e)
        {
            this.Handler(this, e);
        }
    }
}