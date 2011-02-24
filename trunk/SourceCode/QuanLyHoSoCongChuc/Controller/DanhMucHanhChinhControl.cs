using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using QuanLyHoSoCongChuc.DataLayer;
using QuanLyHoSoCongChuc.BusinessObject;

namespace QuanLyHoSoCongChuc.Controller
{
    public class DanhMucHanhChinhControl
    {
        TinhThanhData m_TinhThanhData = new TinhThanhData();
        QuanHuyenData m_QuanHuyenData = new QuanHuyenData();
        PhuongXaData m_PhuongXaData = new PhuongXaData();
        KhoiXomData m_KhoiXomData = new KhoiXomData();

        public void HienThiTreeView(TreeView tv)
        {
            DataTable dtDSTinhThanh = m_TinhThanhData.LayDSTinhThanh();
            DataTable dtDSQuanHuyen = m_QuanHuyenData.LayDSQuanHuyen();
            DataTable dtDSPhuongXa = m_PhuongXaData.LayDSPhuongXa();
            DataTable dtDSKhoiXom = m_KhoiXomData.LayDSKhoiXom();

            TreeNode n0 = new TreeNode();
            n0.Text = "Danh Muc Hanh Chinh";
            foreach (DataRow rowTinhThanhTemp in dtDSTinhThanh.Rows)
            {
                TreeNode n1 = new TreeNode();
                n1.Text = rowTinhThanhTemp["TenTinh"].ToString();
                n1.Tag = rowTinhThanhTemp["MaTinh"].ToString();

                foreach (DataRow rowQuanHuyenTemp in dtDSQuanHuyen.Rows)
                {
                    TreeNode n2 = new TreeNode();
                    if (n1.Tag.ToString().CompareTo(rowQuanHuyenTemp["MaTinh"].ToString()) == 0)
                    {
                        n2.Text = rowQuanHuyenTemp["TenQuanHuyen"].ToString();
                        n2.Tag = rowQuanHuyenTemp["MaQuanHuyen"].ToString();
                        n1.Nodes.Add(n2);

                        foreach (DataRow rowPhuongXaTemp in dtDSPhuongXa.Rows)
                        {
                            TreeNode n3 = new TreeNode();
                            if (n2.Tag.ToString().CompareTo(rowPhuongXaTemp["MaQuanHuyen"].ToString()) == 0)
                            {
                                n3.Text = rowPhuongXaTemp["TenPhuongXa"].ToString();
                                n3.Tag = rowPhuongXaTemp["MaPhuongXa"].ToString();
                                n2.Nodes.Add(n3);

                                foreach (DataRow rowKhoiXomTemp in dtDSKhoiXom.Rows)
                                {
                                    TreeNode n4 = new TreeNode();
                                    if (n3.Tag.ToString().CompareTo(rowKhoiXomTemp["MaPhuongXa"].ToString()) == 0)
                                    {
                                        n4.Text = rowKhoiXomTemp["TenKhoiXom"].ToString();
                                        n4.Tag = rowKhoiXomTemp["MaKhoiXom"].ToString();
                                        n3.Nodes.Add(n4);
                                    }
                                }

                            }                            
                        }
                    }
                }
                n0.Nodes.Add(n1);
            }

            tv.Nodes.Add(n0);
        }

    }
}
