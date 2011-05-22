using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QuanLyHoSoCongChuc.UsersManager
{
    #region Using
    using QuanLyHoSoCongChuc.Models;
    using QuanLyHoSoCongChuc.Repositories;
    using QuanLyHoSoCongChuc.Utils;
    #endregion

    public partial class FrmQuanLyNguoiDung : DevComponents.DotNetBar.Office2007Form
    {
        // Using this variable to get which ma loai nguoi dung is specified
        private int SpecifiedMaLoaiNguoiDung = -1;
        private int SpecifiedMaNguoiDung = -1;

        public FrmQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void FrmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            LoadLoaiNguoiDung();
            LoadChucNang();
            LoadNguoiDung();
            txtNgayDangKi.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
        }

        private void btnDongNSD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstvNhomNguoiDung_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < lstvNhomNguoiDung.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        lstvNhomNguoiDung.Items[i].Checked = false;
                    }
                    else
                    {
                        SpecifiedMaLoaiNguoiDung = (int)lstvNhomNguoiDung.Items[e.Index].Tag;
                        ResetStateOfChucNang();
                        LoadChucNangBelongToNguoiDung(SpecifiedMaLoaiNguoiDung);
                    }
                }
            }
        }

        private void lstbxNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbxNguoiDung.SelectedIndex != -1)
            {
                try
                {
                    var nguoidung = (NguoiDung)lstbxNguoiDung.SelectedItem;
                    txtTenDangNhap.Text = nguoidung.TenDangNhap;
                    txtMatKhau.Text = Encryption.Decrypt(nguoidung.MatKhau);
                    txtHoTen.Text = nguoidung.TenNguoiDung;
                    txtNgayDangKi.Text = nguoidung.NgayDangKi == null ? DateTime.Now.ToShortDateString() : String.Format("{0:dd/MM/yyyy}", nguoidung.NgayDangKi.Value);
                    txtMoTa.Text = nguoidung.MoTa;
                    SpecifiedMaNguoiDung = nguoidung.MaNguoiDung;
                    for (int i = 0; i < lstvNhomNguoiDung.Items.Count; i++)
                    {
                        if (nguoidung.MaQuyen == (int)lstvNhomNguoiDung.Items[i].Tag)
                        {
                            lstvNhomNguoiDung.Items[i].Checked = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            txtMoTa.Text = "";
            txtNgayDangKi.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            ResetStateOfLoaiNguoiDung();
            ResetStateOfChucNang();
        }

        private void btnThemNSD_Click(object sender, EventArgs e)
        {
            var errorText = "";
            // true: update
            // false: add/delete
            if (!ValidateInput(false, ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ActionAdd())
            {
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNguoiDung();
            }
            else
            {
                MessageBox.Show("Lưu dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaNSD_Click(object sender, EventArgs e)
        {
            var errorText = "";
            // true: update
            // false: add/delete
            if (!ValidateInput(false, ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn xóa dòng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ActionDelete())
                {
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadNguoiDung();
                    btnNhapMoi_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGhiNSD_Click(object sender, EventArgs e)
        {
            var errorText = "";
            // true: update
            // false: add/delete
            if (!ValidateInput(true, ref errorText))
            {
                MessageBox.Show(errorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ActionUpdate())
            {
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNguoiDung();
                ReChoosingNguoiDung(SpecifiedMaNguoiDung);
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load list of nguoi dung exist in DB
        /// </summary>
        public void LoadNguoiDung()
        {
            try
            {
                var lstItem = NguoiDungRepository.SelectAll();
                lstbxNguoiDung.Items.Clear();
                for (int i = 0; i < lstItem.Count; i++)
                {
                    // Only add another nguoi dung, not me ()
                    if (lstItem[i].TenDangNhap != GlobalVars.g_strTenDangNhap)
                    {
                        lstbxNguoiDung.Items.Add(lstItem[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Reset check state of list all of chuc nang loaded in list view
        /// </summary>
        public void ResetStateOfChucNang()
        {
            for (int i = 0; i < lstvChucNangDuocSuDung.Items.Count; i++)
            {
                lstvChucNangDuocSuDung.Items[i].Checked = false;
            }
        }

        /// <summary>
        /// Reset check state of list all of loai nguoi dung loaded in list view
        /// </summary>
        public void ResetStateOfLoaiNguoiDung()
        {
            for (int i = 0; i < lstvNhomNguoiDung.Items.Count; i++)
            {
                lstvNhomNguoiDung.Items[i].Checked = false;
            }
        }

        /// <summary>
        /// Load list of chuc nang belong to specified loai nguoi dung
        /// </summary>
        public void LoadChucNangBelongToNguoiDung(int maloainguoidung)
        {
            try
            {
                var lstItem = LoaiNguoiDung_ChucNangRepository.SelectByMaQuyen(maloainguoidung);
                // Loop for obtained list of chuc nang
                for (int i = 0; i < lstItem.Count; i++)
                {
                    // Loop for obtained list all of chuc nang, if which item have ma chuc nang equal specified chuc nang
                    // => Set check state is checked
                    for (int j = 0; j < lstvChucNangDuocSuDung.Items.Count; j++)
                    {
                        if ((int)lstvChucNangDuocSuDung.Items[j].Tag == lstItem[i].MaChucNang)
                        {
                            lstvChucNangDuocSuDung.Items[j].Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Load list all of loai nguoi dung exist in DB
        /// </summary>
        public void LoadLoaiNguoiDung()
        {
            try
            {
                var lstItem = LoaiNGuoiDungRepository.SelectAll();
                if (lstItem.Count > 0)
                {
                    ListViewItem objListViewItem;
                    lstvNhomNguoiDung.Items.Clear();
                    for (int i = 0; i < lstItem.Count; i++)
                    {
                        objListViewItem = new ListViewItem();
                        objListViewItem.Tag = lstItem[i].MaQuyen;
                        objListViewItem.Text = lstItem[i].TenQuyen;
                        objListViewItem.ImageIndex = 0;
                        lstvNhomNguoiDung.Items.Add(objListViewItem);
                    }
                }
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

        /// <summary>
        /// Load list all of chuc nang exist in DB
        /// </summary>
        public void LoadChucNang()
        {
            try
            {
                var lstItem = ChucNangRepository.SelectAll();
                if (lstItem.Count > 0)
                {
                    ListViewItem objListViewItem;
                    lstvChucNangDuocSuDung.Items.Clear();
                    for (int i = 0; i < lstItem.Count; i++)
                    {
                        objListViewItem = new ListViewItem();
                        objListViewItem.Tag = lstItem[i].MaChucNang;
                        objListViewItem.SubItems.Add(lstItem[i].TenChucNang);
                        lstvChucNangDuocSuDung.Items.Add(objListViewItem);
                    }
                }
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

        /// <summary>
        /// Validate user input
        /// </summary>
        /// <param name="isUpdate"></param>
        /// <returns></returns>
        private bool ValidateInput(bool isUpdate, ref string errorText)
        {
            // Mode update -> checking MaChucNang is exists on textbox
            if (isUpdate)
            {
                if (SpecifiedMaNguoiDung == -1)
                {
                    errorText = "Vui lòng chọn người dùng";
                    return false;
                }
            }

            if (txtTenDangNhap.Text == "")
            {
                errorText = "Vui lòng nhập tên đăng nhập ";
                return false;
            }

            if (txtMatKhau.Text == "")
            {
                errorText = "Vui lòng nhập mật khẩu ";
                return false;
            }

            if (txtHoTen.Text == "")
            {
                errorText = "Vui lòng nhập tên người dùng ";
                return false;
            }

            if (SpecifiedMaLoaiNguoiDung == -1)
            {
                errorText = "Vui lòng chọn loại người dùng";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Add a new item to DB
        /// </summary>
        /// <returns></returns>
        private bool ActionAdd()
        {
            try
            {
                var item = new NguoiDung
                {
                    MaQuyen = SpecifiedMaLoaiNguoiDung,
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = Encryption.Encrypt(txtMatKhau.Text.Trim()),
                    TenNguoiDung = txtHoTen.Text.Trim(),
                    NgayDangKi = DateTime.Now
                };
                if (!NguoiDungRepository.Insert(item))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update item with specificed ID
        /// </summary>
        /// <returns></returns>
        private bool ActionUpdate()
        {
            try
            {
                var item = NguoiDungRepository.SelectByID(SpecifiedMaNguoiDung);
                item.MaQuyen = SpecifiedMaLoaiNguoiDung;
                item.TenDangNhap = txtTenDangNhap.Text.Trim();
                item.MatKhau = Encryption.Encrypt(txtMatKhau.Text.Trim());
                item.TenNguoiDung = txtHoTen.Text.Trim();
                item.MoTa = txtMoTa.Text.Trim();
                return ChucNangRepository.Save();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete item with specified ID
        /// </summary>
        /// <returns></returns>
        private bool ActionDelete()
        {
            try
            {
                return NguoiDungRepository.Delete(SpecifiedMaNguoiDung);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// After user was updated, re-choosing that user in listbox nguoi dung
        /// </summary>
        /// <param name="manguoidung"></param>
        public void ReChoosingNguoiDung(int manguoidung)
        {
            for (int i = 0; i < lstbxNguoiDung.Items.Count; i++)
            {
                if (((NguoiDung)lstbxNguoiDung.Items[i]).MaNguoiDung == manguoidung)
                {
                    lstbxNguoiDung.SetSelected(i, true);
                }
            }
        }
    }
}