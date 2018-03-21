app.controller('IzmjeniUcenikeRoditeljuController', function ($scope, $stateParams, $http, $window, $location) {
    id = $stateParams.KorId;
    var korisnici = [];

    $http.get('api/Korisnik/getK?id=' + id)
        .then(function (response) {
            korisnici = response.data;
            $scope.Ucenici = korisnici.Ucenici;
       }, function () {
           console.log("Nemoguće dohvatiti korsnika pod tim ID-om.");
       });

    $scope.DeleteK = function (UceniciId) {

        $http.delete('/api/Ucenici/deleteU?Id=' + UceniciId).then(function (response) {
            $window.alert("Korisnik uklonjen.");
            $http.get('api/Korisnik/getK?id=' + id)
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