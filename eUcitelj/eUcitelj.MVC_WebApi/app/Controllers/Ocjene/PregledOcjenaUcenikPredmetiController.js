app.controller('PregledOcjenaUcenikPredmetiController', function ($scope, $stateParams, $http, $window, $location) {//unos ocjena uceniku
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

    //DOHVAĆANJE OCJENA//
    $http.get('api/Predmeti/getP?id='+id)
        .then(function (response) {
            $scope.Predmet = response.data;
            $scope.Ocjene = $scope.Predmet.Ocjene;

        }, function () {
            console.log("Greška prilikom prikazivanja ocjene.");
        });
});