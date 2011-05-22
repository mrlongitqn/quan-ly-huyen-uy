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
        }

        private void btnDongNSD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Load list of nguoi dung exist in DB
        /// </summary>
        public void LoadNguoiDung()
        {
            try
            {
                var lstItem = NguoiDungRepository.SelectAll();
                for (int i = 0; i < lstItem.Count; i++)
                {
                    lstItem.Add(lstItem[i]);
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

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtMatKhau.Text = "";
            txtMoTa.Text = "";
            ResetStateOfLoaiNguoiDung();
        }

        private void btnThemNSD_Click(object sender, EventArgs e)
        {

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
            if (txtHoTen.Text == "")
            {
                errorText = "Vui lòng nhập tên ";
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
                var item = new ChucNang
                {
                    TenChucNang = txtTenChucNang.Text
                };
                if (!ChucNangRepository.Insert(item))
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
                var item = ChucNangRepository.SelectByID(int.Parse(txtMaChucNang.Text));
                item.TenChucNang = txtTenChucNang.Text;
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
                return ChucNangRepository.Delete(int.Parse(txtMaChucNang.Text));
            }
            catch
            {
                return false;
            }
        }
    }
}