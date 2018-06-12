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
        kvizService.getAll().then(function (response) {
                kvizovi = response.data;

                for (i = 0; i < kvizovi.length; i++) {
                    if (kvizovi[i].Pitanje == $scope.k.Pitanje) {
                        var kviz = {
                            KvizId: kvizovi[i].KvizId,
                            Pitanje: $scope.pitanje,
                            Odg1: $scope.odg1,
                            Odg2: $scope.odg2,
                            Odg3: $scope.odg3,
                            Tocan_odgovor: $scope.tocan_odgovor
                        };
                        kvizService.update(kviz).then(function (response) {
                            kvizPromjenjeno = response.data;
                            $window.alert("Promijenjeno");
                        }).catch(function (response) {
                            for (var key in response.data.ModelState)
                            {
                                alert(response.data.ModelState[key][0]);
                            }
                        });
                    }
                }
            }, function () {
                $window.alert(KONSTANTE.DOHVACANJE_KVIZA_GRESKA);
            });
    };
});