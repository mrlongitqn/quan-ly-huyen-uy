using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHoSoCongChuc.Utils
{
    /// <summary>
    /// tuansl added: Class is used to transfer data
    /// </summary>
    public class MyEvent : EventArgs
    {
        public string Data { get; set; }
        public MyEvent(string _data)
        {
            Data = _data;
        }
    }

    /// <summary>
    /// tuansl added: Class is used to transfer data loaded from file
    /// </summary>
    public class MyQueryEvent : EventArgs
    {
        public object Data { get; set; }
        public MyQueryEvent(object _data)
        {
            Data = _data;
        }
    }
}
