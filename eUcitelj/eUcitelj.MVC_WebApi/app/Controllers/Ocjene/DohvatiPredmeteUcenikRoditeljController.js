app.controller('DohvatiPredmeteUcenikRoditeljController', function ($scope, $http, $stateParams, $window, korisnikService, KONSTANTE) {
    $scope.korisnikP = [];
    id=angular.fromJson($window.localStorage['ngStorage-currentUser']).KorisnikId;//ucitelj kad pregledava ocijene mora vidjeti sve-zato odvajanje
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