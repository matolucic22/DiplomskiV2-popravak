app.controller('ObrisiKvizController', function ($scope, $http, $stateParams, $location, $window) {

    var KvizPromjenjeno;
    var id = $stateParams.KvizId;
    $http.get('/api/kviz?Id=' + id).then(function (response) {
        $scope.kPitanje = response.data;
        txtPitanje = $scope.kPitanje.Pitanje;
    }, function () {
        alert("Greška prilikom dohvaćanja korisnika.");
    });


    $http.get('/api/kviz').then(function (response) {
        Kvizovi = response.data;

        for (i = 0; i < Kvizovi.length; i++) {
            if (Kvizovi[i].Pitanje == txtPitanje) {
                $http.delete('api/kviz?id=' + Kvizovi[i].KvizId).then(function (response) {
                    KvizPromjenjeno = response.data;
                }, function () {
                    $window.alert("Greška prilikom promjene");
                });
            }
        }
    }, function () {
        alert("Greška prilikom dohvaćanja korisnika.");
    });
});




   