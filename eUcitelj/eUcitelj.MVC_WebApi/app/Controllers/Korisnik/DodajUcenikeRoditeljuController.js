app.controller('DodajUcenikeRoditeljuController', function ($scope, $http, $stateParams, $window, $location, $rootScope, korisnikService, KONSTANTE) {
  
    korisnikService.getAllUcenik().then(function (response) {

        $scope.korisnici = response.data;
    }, function () {
        $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
    });

    


    $scope.snimi = function () {
        var check = document.getElementsByClassName('check');
        var ids = [];
        var obj = [];
        var a = 0;
        var ucenik = [];
        for (var i = 0; i < check.length; i++) {
            if (check[i].checked) {
                ids[a] = check[i].value;
                a++;
            }
        }

        for (i = 0; i < ids.length; i++)
        {
            korisnikService.get(ids[i]).then(function (response) {
                ucenik = response.data;

                obj[i] = {
                    KorisnikId: $rootScope.KorisnikId,
                    IdKorisnikaU: ucenik.Id
                };

                $http.post('api/ucenici', obj[i]).then(function (response) {
                    $scope.response = response.data;

                }, function () {
                    $window.alert(KONSTANTE.UNOS_U_BAZU_GRESKA);
                });


            }, function () {
                $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
            });

            
        } 
        var button = document.getElementById("button");
        button.parentNode.removeChild(button);
    };

});