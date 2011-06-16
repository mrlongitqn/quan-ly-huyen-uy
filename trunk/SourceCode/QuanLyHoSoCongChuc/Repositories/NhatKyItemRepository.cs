using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChuc.Repositories
{
	#region using
	using QuanLyHoSoCongChuc.Models;
	#endregion
	public class NhatKyItemRepository
	{
		public static List<NhatKyItem> SelectAll()
		{
            return DataContext.Instance.NhatKyItems.OrderByDescending(item => item.ThoiDiemVao).ToList();
		}

		public static NhatKyItem SelectByID(int manhatkyitem)
		{
			return DataContext.Instance.NhatKyItems.FirstOrDefault(item => item.MaNhatKyItem == manhatkyitem );
		}

		public static bool Insert(NhatKyItem obj)
		{
			try
			{
				DataContext.Instance.NhatKyItems.AddObject(obj);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

        public static bool DeleteAll()
        {
            try
            {
                foreach (var delitem in DataContext.Instance.NhatKyItems.ToList())
                {
                    foreach (var chucnang in delitem.ChucNangSuDungs.ToList())
                    {
                        DataContext.Instance.ChucNangSuDungs.DeleteObject(chucnang);
                    }
                    DataContext.Instance.NhatKyItems.DeleteObject(delitem);
                    DataContext.Instance.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

		public static bool Delete(int manhatkyitem)
		{
			try
			{
				var delitem = DataContext.Instance.NhatKyItems.FirstOrDefault(item => item.MaNhatKyItem == manhatkyitem );
				DataContext.Instance.NhatKyItems.DeleteObject(delitem);
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool Save()
		{
			try
			{
				DataContext.Instance.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static List<NhatKyItem> RetrieveByID(int manhatkyitem)
		{
			return (from item in DataContext.Instance.NhatKyItems where  item.MaNhatKyItem == manhatkyitem  select item).ToList();
		}

		public static List<NhatKyItem> SelectByMaNhatKy(int manhatky)
		{
			var lstItem = (from item in DataContext.Instance.NhatKyItems where item.MaNhatKy == manhatky select item).ToList();
			return lstItem;
		}

	}
}