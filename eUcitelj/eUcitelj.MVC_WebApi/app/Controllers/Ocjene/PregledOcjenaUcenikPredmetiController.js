app.controller('PregledOcjenaUcenikPredmetiController', function ($scope, $stateParams, $http, $window, $location, predmetiService, korisnikService, KONSTANTE) {//unos ocjena uceniku
    id = $stateParams.UcPrId;
    //PRIKAZ IMENA KORISNIKA//
    predmetiService.get(id).then(function (response) {
            predmet = response.data;

            id2 = predmet.KorisnikId;

            korisnikService.get(id2).then(function (response) {
           $scope.trKorisnik = response.data;

       }, function () {
           $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
       });

        }, function () {
            $window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
        });

    //DOHVAĆANJE OCJENA//
    predmetiService.get(id).then(function (response) {
            $scope.predmet = response.data;
            $scope.ocjene = $scope.predmet.Ocjene;

        }, function () {
            $window.alert(KONSTANTE.DOHVACANJE_OCJENE_GRESKA);
        });
});