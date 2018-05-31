app.controller('IzmjeniUcenikeRoditeljuController', function ($scope, $stateParams, $http, $window, $location, korisnikService, KONSTANTE) {
    id = $stateParams.KorId;
    var korisnici = [];
    
    korisnikService.get(id)
        .then(function (response) {
            korisnik = response.data;
            $scope.ucenici = korisnik.Ucenici;
           
       }, function () {
           $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
       });

    $scope.DeleteK = function (KorisnikId) {

        $http.delete('/api/ucenici?Id=' + KorisnikId).then(function (response) {
            $window.alert(KONSTANTE.OBJ_UKLONJEN);
            korisnikService.get(id)
               .then(function (response) {
                   korisnik2 = response.data;
                   $scope.ucenici = korisnik2.Ucenici;
               }, function () {
                   $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
               });
        }, function () {

            $window.alert(KONSTANTE.UKLANJANJE_KOR_GRESKA);

        });
    };


});