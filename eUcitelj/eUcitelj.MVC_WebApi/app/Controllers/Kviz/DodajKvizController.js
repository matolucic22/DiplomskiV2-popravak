app.controller('DodajKvizController', function ($scope, $http, $stateParams, $location, $window, predmetiService, kvizService, KONSTANTE) {

    id = $stateParams.UcPrId;
    
    predmeti = [];

    //dohvati ime predmeta 
    predmetiService.get(id).then(function (response) {
        $scope.predmet = response.data;
        imePredmeta=$scope.predmet.Ime_predmeta;
    }
        , function (jqXHR) {
            $window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
        });

    //dohvati sve predmete
    predmetiService.getAll().then(function (response) {
        predmeti = response.data;
    }
        , function (jqXHR) {
            $window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
        });

    $scope.unesi = function () {
        for (i = 0; i < predmeti.length; i++) {
            if (predmeti[i].Ime_predmeta==imePredmeta) {
                var obj = {
                    PredmetId: predmeti[i].Id,
                    Pitanje: $scope.pitanje,
                    Odg1: $scope.odg1,
                    Odg2: $scope.odg2,
                    Odg3: $scope.odg3,
                    Tocan_odgovor: $scope.tocan_odgovor
                };

                kvizService.add(obj).then(function (response) {
                    $scope.response = response.data;
                    document.getElementById('id_Odg2').value = '';
                    document.getElementById('id_Odg3').value = '';
                    document.getElementById('id_TocanOdg').value = '';
                    document.getElementById('id_Pitanje').value = '';
                    document.getElementById('id_Odg1').value = '';

                }).catch(function (response) {
                    for (var key in response.data.ModelState)
                    {
                        alert(response.data.ModelState[key][0]);
                    }
                }); 
            }
        }
    }; 
});