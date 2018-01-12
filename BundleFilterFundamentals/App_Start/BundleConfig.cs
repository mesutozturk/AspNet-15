using System.Web.Optimization;

namespace BundleFilterFundamentals.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/themes/base/jquery-ui.css",
                "~/Content/themes/base/all.css",
                "~/Content/site.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-3.2.1.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery-ui-1.12.1.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/moment.js",
                "~/Scripts/moment-with-locales.js",
                "~/Scripts/app.js"
                ));
        }
    }
}