using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyHoSoCongChuc.Danh_muc
{
    class GlobalDanhMucs
    {
        /// <summary>
        /// Get level corresponding with node, it is used to realize chose node is the quanhuyen or tinh thanh or phuongxa, etc.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int GetLevelTreeView(TreeNode node)
        {
            if (node.Parent == null)
                return 1;
            else if (node.Parent.Parent == null)
                return 2;
            else if (node.Parent.Parent.Parent == null)
                return 3;
            else if (node.Parent.Parent.Parent.Parent == null)
                return 4;
            return -1;
        }
    }
}
