﻿app.controller('PregledajKvizController', function ($scope, $http, $stateParams, $window) {
    id = $stateParams.UcPrId;
    
    $http.get('/api/Predmeti/getP?id=' + id).then(function (response) {
        $scope.Predmeti = response.data;
        $scope.Kviz = $scope.Predmeti.Kviz;

    }, function (jqXHR) {
            $window.alert("Greška prilikom dohvaćanja predmeta.");
        });

    //brisanje
    $scope.Obrisi = function (id2) {
        var KvizPromjenjeno;
        $http.get('/api/Kviz/getK?Id=' + id2).then(function (response) {
            $scope.kPitanje = response.data;
            txtPitanje = $scope.kPitanje.Pitanje;
        }, function () {
            alert("Greška prilikom dohvaćanja korisnika.");
        });


        $http.get('/api/Kviz/getAllK').then(function (response) {
            Kvizovi = response.data;

            for (i = 0; i < Kvizovi.length; i++) {
                if (Kvizovi[i].Pitanje == txtPitanje) {
                    $http.delete('api/Kviz/deleteK?id=' + Kvizovi[i].KvizId).then(function (response) {
                        KvizPromjenjeno = response.data;
                        $http.get('/api/Predmeti/getP?id=' + id).then(function (response) {
                            $scope.Predmeti = response.data;
                            $scope.Kviz = $scope.Predmeti.Kviz;

                        }, function (jqXHR) {
                            $window.alert("Greška prilikom dohvaćanja predmeta.");
                        });
                    }, function () {
                        $window.alert("Greška prilikom promjene");
                    });
                }
            }
        }, function () {
            alert("Greška prilikom dohvaćanja korisnika.");
        });
    }; 
});
