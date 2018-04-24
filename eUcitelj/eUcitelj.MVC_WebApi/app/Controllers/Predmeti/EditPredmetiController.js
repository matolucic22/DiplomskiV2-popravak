app.controller("EditPredmetiController", function ($scope, $stateParams, $http, $window, $state, predmetiService, KONSTANTE) {

    predmeti = [];

    $scope.find = function () {
        predmetiService.getAll()
             .then(function (response) {
                predmeti = response.data;
            }, function () {
                window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
            });

    };

    $scope.update = function () {

        var ime = $stateParams.PrIme;//razlog proslijeđivanja imena predmeta je objašnjen u PredmetiController.js fileu pod --> ***ODG: ... Imam više imena i želim ih sve update-at.

        for(i=0; i<predmeti.length; i++)
        {
            if(predmeti[i].Ime_predmeta==ime)
            {
                if ($scope.Ime_predmeta != null) {
                    var updated = {
                        PredmetId: predmeti[i].PredmetId,
                        Ime_predmeta: $scope.Ime_predmeta
                    };

                    predmetiService.update(updated).then(function (data) {
                        $state.go('predmetiIndex');
                    });
                } else {
                    $window.alert("Došlo je do greške prilikom popunjavanja polja.");
                }
            }
        }
    };
});