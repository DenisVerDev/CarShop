﻿using System.Web;
using System.Web.Optimization;

namespace CarShop
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                        "~/Scripts/layout.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqui").Include(
                        "~/Scripts/jquery-ui.min.js"));


            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/ann").Include(
                "~/Scripts/annscripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/mp").Include(
                "~/Scripts/mainpage.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/layout.css"));

            bundles.Add(new StyleBundle("~/Content/reg").Include(
                      "~/Content/reg.css"));

            bundles.Add(new StyleBundle("~/Content/jqui").Include(
                      "~/Content/jquery-ui.min.css"));
        }
    }
}
