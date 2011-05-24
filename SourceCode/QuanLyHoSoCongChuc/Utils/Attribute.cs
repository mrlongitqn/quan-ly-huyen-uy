using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.Utils
{
    public enum DataType
    {
        INT,
        STRING,
        GUILD,
        DATETIME,
        BOOL,
        FLOAT,
        DOUBLE,
        LONG
    }

    /// <summary>
    /// tuansl added: attributes of a table
    /// </summary>
    public class Attribute
    {
        public string Name { get; set; }
        public DataType Type { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsForeignKey { get; set; }
        public string ReferTo { get; set; }
        public bool IsIdentify { get; set; }

        public Attribute()
        {
            Name = "";
            Type = DataType.STRING;
            IsPrimaryKey = false;
            IsForeignKey = false;
            ReferTo = "";
            IsIdentify = false;
        }
    }
}
