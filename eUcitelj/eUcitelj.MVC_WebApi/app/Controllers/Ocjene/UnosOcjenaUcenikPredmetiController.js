app.controller('UnosOcjenaUcenikPredmetiController', function ($scope, $stateParams, $http, $window, $location) {//unos ocjena uceniku
    id = $stateParams.UcPrId;

    //PRIKAZ IMENA KORISNIKA//
    $http.get('api/Predmeti/getP?id=' + id)
        .then(function (response) {
            predmeti = response.data;

            id2 = predmeti.KorisnikId;

            $http.get('api/Korisnik/getK?id=' + id2)
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
        if ($scope.Ocjena > 0 && $scope.Ocjena < 6) {
            var addO = {
                Ocjena: $scope.Ocjena,
                Opis: $scope.Opis,
                DatumOcjene: $scope.DatumOcjene,
                PredmetiId: id
            };

            $http.post('api/Ocjene/addO', addO)
               .then(function (data) {
                   $scope.response = data;
                   $window.alert("Ocjena dodana");
                   $location.path('/ocjene/ocjeneUnos');
               }, function () {
                   console.log("Greška prilikom upisivanja ocjene.");
               });
        }else
        {
            $window.alert("Unjeli ste krivu ocjenu. Ponovite unos.");
        }
    };
});