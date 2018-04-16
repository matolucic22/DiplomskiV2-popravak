app.controller('UnosOcjenaUcenikPredmetiController', function ($scope, $stateParams, $http, $window, $location) {//unos ocjena uceniku
    id = $stateParams.UcPrId;

    //PRIKAZ IMENA KORISNIKA//
    $http.get('api/predmeti?id=' + id)
        .then(function (response) {
            predmet = response.data;

            id2 = predmet.KorisnikId;

            $http.get('api/korisnik?id=' + id2)
       .then(function (response) {
           $scope.TrKorisnik = response.data;
           
       }, function () {
           console.log("Nemoguće dohvatiti korsnika pod tim ID-om.");
       });

        }, function () {
            console.log("Nemoguće dohvatiti predmet pod tim ID-om.");
        });

    //DODAVANJE OCJENE U BAZU//
    $scope.Upisi = function () {
        if ($scope.Ocj > 0 && $scope.Ocj < 6) {
            var addO = {
                Ocj: $scope.Ocj,
                Opis: $scope.Opis,
                DatumOcjene: $scope.DatumOcjene,
                PredmetId: id
            };

            $http.post('api/ocjene', addO)
               .then(function (data) {
                   $scope.response = data;
                   $window.alert("Ocjena dodana");
                   $location.path('/ocjene/ocjeneUnos');
               }, function () {
                   $window.alert("Greška prilikom upisivanja ocjene.");
               });
        }else
        {
            $window.alert("Unjeli ste krivu ocjenu. Ponovite unos.");
        }
    };
});