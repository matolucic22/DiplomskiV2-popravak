app.controller('DohvatiPredmeteUcenikaZaRoditeljaController', function ($scope, $http, $stateParams, $window) {

    var ucenici = []; 
    var korisnici = [];

    id = angular.fromJson($window.localStorage['ngStorage-currentUser']).KorisnikId;//ucitelj kad pregledava ocijene mora vidjeti sve-zato odvajanje
    $http.get('api/Korisnik?Id='+id)
        .then(function (response) {
            korisnik = response.data;
            $scope.ucenici = korisnik.Ucenici;
        }, function () {
            console.log("Greška prilikom dohvaćanja učenika");
        });
});