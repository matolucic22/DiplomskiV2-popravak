app.controller('BrisanjeOcjenaUcenikPredmetiController', function ($scope, $stateParams, $http, $window, $location) {//unos ocjena uceniku
    id = $stateParams.UcPrId;

    //PRIKAZ IMENA KORISNIKA//
    $http.get('api/Predmeti/getP?id=' + id)
        .then(function (response) {
            $scope.predmet = response.data;
            $scope.Ocjene = $scope.predmet.Ocjene;
            id2 = $scope.predmet.KorisnikId;

            $http.get('api/Korisnik/getK?id=' + id2)
       .then(function (response) {
           $scope.TrKorisnik = response.data;

       }, function () {
           console.log("Nemoguće dohvatiti korsnika pod tim ID-om.");
       });

        }, function () {
            console.log("Nemoguće dohvatiti predmet pod tim ID-om.");
        });

    $scope.Obrisi = function (OcjeneId) {
        $http.delete('api/Ocjene/deleteO?id=' + OcjeneId)
               .then(function (data) {
                   $window.alert("Obrisano");
                   $http.get('api/Predmeti/getP?id=' + id)
                       .then(function (response) {
                           $scope.predmet = response.data;
                           $scope.Ocjene = $scope.predmet.Ocjene;
                       }, function () {
                           console.log("Nemoguće dohvatiti korsnika pod tim ID-om.");
                       });
               }, function () {
                   console.log("Greška prilikom brisanja ocjene.");
               });
    };

});