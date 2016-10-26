﻿using System.Web;
using System.Web.Optimization;

namespace DrugsSystem.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            // uncomment in production may be
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryGrid").Include(
                      "~/Scripts/i18n/grid.locale-ru.js").Include(
                      "~/Scripts/jquery.jqGrid.js"));

            bundles.Add(new ScriptBundle("~/bundles/handlebars").Include(
                      "~/Scripts/handlebars.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/content/jquery.jqGrid/ui.jqgrid.css",
                      "~/content/themes/base/jquery-ui.css"));
        }
    }
}
