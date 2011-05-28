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
    public partial class FrmLuuCauHoi : DevComponents.DotNetBar.Office2007Form
    {
        public List<DieuKienTimKiem> LstDieuKienTimKiem { get; set; }
        public string Bang { get; set; }
        public string MaDonVi { get; set; }
        
        public FrmLuuCauHoi()
        {
            InitializeComponent();
        }

        private void LoadCauHoi()
        {
            lstvDieuKienTimKiem.Items.Clear();
            for (int i = 0; i < LstDieuKienTimKiem.Count; i++)
            {
                var objListViewItem = new ListViewItem
                {
                    Tag = LstDieuKienTimKiem[i],
                    Text = LstDieuKienTimKiem[i].AndOr + " " + LstDieuKienTimKiem[i].Attr.Name + LstDieuKienTimKiem[i].Condition + LstDieuKienTimKiem[i].Value
                };
                lstvDieuKienTimKiem.Items.Add(objListViewItem);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenCauHoi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập vào tên câu hỏi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LstDieuKienTimKiem.Count > 0)
            {
                var lst = new List<DieuKienThanhPhan>();
                for (int i = 0; i < LstDieuKienTimKiem.Count; i++)
                {
                    var dieukienthanhphan = new DieuKienThanhPhan
                    {
                        ThuocTinhDieuKien = LstDieuKienTimKiem[i].AndOr.Trim(),
                        Bien = LstDieuKienTimKiem[i].Attr.Name.Trim(),
                        DieuKien = LstDieuKienTimKiem[i].Condition.Trim(),
                        GiaTri = LstDieuKienTimKiem[i].Value.Trim()
                    };
                    lst.Add(dieukienthanhphan);
                }
                GlobalVars.g_CauHoiNguoiDung = new CauHoiNguoiDung
                {
                    Bang = this.Bang,
                    MaDonVi = this.MaDonVi,
                    TenCauHoi = txtTenCauHoi.Text.Trim(),
                    LstDieuKien = lst
                };
                if (GlobalVars.g_CauHoiNguoiDung.CheckingNameQueyExist(GlobalVars.g_strPathCauhoiTimKiem))
                {
                    MessageBox.Show("Tên câu hỏi đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (GlobalVars.g_CauHoiNguoiDung.SaveUserQuery(GlobalVars.g_strPathCauhoiTimKiem))
                    {
                        MessageBox.Show("Lưu câu hỏi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Lưu câu hỏi thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chuỗi điều kiện không có giá trị", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLuuCauHoi_Load(object sender, EventArgs e)
        {
            LoadCauHoi();
        }
    }
}