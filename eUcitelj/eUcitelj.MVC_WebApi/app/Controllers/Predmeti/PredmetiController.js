app.controller("PredmetiController", function ($window, $scope, $http, predmetiService, KONSTANTE, $rootScope, $state) {
    //$scope.predmeti = [];
    //predmetiService.getAll()
    //    .then(function (response) {
    //        $scope.predmeti = response.data;
    //    }, function () {
    //        $window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
    //    });
    //$scope.sort = function (keyname) {
    //    $scope.sortKey = keyname;
    //    $scope.reverse = !$scope.reverse;//if true make it false and vice versa
    //};

    //PITANJE(polovicno): "isto tako se prosljeđuje odabrani id na brisanje - u htmlu se može prosljediti u metodi - npr. deletePredmet(resource.id) ukoliko je resource objekt na kojem se nalazi dobiveni item iz baze)"
    //***ODG: Dodavanje imena u metodu umjesto ID-a mi je bio najlakši način riješavanja problema. U bazi mi se nalazi tablica Predmet koja je povezana s tablicom Korisnik preko ID-a(foreign key)
         //na taj način sam dobio u tablici predmeti da mi svaki korisnik ima predmet sa drugačijim ID-om, ali istim imenom. U ovom slučaju proslijedim ime te preko imena dohvatim sve ID-ove od predmeta onda ih kao argument stavljam u delete metodu i obrišem.
    $scope.spfPredmeti = function (redoslijed, trazeniPojam, brStr) {
        predmetiService.spf(redoslijed, trazeniPojam, brStr)
       .then(function (response) {
           $scope.predmeti = response.data;
       }, function () {
           $window.alert("Došlo je progreške prilikom SPF-a.")
       });
    };

    $scope.del=function (ime)
    {
        var i = 0;
        var predmeti = [];
        $rootScope.ime = ime;
        predmetiService.getAll()
             .then(function (response) {
                 predmeti = response.data;
                 for (i = 0; i < predmeti.length; i++)
                 {
                     if (predmeti[i].Ime_predmeta == ime) 
                     {
                         predmetiService.delete(predmeti[i].PredmetId).then(function (data) {
                             $state.go('predmetiIndex');
                         });
                     }
                 }
             }, function () 
             {
                 window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
             });       
        }    
});