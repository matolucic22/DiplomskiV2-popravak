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
        var kvizPromjenjeno;
        kvizService.delete(id2).then(function (response) {
            $scope.kPitanje = response.data;
            txtPitanje = $scope.kPitanje.Pitanje;
        }, function () {
            $window.alert(KONSTANTE.BRISANJE_GRESKA);
        });

        kvizService.getAll().then(function (response) {
            kvizovi = response.data;

            for (i = 0; i < kvizovi.length; i++) {
                if (kvizovi[i].Pitanje == txtPitanje) {
                    kvizService.delete(kvizovi[i].KvizId).then(function (response) {
                        kvizPromjenjeno = response.data;
                        predmetiService.get(id).then(function (response) {
                            $scope.predmet = response.data;
                            $scope.kviz = $scope.predmet.Kviz;

                        }, function (jqXHR) {
                            $window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
                        });
                    }, function () {
                        $window.alert(KONSTANTE.BRISANJE_GRESKA);
                    });
                }
            }
        }, function () {
            alert(KONSTANTE.DOHVACANJE_KVIZA_GRESKA);
        });
    }; 
});
