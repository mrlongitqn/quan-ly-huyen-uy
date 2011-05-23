using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLyHoSoCongChuc.Utils;

namespace QuanLyHoSoCongChuc.UsersDiary
{
    /// <summary>
    /// tuansl added: form is used to manage user diary
    /// </summary>
    public partial class FrmNhatKySuDung : DevComponents.DotNetBar.Office2007Form
    {
        private DanhSachNhatKySuDung lstUserDaries = new DanhSachNhatKySuDung();
        public FrmNhatKySuDung()
        {
            InitializeComponent();
        }

        private void FrmNhatKySuDung_Load(object sender, EventArgs e)
        {
            if (LoadUserDiary(GlobalVars.g_strPathNhatKi))
            {
                try
                {
                    var count = 1;
                    lstvNhatKySuDung.Items.Clear();
                    for (int i = 0; i < lstUserDaries.LstNhatKyNguoiDung.Count; i++)
                    {
                        // Get user
                        var nguoidung = lstUserDaries.LstNhatKyNguoiDung[i];
                        for (int j = 0; j < nguoidung.LstNhatkySuDung.Count; j++)
                        {
                            // Get nhatkysudung of user
                            var nhatkysudung = nguoidung.LstNhatkySuDung[j];
                            var objListViewItem = new ListViewItem();
                            objListViewItem.Tag = nguoidung.TenTruyCap + "-" + nhatkysudung.ThoiDiemVao;
                            objListViewItem.Text = count.ToString();
                            objListViewItem.SubItems.Add(nguoidung.TenTruyCap);
                            objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", nhatkysudung.ThoiDiemVao));
                            objListViewItem.SubItems.Add(String.Format("{0:dd/MM/yyyy}", nhatkysudung.ThoiDiemRa));
                            objListViewItem.SubItems.Add(nhatkysudung.TenMayTram);
                            lstvNhatKySuDung.Items.Add(objListViewItem);

                            // Loop for list of used functionalities
                            var count2 = 1;
                            lstvChucNangSuDung.Items.Clear();
                            for (int k = 0; k < nhatkysudung.LstChucNangSuDung.Count; k++)
                            {
                                var chucnangsudung = nhatkysudung.LstChucNangSuDung[k];
                                objListViewItem = new ListViewItem();
                                objListViewItem.Text = count2.ToString();
                                objListViewItem.SubItems.Add(chucnangsudung.TenChucNang.ToString());
                                objListViewItem.SubItems.Add(chucnangsudung.SoLan.ToString());
                                lstvChucNangSuDung.Items.Add(objListViewItem);
                                count2++;
                            }
                            count++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }

        public bool LoadUserDiary(string pathFile)
        {
            if (lstUserDaries.LoadDiary(pathFile))
            {
                return true;
            }
            return false;
        }
    }
}