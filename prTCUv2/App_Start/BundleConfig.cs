using System.Web;
using System.Web.Optimization;

namespace prTCUv2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/admin/styles")
            .Include("~/content/styles/bootstrap.css"));

            bundles.Add(new StyleBundle("~/styles")
            .Include("~/content/styles/bootstrap.css")
            .Include("~/content/styles/bootstrap-datetimepicker.css"));
            bundles.Add(new StyleBundle("~/styles_datetimepicker")
            .Include("~/content/styles/bootstrap-datetimepicker.css"));

            bundles.Add(new StyleBundle("~/bundles/AdminTemplates")
            .Include("~/Content/theme.css")
            .Include("~/Content/Admin.css")
            .Include("~/Content/all.min.css"));

            bundles.Add(new StyleBundle("~/siteStyles")
            .Include("~/content/theme.css", "~/content/Admin.css", "~/content/styles/bootstrap.css"));

            bundles.Add(new StyleBundle("~/admin/scripts")
            .Include("~/scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Scripts")
            .Include("~/Scripts/bootstrap-datetimepicker.js")
            .Include("~/scripts/en-ca.js"));

            bundles.Add(new ScriptBundle("~/bootstrapjs")
            .Include("~/Scripts/moment.js")
            .Include("~/Scripts/bootstrap-datetimepicker.js")
            .Include("~/scripts/en-ca.js"));

            bundles.Add(new ScriptBundle("~/bootstrap-dropdown-js").Include("~/Scripts/bootstrap-dropdown-select-ext.js"));

            bundles.Add(new StyleBundle("~/bootstrapcss")
            .Include("~/content/styles/bootstrap-datetimepicker.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/lockr-js").Include("~/Scripts/lockr.min.js"));

            bundles.Add(new StyleBundle("~/jquery")
            .Include("~/Scripts/jquery.validate.min.js")
            .Include("~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Rol-js")
                .Include("~/Scripts/CheckTimeout.js"));

            bundles.Add(new ScriptBundle("~/bundles/Miscellaneous")
                .Include("~/Areas/Admin/Scripts/CommonFunctions.js")
                .Include("~/Scripts/shield-ui-lite.js"));

            bundles.Add(new ScriptBundle("~/bundles/TimeOut-js").Include("~/Scripts/CheckTimeout.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
