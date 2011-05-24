using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.Models
{
    public partial class GioiTinh
    {
        public override string ToString()
        {
            return TenGioiTinh;
        }
    }

    public partial class DanToc
    {
        public override string ToString()
        {
            return TenDanToc;
        }
    }

    public partial class TonGiao
    {
        public override string ToString()
        {
            return TenTonGiao;
        }
    }

    public partial class TrinhDoChinhTri
    {
        public override string ToString()
        {
            return TenTrinhDoChinhTri;
        }
    }

    public partial class TrinhDoHocVan
    {
        public override string ToString()
        {
            return TenTrinhDoHocVan;
        }
    }

    public partial class TrinhDoChuyenMon
    {
        public override string ToString()
        {
            return TenTrinhDoChuyenMon;
        }
    }
}
