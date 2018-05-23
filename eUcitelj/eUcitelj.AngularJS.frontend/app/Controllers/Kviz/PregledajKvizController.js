app.controller('PregledajKvizController', function ($scope, $http, $stateParams, $window, predmetiService, kvizService, KONSTANTE) {
    id = $stateParams.UcPrId;
    var txtPitanje;
    
    predmetiService.get(id).then(function (response) {
        $scope.predmet = response.data;
        $scope.kviz = $scope.predmet.Kviz;

    }, function (jqXHR) {
        $window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
        });

    //brisanje
    $scope.obrisi = function (id2) {

        kvizService.delete(id2).then(function (response) {
            $window.alert(KONSTANTE.OBJ_UKLONJEN);
        }, function () {
            $window.alert(KONSTANTE.BRISANJE_GRESKA);
        });
    }; 
});
