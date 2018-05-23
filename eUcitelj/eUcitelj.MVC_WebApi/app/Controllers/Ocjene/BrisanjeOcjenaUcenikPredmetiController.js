﻿app.controller('BrisanjeOcjenaUcenikPredmetiController', function ($scope, $stateParams, $http, $window, $location, predmetiService, korisnikService, ocjeneService, KONSTANTE, IDKOR) {//unos ocjena uceniku
    id = $stateParams.UcPrId;
    idKorisnik = IDKOR.Id;
    var oc = [];

    //PRIKAZ IMENA KORISNIKA//-da se zna koji je korisnik u pitanju

    korisnikService.get(idKorisnik).then(function (response) {
        $scope.trKorisnik = response.data;

    }, function () {
        $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
    });

    ocjeneService.getByKorisnikIdAsync(idKorisnik).then(function (respose) {

        ocjeneK = respose.data;

        for (i = 0; i < ocjeneK.length; i++) {
            if (ocjeneK[i].PredmetId == id) {
                oc[i] = ocjeneK[i];
            }
        }

        $scope.ocjene = oc;

    }, function () {
        $window.alert(KONSTANTE.DOHVACANJE_OCJENE_GRESKA);
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