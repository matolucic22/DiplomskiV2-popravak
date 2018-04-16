app.controller('PregledOcjenaUcenikPredmetiController', function ($scope, $stateParams, $http, $window, $location) {//unos ocjena uceniku
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

    //DOHVAĆANJE OCJENA//
    $http.get('api/predmeti?id='+id)
        .then(function (response) {
            $scope.Predmet = response.data;
            $scope.Ocjene = $scope.Predmet.Ocjene;

        }, function () {
            console.log("Greška prilikom prikazivanja ocjene.");
        });
});