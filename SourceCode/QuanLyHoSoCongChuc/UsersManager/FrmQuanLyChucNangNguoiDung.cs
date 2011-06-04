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

    /// <summary>
    /// tuansl added: manage functionalities corresponding with specified loai nguoi dung
    /// </summary>
    public partial class frmQuanLyChucNangNguoiDung : DevComponents.DotNetBar.Office2007Form
    {
        // Using this variable to get which ma loai nguoi dung is specified
        private int SpecifiedMaLoaiNguoiDung = -1;

        public frmQuanLyChucNangNguoiDung()
        {
            InitializeComponent();
        }

        private void frmQuanLyChucNangNguoiDung_Load(object sender, EventArgs e)
        {
            LoadLoaiNguoiDung();
            LoadChucNang();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event is raised when user check on an item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Only executed when there's at least 1 loai nguoi dung is chosen  
            if (SpecifiedMaLoaiNguoiDung != -1)
            {
                // Get list of chose chuc nang
                var lstChoseChucNang = new List<int>();
                for (int i = 0; i < lstvChucNangDuocSuDung.Items.Count; i++)
                {
                    if (lstvChucNangDuocSuDung.Items[i].Checked)
                    {
                        lstChoseChucNang.Add((int)lstvChucNangDuocSuDung.Items[i].Tag);
                    }
                }
                if (lstChoseChucNang.Count > 0)
                {
                    // Before insert new list of chuc nang for loai nguoi dung, we remove list of chuc nang belong to loai nguoi dung that have been associated before
                    if (DeleteChucNangBelongToNguoiDung(SpecifiedMaLoaiNguoiDung))
                    {
                        var successful = false;
                        for (int i = 0; i < lstChoseChucNang.Count; i++)
                        {
                            var item = new LoaiNguoiDung_ChucNang
                            {
                                MaQuyen = SpecifiedMaLoaiNguoiDung,
                                MaChucNang = lstChoseChucNang[i]
                            };
                            successful = LoaiNguoiDung_ChucNangRepository.Insert(item);
                        }
                        if (successful)
                            MessageBox.Show("Lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Có lỗi trong quá trình thực thi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Có lỗi trong quá trình thực thi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                var lstItem = LoaiNguoiDungRepository.SelectAll();
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
        /// Remove list of chuc nang belong to loai nguoi dung
        /// </summary>
        /// <param name="maloainguoidung"></param>
        /// <returns></returns>
        private bool DeleteChucNangBelongToNguoiDung(int maloainguoidung)
        {
            try
            {
                var lstItem = LoaiNguoiDung_ChucNangRepository.SelectByMaQuyen(maloainguoidung);
                for (int i = 0; i < lstItem.Count; i++)
                {
                    LoaiNguoiDung_ChucNangRepository.Delete(lstItem[i].MaChucNangNguoiDung);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}