app.controller('BrisanjeOcjenaUcenikPredmetiController', function ($scope, $stateParams, $http, $window, $location, predmetiService, korisnikService, ocjeneService, KONSTANTE) {//unos ocjena uceniku
    id = $stateParams.UcPrId;

    //PRIKAZ IMENA KORISNIKA//
    predmetiService.get(id).then(function (response) {
            $scope.predmet = response.data;
            $scope.ocjene = $scope.predmet.Ocjene;
            id2 = $scope.predmet.KorisnikId;

            korisnikService.get(id2).then(function (response) {
               $scope.trKorisnik = response.data;

           }, function () {
               $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
           });

        }, function () {
            $window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
        });

    $scope.obrisi = function (OcjeneId) {
        ocjeneService.delete(OcjeneId).then(function (data) {
            $window.alert("Obrisano");
            predmetiService.get(id).then(function (response) {
                           $scope.predmet = response.data;
                           $scope.ocjene = $scope.predmet.Ocjene;
                       }, function () {
                           $window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
                       });
               }, function () {
                   $window.alert(KONSTANTE.BRISANJE_GRESKA);
               });
    };

});