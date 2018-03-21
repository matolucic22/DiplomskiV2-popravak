﻿app.controller("EditPredmetiController", function ($scope, $stateParams, $http, $window, $location) {

    predmeti = [];

    $scope.find = function () {
        $http.get('api/Predmeti/getAllP')
             .then(function (response) {
                predmeti = response.data;
            }, function () {
                console.log("Can't get response.");
            });

    };

    $scope.update = function () {

        var ime = $stateParams.PrIme;

        for(i=0; i<predmeti.length; i++)
        {
            if(predmeti[i].Ime_predmeta==ime)
            {
                if ($scope.Ime_predmeta != null) {
                    var updated = {
                        PredmetiId: predmeti[i].PredmetiId,
                        Ime_predmeta: $scope.Ime_predmeta
                    };

                    $http.put('/api/Predmeti/updateP', updated).then(function (data) {
                        $location.path('/predmeti/predmetiIndex');
                    });
                } else {
                    $window.alert("Došlo je do greške prilikom popunjavanja polja.");
                }
            }
        }
    };
});