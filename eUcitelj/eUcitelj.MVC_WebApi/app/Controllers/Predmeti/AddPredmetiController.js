app.controller("AddPredmetiController", function ($scope, $http, $location, $window, $state, predmetiService, korisnikService, KONSTANTE, predmetKorisnikService) {      

    $scope.predmet = {};

    $scope.addPredmet = function () {

        predmetiService.add($scope.predmet).then(function (data) {
            $scope.response = data;
        }).catch(function (response) {
            for (var key in response.data.ModelState)
            {
                alert(response.data.ModelState[key][0]);
            }
        });
    };
    
});