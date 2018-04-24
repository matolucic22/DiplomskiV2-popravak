app.controller('UnosOcjenaUcenikPredmetiController', function ($scope, $stateParams, $http, $window, $location, $state, predmetiService, korisnikService, ocjeneService) {//unos ocjena uceniku
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

    //DODAVANJE OCJENE U BAZU//
    $scope.upisi = function () {
        if ($scope.Ocj > 0 && $scope.Ocj < 6) {
            var addO = {
                Ocj: $scope.Ocj,
                Opis: $scope.Opis,
                DatumOcjene: $scope.DatumOcjene,
                PredmetId: id
            };

            ocjeneService.add(addO).then(function (data) {
                   $scope.response = data;
                   $window.alert("Ocjena dodana");
                   $state.go('unosOcjena');
               }, function () {
                   $window.alert(KONSTANTE.UNOS_U_BAZU_GRESKA);
               });
        }else
        {
            $window.alert("Unjeli ste krivu ocjenu. Ponovite unos.");
        }
    };
});