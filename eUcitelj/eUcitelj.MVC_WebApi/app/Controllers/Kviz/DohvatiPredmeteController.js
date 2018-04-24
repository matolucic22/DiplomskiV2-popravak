app.controller('DohvatiPredmeteController', function ($scope, $http, $stateParams, korisnikService, KONSTANTE) {
    var korisnikIdovi = {
        KorisnikId:undefined
    };
    $scope.korisnik = [];

    korisnikService.getAllKorisnikId().then(function (response) {
        korisnikIdovi = response.data;
        id = korisnikIdovi[0].KorisnikId
        korisnikService.get(id)
    .then(function (response) {
        $scope.korisnik = response.data;
        $scope.predmeti = $scope.korisnik.Predmeti;
    }
        , function (jqXHR) {
            window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
        });
    });

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;//if true make it false and vice versa
    };
});