using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyHoSoCongChuc.Models;
using QuanLyHoSoCongChuc.Utils;

namespace QuanLyHoSoCongChuc
{
    /// <summary>
    /// Singleton class that is used to interact with database
    /// </summary>
    public class DataContext
    {
        private static QLHSCCEntities _dataContext = null;

        static DataContext()
        {
           _dataContext = new QLHSCCEntities(GlobalVars.g_strConnectionString);
        }

        public static QLHSCCEntities Instance
        {
            get { return _dataContext; }
        }
    }
}