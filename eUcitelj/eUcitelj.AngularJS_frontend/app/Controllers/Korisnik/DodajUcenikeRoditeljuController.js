app.controller('DodajUcenikeRoditeljuController', function ($scope, $http, $stateParams, $window, $location, $rootScope) {
  
    $http.get('/api/korisnik').then(function (response) {

        $scope.korisnici = response.data;

    }, function () {
        console.log("Greška prilikom preuzimanja korisnika iz baze.");
    });


    $scope.Snimi = function () {
        var check = document.getElementsByClassName('check');
        var Ids = [];
        var obj = [];
        var a = 0;
        var Ucenik = [];
        for (var i = 0; i < check.length; i++) {
            if (check[i].checked) {
                Ids[a] = check[i].value;
                a++;
            }
        }

        for (i = 0; i < Ids.length; i++)
        {
            $http.get('/api/korisnik?Id=' + Ids[i]).then(function (response) {
                Ucenik = response.data;

                obj[i] = {
                    KorisnikId: $rootScope.KorisnikId,
                    Ime_korisnika: Ucenik.Ime_korisnika,
                    Prezime_korisnika: Ucenik.Prezime_korisnika,
                    IdKorisnikaU: Ucenik.KorisnikId
                };

                $http.post('api/ucenici', obj[i]).then(function (response) {
                    $scope.response = response.data;

                }, function () {
                    $window.alert("Greška prilikom unosa u bazu.");
                });


            }, function () {
                alert("Greška prilikom dohvaćanja korisnika.");
            });

            
        } 
        var button = document.getElementById("button");
        button.parentNode.removeChild(button);
    };

});