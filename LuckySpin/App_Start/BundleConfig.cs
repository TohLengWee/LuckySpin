using System.Web;
using System.Web.Optimization;

namespace LuckySpin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            
            bundles.Add(new StyleBundle("~/css/wheel").Include(
                    "~/Content/wheel/main-DB.css",
                    "~/Content/wheel/reset.css",
                    "~/Content/wheel/style.css"));

            bundles.Add(new ScriptBundle("~/script/wheel").Include(
                    "~/Scripts/wheel/jquery-*",
                    "~/Scripts/wheel/tt-new/*.js",
                    "~/Scripts/wheel/*.js"));
        }
    }
}
