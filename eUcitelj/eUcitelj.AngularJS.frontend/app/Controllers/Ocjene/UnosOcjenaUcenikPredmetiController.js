app.controller('UnosOcjenaUcenikPredmetiController', function ($scope, $stateParams, $http, $window, $location, $state, predmetiService, korisnikService, ocjeneService, KONSTANTE, IDKOR) {//unos ocjena uceniku
    id = $stateParams.UcPrId;
    idKorisnik = IDKOR.id;

    //PRIKAZ IMENA KORISNIKA//-da se zna koji je korisnik u pitanju

       korisnikService.get(idKorisnik).then(function (response) {
        $scope.trKorisnik = response.data;
           
       }, function () {
           $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
       });

    //DODAVANJE OCJENE U BAZU//
    $scope.upisi = function () {
        if ($scope.Ocj > 0 && $scope.Ocj < 6) {
            var addO = {
                Ocj: $scope.ocj,
                Opis: $scope.opis,
                DatumOcjene: $scope.datumOcjene,
                PredmetId: id,
                KorisnikId: idKorisnik
            };

            ocjeneService.add(addO).then(function (data) {
                   $scope.response = data;
                   $window.alert("Ocjena dodana");
                   $state.go('unosOcjena');
            }).catch(function (response) {
                for (var key in response.data.ModelState)
                {
                    alert(response.data.ModelState[key][0]);
                }
            });
        }else
        {
            $window.alert("Unjeli ste krivu ocjenu. Ponovite unos.");
        }
    };
});