using System.Web;
using System.Web.Optimization;

namespace JobJabs
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assets/ERP/Scripts/Vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Assets/ERP/Scripts/Vendor/jquery.validate*",
                         "~/Assets/ERP/Scripts/Vendor/jquery.validate.unobtrusive.js"
                        ));
        }
    }
}
