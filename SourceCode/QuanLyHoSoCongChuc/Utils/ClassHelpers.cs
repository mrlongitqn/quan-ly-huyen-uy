using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.Utils
{
    /// <summary>
    /// tuansl added: class used to present data item with data type is bool 
    /// </summary>
    public class BoolDataItem
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
