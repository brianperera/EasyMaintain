using System.Web;
using System.Web.Optimization;

namespace EasyMaintain.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/metro").Include(
                        "~/Scripts/metro.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                        "~/Scripts/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/customTiles").Include(
                        "~/Scripts/customTiles.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTable").Include(
                        "~/Scripts/jquery.dataTables.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/metro.css",
                      "~/Content/metro-icons.css",
                      "~/Content/metro-responsive.css",
                      "~/Content/custom.css"));
        }
    }
}
