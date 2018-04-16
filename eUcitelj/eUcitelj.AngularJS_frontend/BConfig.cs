using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace eUcitelj.AngularJS_frontend
{
    public class BConfig
    {
        public static void RegisterB(BundleCollection b)
        {
            //b.Add(new ScriptBundle("~/bundles/angularjs").Include(
            //    "~/Scripts/angular.js",
            //    "~/Scripts/angular-ui-router.js",
            //    "~/Scripts/angular-local-storage.js",
            //    "~/app/js/md5.js",
            //    "~/app/js/ngStorage.js",
            //    "~/app/js/unique.js",
            //    "~/Scripts/dirPagination.js"));

            //b.Add(new ScriptBundle("~/bundles/aplikacija").Include(
            //  "~/app/app.js",
            //  "~/app/Controllers/Predmeti/*Controller.js",
            //  "~/app/Controllers/Korisnik/*Controller.js",
            //  "~/app/Controllers/Ocjene/*Controller.js",
            //  "~/app/Controllers/Kviz/*Controller.js",
            //  "~/app/Controllers/*Controller.js",
            //  "~/app/Services/*Service.js"
            //  ));

            // b.Add(new ScriptBundle("~/bundles/aplikacija").IncludeDirectory("~/app", "*.js"));
        }
    }
}
