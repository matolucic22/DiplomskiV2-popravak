﻿app.controller('PopraviKvizController', function ($scope, $http, $stateParams, $location, $window) {

    var KvizPromjenjeno;
    var id = $stateParams.KvizId;
    var Kvizovi = [];
        $http.get('/api/kviz?Id=' + id).then(function (response) {
            $scope.K = response.data;
        }, function () {
            alert("Greška prilikom dohvaćanja korisnika.");
        });

    $scope.update = function () {
        var id = $stateParams.KvizId;
      // if ($scope.Pitanje != null && $scope.Odg1 != null && $scope.Odg2 != null && $scope.Odg3 != null && $scope.Tocan_odgovor != null) {
                  
            $http.get('api/kviz').then(function (response) {
                Kvizovi = response.data;

                for (i = 0; i < Kvizovi.length; i++) {
                    if (Kvizovi[i].Pitanje == $scope.K.Pitanje) {
                        var Kviz = {
                            KvizId: Kvizovi[i].KvizId,
                            Pitanje: $scope.Pitanje,
                            Odg1: $scope.Odg1,
                            Odg2: $scope.Odg2,
                            Odg3: $scope.Odg3,
                            Tocan_odgovor: $scope.Tocan_odgovor
                        };
                        $http.put('api/kviz', Kviz).then(function (response) {
                            KvizPromjenjeno = response.data;
                            $window.alert("Promijenjeno");
                        }, function () {
                            $window.alert("Svaka rubrika mora biti popunjena.");
                        });
                    }
                }

            }, function () {
                $window.alert("Greška prilikom dohvaćanja korinsika");
            });
        
        
    };
});