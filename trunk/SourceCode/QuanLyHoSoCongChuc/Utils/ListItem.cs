using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc
{
    public class ListItem
    {
        private string id = "0";
        private string name = string.Empty;
        public ListItem(string sid, string sname)
        {
            id = sid;
            name = sname;
        }
        public override string ToString()
        {
            return this.name;
        }
        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }
}
