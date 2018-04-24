app.controller('ObrisiKvizController', function ($scope, $http, $stateParams, $location, $window, kvizService, KONSTANTE) {

    var kvizPromjenjeno;
    var id = $stateParams.KvizId;
    kvizService.get(id).then(function (response) {
        $scope.kPitanje = response.data;
        txtPitanje = $scope.kPitanje.Pitanje;
    }, function () {
        $window.alert(KONSTANTE.DOHVACANJE_KVIZA_GRESKA);
    });

    kvizService.getAll().then(function (response) {
        kvizovi = response.data;

        for (i = 0; i < kvizovi.length; i++) {
            if (kvizovi[i].Pitanje == txtPitanje) {
                kvizService.delete(kvizovi[i].KvizId).then(function (response) {
                    kvizPromjenjeno = response.data;
                }, function () {
                    $window.alert("Greška prilikom promjene");
                });
            }
        }
    }, function () {
        $window.alert(KONSTANTE.DOHVACANJE_KVIZA_GRESKA);
    });
});




   