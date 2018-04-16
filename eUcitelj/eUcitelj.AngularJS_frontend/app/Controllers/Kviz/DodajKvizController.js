app.controller('DodajKvizController', function ($scope, $http, $stateParams, $location, $window) {

    id = $stateParams.UcPrId;
    
    PredmetiIme = [];
    Predmeti = [];

    //dohvati ime predmeta 
    $http.get('/api/predmeti?id='+id).then(function (response) {
        $scope.Predmeti = response.data;
        imePredmeta=$scope.Predmeti.Ime_predmeta;
    }
        , function (jqXHR) {
            window.alert("Greška prilikom dohvaćanja predmeta.");
        });

    //dohvati sve predmete
    $http.get('/api/predmeti').then(function (response) {
        Predmeti = response.data;
    }
        , function (jqXHR) {
            window.alert("Greška prilikom dohvaćanja predmeta.");
        });

    $scope.Unesi = function () {
        for (i = 0; i < Predmeti.length; i++) {
            if (Predmeti[i].Ime_predmeta==imePredmeta) {
                var obj = {
                    PredmetId: Predmeti[i].PredmetId,
                    Pitanje: $scope.Pitanje,
                    Odg1: $scope.Odg1,
                    Odg2: $scope.Odg2,
                    Odg3: $scope.Odg3,
                    Tocan_odgovor: $scope.Tocan_odgovor
                };

                $http.post('api/kviz', obj).then(function (response) {
                    $scope.response = response.data;
                    document.getElementById('id_Odg2').value = '';
                    document.getElementById('id_Odg3').value = '';
                    document.getElementById('id_TocanOdg').value = '';
                    document.getElementById('id_Pitanje').value = '';
                    document.getElementById('id_Odg1').value = '';

                }, function () {
                    $window.alert("Greška prilikom unosa kviza.");
                });
            }
        }
    }; 
});