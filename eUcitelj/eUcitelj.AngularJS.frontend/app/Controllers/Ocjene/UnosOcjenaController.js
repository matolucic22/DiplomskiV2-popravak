app.controller('UnosOcjenaController', function ($scope, $http, $window, korisnikService, KONSTANTE) {
    $scope.korisnici = [];
    korisnikService.getAll().then(function (response) {
        $scope.korisnici = response.data;

    }, function () {
        $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
    });

});