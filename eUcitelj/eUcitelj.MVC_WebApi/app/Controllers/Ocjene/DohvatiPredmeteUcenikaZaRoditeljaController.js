app.controller('DohvatiPredmeteUcenikaZaRoditeljaController', function ($scope, $http, $stateParams, $window) {

    var ucenici = []; 
    var korisnici = [];

    id = angular.fromJson($window.localStorage['ngStorage-currentUser']).KorisnikId;//ucitelj kad pregledava ocijene mora vidjeti sve-zato odvajanje
    $http.get('api/Korisnik/getK?Id='+id)
        .then(function (response) {
            korisnici = response.data;
            $scope.ucenici = korisnici.Ucenici;
        }, function () {
            console.log("Greška prilikom dohvaćanja učenika");
        });
});