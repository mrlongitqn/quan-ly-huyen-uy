using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLyHoSoCongChuc.Utils
{
    /// <summary>
    /// tuansl added: class contain validate methods
    /// </summary>
    public class Validations
    {
        public static bool IsValidaDateTime(string dataCheck)
        {
            var expression = new Regex(@"^(\d){1,2}\/(\d){4}");
            if (expression.IsMatch(dataCheck))
            {
                try
                {
                    var date = DateTime.Parse(dataCheck);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public static bool IsNumeric(string dataCheck)
        {
            try
            {
                int val = int.Parse(dataCheck);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
