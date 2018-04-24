using System.Web;
using System.Web.Optimization;

namespace eUcitelj.MVC_WebApi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/angular-local-storage.js",
                "~/app/js/md5.js",
                "~/app/js/ngStorage.js",
                "~/app/js/unique.js",
                "~/Scripts/dirPagination.js"));

            bundles.Add(new ScriptBundle("~/bundles/aplikacija").Include(
              "~/app/app.js",
              "~/app/Controllers/konstante.js",
              "~/app/Controllers/Predmeti/*Controller.js",
              "~/app/Controllers/Korisnik/*Controller.js",
              "~/app/Controllers/Ocjene/*Controller.js",
              "~/app/Controllers/Kviz/*Controller.js",
              "~/app/Controllers/*Controller.js",
              "~/app/Services/*Service.js"
              ));



            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/DropDownMenu.css"));
        }
    }
}
