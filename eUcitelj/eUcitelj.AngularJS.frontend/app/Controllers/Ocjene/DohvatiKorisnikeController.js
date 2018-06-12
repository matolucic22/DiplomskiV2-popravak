app.controller('DohvatiKorisnikeController', function ($scope, $http, $stateParams, $window, korisnikService, KONSTANTE, predmetiService) {

    id = $stateParams.KoId;
   
    predmetiService.getAll().then(function (response) { 
        $scope.korisnikP = response.data;
        }, function () {
            $window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
        });
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    };
});

app.factory('IDKOR', function () {
        return { id:id };
    });