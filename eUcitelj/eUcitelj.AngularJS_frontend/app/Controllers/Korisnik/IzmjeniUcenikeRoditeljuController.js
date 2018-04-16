app.controller('IzmjeniUcenikeRoditeljuController', function ($scope, $stateParams, $http, $window, $location) {
    id = $stateParams.KorId;
    var korisnici = [];

    $http.get('api/korisnik?id=' + id)
        .then(function (response) {
            korisnik = response.data;
            $scope.Ucenici = korisnik.Ucenici;
       }, function () {
           console.log("Nemoguće dohvatiti korsnika pod tim ID-om.");
       });

    $scope.DeleteK = function (UceniciId) {

        $http.delete('/api/ucenici?Id=' + UceniciId).then(function (response) {
            $window.alert("Korisnik uklonjen.");
            $http.get('api/korisnik/get?id=' + id)
               .then(function (response) {
                   korisnici = response.data;
                   $scope.Ucenici = korisnici.Ucenici;
               }, function () {
                   console.log("Nemoguće dohvatiti korsnika pod tim ID-om.");
               });
        }, function () {

            alert("Greška prilikom uklanjanja iz baze");

        });
    };


});