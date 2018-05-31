app.controller('DohvatiPredmeteController', function ($scope, predmetiService, $http, $stateParams, $window, korisnikService, KONSTANTE) {
    $scope.korisnikP = [];
    id=angular.fromJson($window.localStorage['ngStorage-currentUser']).KorisnikId;//ucitelj kad pregledava ocijene mora vidjeti sve-zato odvajanje
    predmetiService.getAll().then(function (response) {
        $scope.korisnikP = response.data;
    }, function () {
        $window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
    });
});