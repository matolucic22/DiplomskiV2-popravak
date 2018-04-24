app.controller('PopraviKvizController', function ($scope, $http, $stateParams, $location, $window, kvizService, KONSTANTE) {

    var kvizPromjenjeno;
    var id = $stateParams.KvizId;
    var kvizovi = [];
    kvizService.get(id).then(function (response) {
            $scope.k = response.data;
        }, function () {
            alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
        });

    $scope.update = function () {
        var id = $stateParams.KvizId;
      // if ($scope.Pitanje != null && $scope.Odg1 != null && $scope.Odg2 != null && $scope.Odg3 != null && $scope.Tocan_odgovor != null) {
                  
        kvizService.getAll().then(function (response) {
                kvizovi = response.data;

                for (i = 0; i < kvizovi.length; i++) {
                    if (kvizovi[i].Pitanje == $scope.k.Pitanje) {
                        var kviz = {
                            KvizId: kvizovi[i].KvizId,
                            Pitanje: $scope.Pitanje,
                            Odg1: $scope.Odg1,
                            Odg2: $scope.Odg2,
                            Odg3: $scope.Odg3,
                            Tocan_odgovor: $scope.Tocan_odgovor
                        };
                        kvizService.update(kviz).then(function (response) {
                            kvizPromjenjeno = response.data;
                            $window.alert("Promijenjeno");
                        }, function () {
                            $window.alert("Svaka rubrika mora biti popunjena.");
                        });
                    }
                }

            }, function () {
                $window.alert(KONSTANTE.DOHVACANJE_KVIZA_GRESKA);
            });
        
        
    };
});