app.controller('UnosOcjenaController', function ($scope, $http) {
    $scope.korisnici = [];
    $http.get('/api/Korisnik/getAllK').then(function (response) {
        $scope.korisnici = response.data;

    }, function () {
        console.log("Greška prilikom preuzimanja korisnika iz baze.");
    });

});