using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyHoSoCongChuc.Models;

namespace QuanLyHoSoCongChuc.Search
{
    public class GlobalSearch
    {
        public static Dictionary<string, QuanLyHoSoCongChuc.Utils.Attribute> LstTruongHienThi { get; set; }

        public static QuanLyHoSoCongChuc.Utils.Attribute GetAttInDict(Dictionary<string, QuanLyHoSoCongChuc.Utils.Attribute> dict, string key)
        {
            try
            {
                return dict[key];
            }
            catch
            {
                return null;
            }
        }
    }
}
