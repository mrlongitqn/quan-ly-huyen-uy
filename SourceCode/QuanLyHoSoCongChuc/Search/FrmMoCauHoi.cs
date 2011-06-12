using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Utils;

namespace QuanLyHoSoCongChuc.Search
{
    /// <summary>
    /// tuansl added: open list of user queries stored in file
    /// </summary>
    public partial class FrmMoCauHoi : DevComponents.DotNetBar.Office2007Form
    {
        public DanhSachCauHoiNguoiDung danhsachcauhoi = new DanhSachCauHoiNguoiDung();
        public EventHandler Handler { get; set; }

        public FrmMoCauHoi()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btChon_Click(object sender, EventArgs e)
        {
            if (lstvCauHoi.SelectedItems.Count > 0)
            {
                // Show waiting form
                GlobalVars.PreLoading();
                //------- E ---------

                TransferDataInfo(sender, new MyQueryEvent((CauHoiNguoiDung)lstvCauHoi.SelectedItems[0].Tag));

                // Pos waiting form
                GlobalVars.PosLoading();
                //------- E ---------
            }
            else
            {
                MessageBox.Show("Vui lòng chọn câu hỏi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstvCauHoi.SelectedItems.Count > 0)
            {
                if (danhsachcauhoi.RemoveCauHoi(GlobalVars.g_strPathCauhoiTimKiem, ((CauHoiNguoiDung)lstvCauHoi.SelectedItems[0].Tag).TenCauHoi))
                {
                    MessageBox.Show("Xóa câu hỏi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserQueries();
                }
                else
                {
                    MessageBox.Show("Xóa câu hỏi thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn câu hỏi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMoCauHoi_Load(object sender, EventArgs e)
        {
            LoadUserQueries();
        }

        public void LoadUserQueries()
        {
            // Load list of user queries from file
            danhsachcauhoi.LoadUserQueries(GlobalVars.g_strPathCauhoiTimKiem);
            lstvCauHoi.Items.Clear();
            for (int i = 0; i < danhsachcauhoi.LstCauHoiNguoiDung.Count; i++)
            {
                var objListviewItem = new ListViewItem();
                objListviewItem.Tag = danhsachcauhoi.LstCauHoiNguoiDung[i];
                objListviewItem.Text = (i + 1).ToString();
                objListviewItem.SubItems.Add(danhsachcauhoi.LstCauHoiNguoiDung[i].TenCauHoi);
                lstvCauHoi.Items.Add(objListviewItem);
            }
        }

        /// <summary>
        /// tuansl added: function is used to transfer data when event would be raised
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TransferDataInfo(object sender, MyQueryEvent e)
        {
            this.Close();
            this.Handler(this, e);
        }

        private void lstvCauHoi_DoubleClick(object sender, EventArgs e)
        {
            if (lstvCauHoi.SelectedItems.Count > 0)
            {
                // Show waiting form
                GlobalVars.PreLoading();
                //------- E ---------

                TransferDataInfo(sender, new MyQueryEvent((CauHoiNguoiDung)lstvCauHoi.SelectedItems[0].Tag));

                // Hide waiting form
                GlobalVars.PosLoading();
                //------- E ---------
            }
            else
            {
                MessageBox.Show("Vui lòng chọn câu hỏi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}