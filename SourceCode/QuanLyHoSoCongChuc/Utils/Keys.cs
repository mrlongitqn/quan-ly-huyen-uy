using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.Utils
{
    /// <summary>
    /// tuansl added: foreign key
    /// </summary>
    public class ForeignKey
    {
        public List<string> Name { get; set; }
        public string ReferTo { get; set; }
    }

    /// <summary>
    /// tuansl added: primary key
    /// </summary>
    public class PrimaryKey
    {
        public string Name { get; set; }
        public bool IsIdentify { get; set; }

        public PrimaryKey()
        {
            IsIdentify = false;
        }
    }
}
