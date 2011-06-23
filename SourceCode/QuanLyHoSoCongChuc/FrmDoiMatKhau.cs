using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyHoSoCongChuc
{
    #region Using
    using DevComponents.DotNetBar;
    using QuanLyHoSoCongChuc.Utils;
    using QuanLyHoSoCongChuc.Repositories;
    #endregion
    public partial class FrmDoiMatKhau : Office2007Form
    {
        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }
 
        private void btnDongY_Click(object sender, EventArgs e)
        {
            string errorText = "";
            if (txtOldPassword.Text == "")
            {
                errorText = "Chưa nhập mật khẩu hiện tại!";
                goto Cont;
            }

            if (txtNewPassword.Text == "")
            {
                errorText = "Chưa nhập mật khẩu mới!";
                goto Cont;
            }

            if (txtReNPassword.Text == "")
            {
                errorText = "Chưa nhập xác nhận mật khẩu!";
                goto Cont;
            }

            String password = GlobalVars.g_CurrentUser.MatKhau;

            String m_OldPassword = txtOldPassword.Text;
            String m_NewPassword = txtNewPassword.Text;
            String m_ReNPassword = txtReNPassword.Text;

            if (password != Encryption.Encrypt(m_OldPassword))
            {
                errorText = "Nhập sai mật khẩu cũ!";
                goto Cont;
            }
            else if (m_NewPassword != m_ReNPassword)
            {
                errorText = "Nhập xác nhận không khớp!";
                goto Cont;
            }
            else
            {
                GlobalVars.g_CurrentUser.MatKhau = Encryption.Encrypt(m_NewPassword);
                if (NguoiDungRepository.Save())
                {
                    MessageBoxEx.Show("Đổi mật khẩu thành công!", "PASSWORD CHANGED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        Cont:
            MessageBoxEx.Show(errorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            Close();
        }   
       
    }
}