﻿using System.Web.Optimization;

namespace AdminView
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/jquery.dateFormat-1.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/canvas").Include(
                      "~/Scripts/canvas/canvasjs.min.js",
                      "~/Scripts/canvas/jquery.canvasjs.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sbadmin").Include(
                      "~/Scripts/sb-admin-2.js"));

            bundles.Add(new ScriptBundle("~/bundles/metismenu").Include(
                      "~/Scripts/metisMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/users").Include(
                      "~/Scripts/functions/functions.js"));

            bundles.Add(new ScriptBundle("~/bundles/edituser").Include(
                      "~/Scripts/functions/functions_edituser.js"));

            bundles.Add(new ScriptBundle("~/bundles/database").Include(
                      "~/Scripts/bootstrap-select.min.js",
                      "~/Scripts/bootstrap-toggle.min.js",
                      "~/Scripts/functions/functions_database.js"));

            bundles.Add(new ScriptBundle("~/bundles/posts").Include(
                      "~/Scripts/functions/functions_posts.js",
                      "~/Scripts/jquery/jquery.tablesorter.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-toggle.css",
                      "~/Content/bootstrap-select.css",
                      "~/Content/bootstrap.css",
                      "~/Content/sb-admin-2.css",
                      "~/Content/metisMenu.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/stats").Include(
                      "~/Content/stats.css"));

            bundles.Add(new ScriptBundle("~/bundles/stats").Include(
                "~/Scripts/functions/stats.js"));
        }
    }
}
