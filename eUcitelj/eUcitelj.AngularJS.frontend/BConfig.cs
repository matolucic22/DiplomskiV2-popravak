using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace eUcitelj.AngularJS.frontend
{
    public class BConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-1.10.2.intellisense.js",
                        "~/Scripts/jquery-1.10.2.js",
                        "~/Scripts/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate-vsdoc.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/angular-local-storage.js",
                "~/app/js/md5.js",
                "~/app/js/ngStorage.js",
                "~/app/js/unique.js",
                "~/Scripts/dirPagination.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/aplikacija").Include(
              "~/app/app.js",
              "~/app/Controllers/konstante.js",
              "~/app/Controllers/Predmeti/AddPredmetiController.js",
              "~/app/Controllers/Predmeti/EditPredmetiController.js",
              "~/app/Controllers/Predmeti/PredmetiController.js",
              "~/app/Controllers/Korisnik/DodajUcenikeRoditeljuController.js",
              "~/app/Controllers/Korisnik/HomeController.js",
              "~/app/Controllers/Korisnik/IzmjeniUcenikeRoditeljuController.js",
              "~/app/Controllers/Korisnik/LoginController.js",
              "~/app/Controllers/Korisnik/PotvrdaKorisnikaController.js",
              "~/app/Controllers/Korisnik/RegisterController.js",
              "~/app/Controllers/Kviz/DodajKvizController.js",
              "~/app/Controllers/Kviz/DohvatiPredmeteController.js",
              "~/app/Controllers/Kviz/ObrisiKvizController.js",
              "~/app/Controllers/Kviz/PopraviKvizController.js",
              "~/app/Controllers/Kviz/PregledajKvizController.js",
              "~/app/Controllers/Kviz/RjesavajKvizController.js",
              "~/app/Controllers/Ocjene/BrisanjeOcjeneController.js",
              "~/app/Controllers/Ocjene/DohvatiPredmeteUcenikaZaRoditeljaController.js",
              "~/app/Controllers/Ocjene/DohvatiPredmeteController.js",
              "~/app/Controllers/Ocjene/PregledOcjenaUcenikPredmetiController.js",
              "~/app/Controllers/Ocjene/DohvatiKorisnikeController.js",
              "~/app/Controllers/Ocjene/UnosOcjenaUcenikController.js",
              "~/app/Controllers/Ocjene/UnosOcjenaUcenikPredmetiController.js",
              "~/app/Controllers/NavbarController.js",
              "~/app/Services/AuthenticationService.js",
              "~/app/Services/korisnikService.js",
              "~/app/Services/kvizService.js",
              "~/app/Services/ocjeneService.js",
              "~/app/Services/predmetiService.js",
              "~/app/Services/predmetKorisnikService.js"
              ));



            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.6.2.js"));

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