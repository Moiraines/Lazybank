﻿namespace Lazybank.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
            BundleTable.EnableOptimizations = false;
            bundles.IgnoreList.Clear();
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include("~/Scripts/KendoUI/kendo.all.min.js", "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/js-kendo-listview").Include("~/Scripts/Kendo/kendo.listview.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/js-kendo-datetimepicker").Include("~/Scripts/Kendo/kendo.datetimepicker.min.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/kendo").Include("~/Content/KendoUI/kendo.common-material.min.css", "~/Content/KendoUI/kendo.material.min.css"));
        }
    }
}
