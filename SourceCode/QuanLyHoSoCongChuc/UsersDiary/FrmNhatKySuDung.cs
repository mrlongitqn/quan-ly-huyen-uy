using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QuanLyHoSoCongChuc.UsersDiary
{
    #region Using
    using QuanLyHoSoCongChuc.Utils;
    using QuanLyHoSoCongChuc.Repositories;
    using QuanLyHoSoCongChuc.Models;
    #endregion

    /// <summary>
    /// tuansl added: form is used to manage user diary
    /// </summary>
    public partial class FrmNhatKySuDung : DevComponents.DotNetBar.Office2007Form
    {
        public FrmNhatKySuDung()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                var lstItem = NhatKyItemRepository.SelectAll();
                lstvNhatKySuDung.Items.Clear();
                for (int i = 0; i < lstItem.Count; i++)
                {
                    var objListViewItem = new ListViewItem();
                    objListViewItem.Tag = lstItem[i];
                    objListViewItem.Text = (i + 1).ToString();
                    objListViewItem.SubItems.Add(lstItem[i].NhatKy.NguoiDung.TenDangNhap);
                    objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy HH:mm:ss}", lstItem[i].ThoiDiemVao));
                    objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy HH:mm:ss}", lstItem[i].ThoiDiemRa));
                    objListViewItem.SubItems.Add(lstItem[i].TenMayTram);
                    lstvNhatKySuDung.Items.Add(objListViewItem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void FrmNhatKySuDung_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lstvNhatKySuDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvNhatKySuDung.SelectedItems.Count > 0)
            {
                // loop for list of used functionalities
                var nhatkyitem = (NhatKyItem)lstvNhatKySuDung.SelectedItems[0].Tag;
                lstvChucNangSuDung.Items.Clear();
                var lstChucNangSuDung = ChucNangSuDungRepository.SelectByMaNhatKyItem(nhatkyitem.MaNhatKyItem);

                for (int i = 0; i < lstChucNangSuDung.Count; i++)
                {
                    var objlistviewitem = new ListViewItem();
                    objlistviewitem.Text = (i + 1).ToString();
                    objlistviewitem.SubItems.Add(lstChucNangSuDung[i].TenChucNang);
                    objlistviewitem.SubItems.Add(lstChucNangSuDung[i].SoLan.ToString());
                    lstvChucNangSuDung.Items.Add(objlistviewitem);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (NhatKyItemRepository.DeleteAll())
                {
                    LoadData();
                    lstvChucNangSuDung.Items.Clear();
                }
            }
        }
    }
}