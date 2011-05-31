using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Repositories;
using QuanLyHoSoCongChuc.Utils;
using QuanLyHoSoCongChuc.Models;

namespace QuanLyHoSoCongChuc.DataManager
{
    public partial class FrmTimNhanVien : DevComponents.DotNetBar.Office2007Form
    {
        public EventHandler Handler { get; set; }
        private string _madonvi;

        public FrmTimNhanVien(string madonvi)
        {
            InitializeComponent();
            _madonvi = madonvi;
        }

        private void FrmTimNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lstvCanBo_DoubleClick(object sender, EventArgs e)
        {
            if (lstvNhanVien.SelectedItems.Count > 0)
            {
                TransferDataInfo(sender, new MyEvent(((NhanVien)lstvNhanVien.SelectedItems[0].Tag).MaNhanVien));
            }
        }

        /// <summary>
        /// tuansl added: function is used to transfer data when event would be raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TransferDataInfo(object sender, MyEvent e)
        {
            this.Close();
            this.Handler(this, e);
        }

        public void LoadData()
        {
            var lstItem = NhanVienRepository.SelectByMaDonVi(_madonvi);
            lstvNhanVien.Items.Clear();
            for (int i = 0; i < lstItem.Count; i++)
            {
                var objLstviewItem = new ListViewItem();
                objLstviewItem.Tag = lstItem[i];
                objLstviewItem.Text = (i + 1).ToString();
                objLstviewItem.SubItems.Add(lstItem[i].MaNhanVien);
                objLstviewItem.SubItems.Add(lstItem[i].HoTenNhanVien);
                lstvNhanVien.Items.Add(objLstviewItem);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btChon_Click(object sender, EventArgs e)
        {
            if (lstvNhanVien.SelectedItems.Count > 0)
            {
                TransferDataInfo(sender, new MyEvent(((NhanVien)lstvNhanVien.SelectedItems[0].Tag).MaNhanVien));
                return;
            }
            MessageBox.Show("Vui lòng chọn nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}