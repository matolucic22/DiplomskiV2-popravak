app.controller('DohvatiPredmeteUcenikaZaRoditeljaController', function ($scope, $http, $stateParams, $window, korisnikService, KONSTANTE) {

    var ucenici = []; 
    var korisnici = [];

    id = angular.fromJson($window.localStorage['ngStorage-currentUser']).KorisnikId;//ucitelj kad pregledava ocijene mora vidjeti sve-zato odvajanje
    korisnikService.get(id).then(function (response) {
            korisnik = response.data;
            $scope.ucenici = korisnik.Ucenici;
        }, function () {
            $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
        });
});