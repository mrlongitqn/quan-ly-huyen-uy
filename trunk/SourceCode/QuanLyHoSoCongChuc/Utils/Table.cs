using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.Utils
{
    /// <summary>
    /// Mapping table in DB to Table object in App
    /// </summary>
    public class Table
    {
        public string Name { get; set; }
        public List<Attribute> Attributes { get; set; }

        public Table()
        {
            Name = "";
            Attributes = new List<Attribute>();
        }
    }
}
