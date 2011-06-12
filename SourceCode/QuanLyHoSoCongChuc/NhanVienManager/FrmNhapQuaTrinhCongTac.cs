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
    using QuanLyHoSoCongChuc.Utils;
    using QuanLyHoSoCongChuc.OtherForms;
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    using System.Text.RegularExpressions;
    #endregion

    /// <summary>
    /// tuansl added: insert new congtac progress
    /// </summary>
    public partial class FrmNhapQuaTrinhCongTac : DevComponents.DotNetBar.Office2007Form
    {
        public EventHandler Handler { get; set; }
        private bool Updated = false;
        private NhanVien _nhanvien;
        private EnumUpdateMode UpdateMode = EnumUpdateMode.INSERT; 
        // Hidden files are used to store ids 
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaNuocCongTac;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaQuaTrinhCongTac;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaCapUy;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaCapUyKiem;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaChucVuChinhQuyen;

        public FrmNhapQuaTrinhCongTac(NhanVien nhanvien)
        {
            InitializeComponent();
            InitHiddenFields();
            _nhanvien = nhanvien;
            txtHoTen.Text = _nhanvien.HoTenKhaiSinh;
            txtMaNhanVien.Text = _nhanvien.MaNhanVien;
            LoadData();
        }

        /// <summary>
        /// Load list of congtac progresses of specified nhanvien
        /// </summary>
        public void LoadData()
        {
            if (_nhanvien != null)
            {
                var lstItem = QuaTrinhCongTacRepository.SelectByMaNhanVien(_nhanvien.MaNhanVien);
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

        /// <summary>
        /// Init hidden fields
        /// </summary>
        public void InitHiddenFields()
        {
            // Add a new textbox
            txtMaQuaTrinhCongTac = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaQuaTrinhCongTac",
                Text = ""
            };
            txtMaQuaTrinhCongTac.Visible = false;

            // Add a new textbox
            txtMaNuocCongTac = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaNuocCongTac",
                Text = ""
            };
            txtMaNuocCongTac.Visible = false;

            // Add a new textbox
            txtMaCapUy = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaCapUy",
                Text = ""
            };
            txtMaCapUy.Visible = false;

            // Add a new textbox
            txtMaCapUyKiem = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaCapUyKiem",
                Text = ""
            };
            txtMaCapUyKiem.Visible = false;

            // Add a new textbox
            txtMaChucVuChinhQuyen = new DevComponents.DotNetBar.Controls.TextBoxX
            {
                Name = "txtMaChucVuChinhQuyen",
                Text = ""
            };
            txtMaChucVuChinhQuyen.Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UpdateMode = EnumUpdateMode.INSERT;
            EraseTextboxes();
            SetDefaultMode(false);
            DisableCmdButtons();
            txtTuThangNam.Focus();
        }

        private void btnChonNuocCongTac_Click(object sender, EventArgs e)
        {
            FrmQuanLyQuocGia frm = new FrmQuanLyQuocGia();
            frm.Handler += GetNuocCT;
            frm.ShowDialog();
        }

        public void GetNuocCT(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaNuocCongTac.Text = comp[0];
            txtNuocCongTac.Text = comp[1];
        }

        private void btnChonCapUy_Click(object sender, EventArgs e)
        {
            FrmQuanLyCapUy frm = new FrmQuanLyCapUy();
            frm.Handler += GetCapUy;
            frm.ShowDialog();
        }

        public void GetCapUy(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaCapUy.Text = comp[0];
            txtCapUy.Text = comp[1];
        }

        private void btnChonCapUyKiem_Click(object sender, EventArgs e)
        {
            FrmQuanLyCapUyKiem frm = new FrmQuanLyCapUyKiem();
            frm.Handler += GetCapUyKiem;
            frm.ShowDialog();
        }

        public void GetCapUyKiem(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaCapUyKiem.Text = comp[0];
            txtCapUyKiem.Text = comp[1];
        }

        private void btnChonChucVuChinhQuyen_Click(object sender, EventArgs e)
        {
            FrmQuanLyChucVuChinhQuyen frm = new FrmQuanLyChucVuChinhQuyen();
            frm.Handler += GetChucVuCQ;
            frm.ShowDialog();
        }

        public void GetChucVuCQ(object sender, EventArgs e)
        {
            var eventType = (MyEvent)e;
            string[] comp = eventType.Data.Split(new char[] { '#' });
            txtMaChucVuChinhQuyen.Text = comp[0];
            txtChucVuChinhQuyen.Text = comp[1];
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNhapQuaTrinhCongTac_FormClosed(object sender, FormClosedEventArgs e)
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

        private void FrmNhapQuaTrinhCongTac_Load(object sender, EventArgs e)
        {
            EraseTextboxes();
            SetDefaultMode(true);
        }

        private void listViewEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvData.SelectedItems.Count > 0)
            {
                var item = (QuaTrinhCongTac)lstvData.SelectedItems[0].Tag;

                txtMaQuaTrinhCongTac.Text = item.MaQuaTrinhCongTac.ToString();
                txtTuThangNam.Text = String.Format("{0:MM/yyyy}", item.ThoiGianBatDau.Value);
                txtDenThangNam.Text = String.Format("{0:MM/yyyy}", item.ThoiGianKetThuc.Value);
                txtMoTaCongTac.Text = item.MoTaCongTac;

                txtNuocCongTac.Text = item.MaNuocCongTac == null ? "" : item.QuocGia.TenQuocGia;
                txtMaNuocCongTac.Text = item.MaNuocCongTac == null ? "" : item.MaNuocCongTac.ToString();

                txtCapUy.Text = item.MaCapUy == null ? "" : item.CapUy.TenCapUy;
                txtMaCapUy.Text = item.MaCapUy == null ? "" : item.MaCapUy.ToString();

                txtCapUyKiem.Text = item.MaCapUyKiem == null ? "" : item.CapUyKiem.TenCapUyKiem;
                txtMaCapUyKiem.Text = item.MaCapUyKiem == null ? "" : item.MaCapUyKiem.ToString();

                txtChucDanh.Text = item.ChucDanh;

                txtChucVuChinhQuyen.Text = item.MaChucVuChinhQuyen == null ? "" : item.ChucVuChinhQuyen.TenChucVuChinhQuyen;
                txtMaChucVuChinhQuyen.Text = item.MaChucVuChinhQuyen == null ? "" : item.MaChucVuChinhQuyen.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaQuaTrinhCongTac.Text != "")
            {
                UpdateMode = EnumUpdateMode.UPDATE;
                SetDefaultMode(false);
                DisableCmdButtons();
                txtTuThangNam.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaQuaTrinhCongTac.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (QuaTrinhCongTacRepository.Delete(int.Parse(txtMaQuaTrinhCongTac.Text)))
                    {
                        MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Updated = true;
                        EraseTextboxes();
                        txtMaQuaTrinhCongTac.Text = "";
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
            if (txtMoTaCongTac.Text == "")
            {
                errorText = "Vui lòng nhập mô tả công tác";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Update foreign keys need to insert
        /// </summary>
        /// <param name="quatrinhcongtac"></param>
        public void UpdateForeignKeys(ref QuaTrinhCongTac quatrinh)
        {
            if (txtMaNuocCongTac.Text != "")
            {
                quatrinh.MaNuocCongTac = int.Parse(txtMaNuocCongTac.Text);
            }
            if (txtMaCapUy.Text != "")
            {
                quatrinh.MaCapUy = int.Parse(txtMaCapUy.Text);
            }
            if (txtMaCapUyKiem.Text != "")
            {
                quatrinh.MaCapUyKiem = int.Parse(txtMaCapUyKiem.Text);
            }
            if (txtMaChucVuChinhQuyen.Text != "")
            {
                quatrinh.MaChucVuChinhQuyen = int.Parse(txtMaChucVuChinhQuyen.Text);
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
                var newItem = new QuaTrinhCongTac
                {
                    MaNhanVien = _nhanvien.MaNhanVien,
                    ChucDanh = txtChucDanh.Text,
                    MoTaCongTac = txtMoTaCongTac.Text,
                    ThoiGianBatDau = DateTime.Parse(txtTuThangNam.Text),
                    ThoiGianKetThuc = DateTime.Parse(txtDenThangNam.Text)
                };

                UpdateForeignKeys(ref newItem);

                if (!QuaTrinhCongTacRepository.Insert(newItem))
                {
                    return false;
                }
                RefreshQuaTrinh(newItem.MaQuaTrinhCongTac.ToString());
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
                var quatrinh = QuaTrinhCongTacRepository.SelectByID(int.Parse(txtMaQuaTrinhCongTac.Text));
                quatrinh.MaNhanVien = _nhanvien.MaNhanVien;
                quatrinh.ChucDanh = txtChucDanh.Text;
                quatrinh.MoTaCongTac = txtMoTaCongTac.Text;
                quatrinh.ThoiGianBatDau = DateTime.Parse(txtTuThangNam.Text);
                quatrinh.ThoiGianKetThuc = DateTime.Parse(txtDenThangNam.Text);

                UpdateForeignKeys(ref quatrinh);

                return QuaTrinhCongTacRepository.Save();
            }
            catch
            {
                return false;
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

        /// <summary>
        /// Load info of current quatrinh
        /// If mode is insert: update txtMaQuaTrinhCongTac
        /// Else: not change
        /// </summary>
        public void LoadCurrentQuaTrinhInfo(int id)
        {
            var item = QuaTrinhCongTacRepository.SelectByID(id);

            txtMaQuaTrinhCongTac.Text = id.ToString();
            txtTuThangNam.Text = String.Format("{0:MM/yyyy}", item.ThoiGianBatDau.Value);
            txtDenThangNam.Text = String.Format("{0:MM/yyyy}", item.ThoiGianKetThuc.Value);
            txtMoTaCongTac.Text = item.MoTaCongTac;

            txtNuocCongTac.Text = item.MaNuocCongTac == null ? "" : item.QuocGia.TenQuocGia;
            txtMaNuocCongTac.Text = item.MaNuocCongTac == null ? "" : item.MaNuocCongTac.ToString();

            txtCapUy.Text = item.MaCapUy == null ? "" : item.CapUy.TenCapUy;
            txtMaCapUy.Text = item.MaCapUy == null ? "" : item.MaCapUy.ToString();

            txtCapUyKiem.Text = item.MaCapUyKiem == null ? "" : item.CapUyKiem.TenCapUyKiem;
            txtMaCapUyKiem.Text = item.MaCapUyKiem == null ? "" : item.MaCapUyKiem.ToString();

            txtChucDanh.Text = item.ChucDanh;

            txtChucVuChinhQuyen.Text = item.MaChucVuChinhQuyen == null ? "" : item.ChucVuChinhQuyen.TenChucVuChinhQuyen;
            txtMaChucVuChinhQuyen.Text = item.MaChucVuChinhQuyen == null ? "" : item.MaChucVuChinhQuyen.ToString();
        }

        /// <summary>
        /// There's 2 case:
        /// Case 1: cancel when no current quatrinh
        /// Case 2: data of current qua trinh is loaded in fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Case 1
            if (txtMaQuaTrinhCongTac.Text != "")
                LoadCurrentQuaTrinhInfo(int.Parse(txtMaQuaTrinhCongTac.Text));
            else
                EraseTextboxes();

            SetDefaultMode(true);
            btnThem.Focus();
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
            txtMaQuaTrinhCongTac.Text = val;
        }

        /// <summary>
        /// Erase data in textboxes when mode is insert
        /// </summary>
        public void EraseTextboxes()
        {
            txtTuThangNam.Text = "";
            txtDenThangNam.Text = "";
            txtMoTaCongTac.Text = "";

            txtNuocCongTac.Text = "";
            txtMaNuocCongTac.Text = "";

            txtCapUy.Text = "";
            txtMaCapUy.Text = "";

            txtCapUyKiem.Text = "";
            txtMaCapUyKiem.Text = "";

            txtChucDanh.Text = "";

            txtChucVuChinhQuyen.Text = "";
            txtMaChucVuChinhQuyen.Text = "";
        }

        /// <summary>
        /// Set default status
        /// </summary>
        /// <param name="val">default is true</param>
        public void SetDefaultMode(bool val = true)
        {
            txtTuThangNam.ReadOnly = val;
            txtDenThangNam.ReadOnly = val;
            txtMoTaCongTac.ReadOnly = val;
            txtChucDanh.ReadOnly = val;

            btnChonNuocCongTac.Enabled = !val;
            btnChonCapUy.Enabled = !val;
            btnChonCapUyKiem.Enabled = !val;
            btnChonChucVuChinhQuyen.Enabled = !val;

            btnThem.Enabled = val;
            btnSua.Enabled = val;
            btnXoa.Enabled = val;
            btnGhi.Enabled = !val;
            btnHuy.Enabled = !val;
        }
    }
}