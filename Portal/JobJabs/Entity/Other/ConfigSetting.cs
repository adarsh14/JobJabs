using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web;

namespace JobJabs.Entity
{
    public class ConfigSetting
    {
        public static string ImagePath { get { return ConfigurationManager.AppSettings["ImagePath"] == null ? String.Empty : Convert.ToString(ConfigurationManager.AppSettings["ImagePath"]); } }
        public static string JPFileServerPath {
            get {
                return ConfigurationManager.AppSettings["JPFilePath"] == null ? String.Empty :
               HttpContext.Current.Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["JPFilePath"]));
            }
        }
        public static string JPFilePath { get { return ConfigurationManager.AppSettings["JPFilePath"] == null ? String.Empty : Convert.ToString(ConfigurationManager.AppSettings["JPFilePath"]); } }

        public static string ResumeFileServerPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ResumeFilePath"] == null ? String.Empty :
               HttpContext.Current.Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["ResumeFilePath"]));
            }
        }
        public static string ResumeFilePath { get { return ConfigurationManager.AppSettings["ResumeFilePath"] == null ? String.Empty : Convert.ToString(ConfigurationManager.AppSettings["ResumeFilePath"]); } }

    }
}
