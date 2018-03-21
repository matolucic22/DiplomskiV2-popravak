app.controller("DeletePredmetiController", function ($stateParams, $http, $window, $location, $scope) {

    predmeti = [];
    var ime = $stateParams.PrIme;
    var i = 0;

    $scope.find = function () {
        $http.get('api/Predmeti/getAllP')
             .then(function (response) {
                 predmeti = response.data;
             }, function () {
                 console.log("Can't get response.");
             }); 
    };

    $scope.Da = function () {
        for (i = 0; i < predmeti.length; i++) {
            if (predmeti[i].Ime_predmeta == ime) {
                $http.delete('/api/Predmeti/deleteP?Id=' + predmeti[i].PredmetiId).then(function (data) {
                    $location.path('/predmeti/predmetiIndex');
                        });
                    }
                }
    };

    $scope.Ne = function () {
        $location.path('/predmeti/predmetiIndex');
    };
});