app.controller('DohvatiPredmeteController', function ($scope, $window, $http, $stateParams, predmetiService, KONSTANTE) {

    predmetiService.getAll().then(function (response) {
        $scope.predmeti = response.data;
    }, function () {
        $window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
    });
});