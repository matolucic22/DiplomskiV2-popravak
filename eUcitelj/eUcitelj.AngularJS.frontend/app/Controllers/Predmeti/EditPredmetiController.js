app.controller("EditPredmetiController", function ($scope, $stateParams, $http, $window, $state, predmetiService, KONSTANTE) {

    $scope.update = function () {

        var id = $stateParams.PrId;

            if ($scope.ime_predmeta != null) {
                var updated = {
                    Id: id,
                    Ime_predmeta: $scope.ime_predmeta
                };

                predmetiService.update(updated).then(function (data) {
                    $state.go('predmetiIndex');
                }).catch(function (response) {
                    for (var key in response.data.ModelState) {
                        alert(response.data.ModelState[key][0]);
                    }
                });
            }
            else {
                $window.alert("Došlo je do greške prilikom popunjavanja polja.");
            }
    };
});