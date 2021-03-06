﻿using System.Web;
using System.Web.Optimization;

namespace AllTrustUs.giftcard
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/Common.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                       "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/kendoUI/css").Include(
                      "~/Content/JQueryControl/kendoUI/styles/kendo.common.min.css",
                      "~/Content/JQueryControl/kendoUI/CustomizeTheme/Silver/kendo.custom.css"));
            bundles.Add(new ScriptBundle("~/Content/kendoUI").Include(
                      "~/Content/JQueryControl/kendoUI/js/kendo.all.min.js",
                      "~/Content/JQueryControl/kendoUI/js/jszip.min.js"));


            bundles.Add(new ScriptBundle("~/Content/layer").Include(
                      "~/Content/layer/layer.js"));
            bundles.Add(new StyleBundle("~/Content/layer/css").Include(
                      "~/Content/layer/skin/layer.css"));

            bundles.Add(new ScriptBundle("~/Content/jquery-validation").Include(
                      "~/Content/jquery-validation/jquery.validate.min.js"));
        }
    }
}
