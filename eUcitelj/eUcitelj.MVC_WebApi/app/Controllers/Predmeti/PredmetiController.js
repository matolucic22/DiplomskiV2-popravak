app.controller("PredmetiController", function ($scope, $http) {
    $scope.predmeti = [];
    $http.get('api/Predmeti')
        .then(function (response) {
            $scope.predmeti = response.data;
        }, function () {
            console.log("Can't get response.");
        });
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;//if true make it false and vice versa
    };
});