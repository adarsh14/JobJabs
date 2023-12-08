using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace JobJabs.Entity
{
    public class Common
    {
        public static string FormatDate(string DateToFormat)
        {
            DateToFormat = (DateToFormat == null ? "" : DateToFormat.ToString());

            string[] formats = { "yyyy-mm-dd", "dd MMM yyyy", "M/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "MM/d/yyyy", "yyyymmdd", "yyyymdd", "yyyymmd", "MM/dd/yyyy hh:mm:ss tt", "MM/d/yyyy hh:mm:ss tt", "M/d/yyyy hh:mm:ss tt", "M/dd/yyyy hh:mm:ss tt", "MM/dd/yyyy hh:mm:ss", "MM/d/yyyy hh:mm:ss", "M/d/yyyy hh:mm:ss", "M/dd/yyyy hh:mm:ss", "MM/dd/yyyy hh:mm", "MM/d/yyyy hh:mm", "M/d/yyyy hh:mm", "M/dd/yyyy hh:mm" };

            DateTime dateValue;
            if (DateTime.TryParseExact(DateToFormat, formats, new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out dateValue))
            {

                return Convert.ToDateTime(DateToFormat, new System.Globalization.CultureInfo("en-US")).ToString("MM/dd/yyyy");
            }

            return DateToFormat;

        }

        public static string FormatDate2(string DateToFormat)
        {
            DateToFormat = (DateToFormat == null ? "" : DateToFormat.ToString());

            string[] formats = { "yyyy-mm-dd", "dd MMM yyyy", "M/d/yyyy", "M/dd/yyyy", "MM/dd/yyyy", "MM/d/yyyy", "yyyymmdd", "yyyymdd", "yyyymmd", "MM/dd/yyyy hh:mm:ss tt", "MM/d/yyyy hh:mm:ss tt", "M/d/yyyy hh:mm:ss tt", "M/dd/yyyy hh:mm:ss tt", "MM/dd/yyyy hh:mm:ss", "MM/d/yyyy hh:mm:ss", "M/d/yyyy hh:mm:ss", "M/dd/yyyy hh:mm:ss", "MM/dd/yyyy hh:mm", "MM/d/yyyy hh:mm", "M/d/yyyy hh:mm", "M/dd/yyyy hh:mm" };

            DateTime dateValue;
            if (DateTime.TryParseExact(DateToFormat, formats, new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out dateValue))
            {

                return Convert.ToDateTime(DateToFormat, new System.Globalization.CultureInfo("en-US")).ToString("dd MMMM hh:ss");
            }

            return DateToFormat;

        }

      


    }



}

      

       