using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Biletix.UI.App_Start
{
    public class BundleConfig
    {
        public static void BundlesOlustur(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new StyleBundle("~/osman").Include("~/Areas/Admin/Content/bower_components/bootstrap/dist/css/bootstrap.min.css", "~/Areas/Admin/Content/bower_components/metisMenu/dist/metisMenu.min.css", "~/Areas/Admin/Content/dist/css/sb-admin-2.css", "~/Areas/Admin/Content/bower_components/font-awesome/css/font-awesome.min.css", "~/Content/css/fontawesome.css", "~/Content/css/popup.css", "~/Content/css/style.css", "~/Content/css/responsive-0.css", "~/Content/css/responsive-768.css", "~/Content/css/responsive-992.css", "~/Content/css/responsive-1200.css", "~/Content/css/normalize.css", "~/Content/css/owlslider.css", "~/Content/demo/main-color/blue.css", "~/Content/css/demo.css", "~/Content/css/typography.css"));

            bundles.Add(new ScriptBundle("~/ali").Include("~/Areas/Admin/Content/bower_components/jquery/dist/jquery.min.js", "~/Areas/Admin/Content/bower_components/bootstrap/dist/js/bootstrap.min.js", "~/Areas/Admin/Content/bower_components/metisMenu/dist/metisMenu.min.js", "~/Areas/Admin/Content/dist/js/sb-admin-2.js", "~/Content/js/jquery.min.js", "~/Content/js/jquery.magnific.popup.min.js", "~/Content/js/jquery.init.js", "~/Content/js/jquery.ui.min.js", "~/Content/js/jquery.fitvids.js", "~/Content/js/jquery.owlcarousel.min.js", "~/Content/js/jquery.parallax.min.js", "~/Content/js/jquery.smooth.scroll.js", "~/Content/js/jquery.demo.js"));
        }
    }
}