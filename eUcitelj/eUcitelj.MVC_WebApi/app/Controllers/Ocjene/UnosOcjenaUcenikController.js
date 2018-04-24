app.controller('UnosOcjenaUcenikController', function ($scope, $http, $stateParams, $window, korisnikService, KONSTANTE) {
    $scope.korisnikP = [];
    id = $stateParams.KoId;
    korisnikService.get(id).then(function (response) {
            korisnik = response.data;
            $scope.korisnikP = korisnik.Predmeti;
        }, function () {
            $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
        });
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    };
});