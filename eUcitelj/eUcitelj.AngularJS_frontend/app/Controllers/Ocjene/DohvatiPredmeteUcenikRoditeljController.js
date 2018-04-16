app.controller('DohvatiPredmeteUcenikRoditeljController', function ($scope, $http, $stateParams, $window) {
    $scope.korisnikP = [];
    id=angular.fromJson($window.localStorage['ngStorage-currentUser']).KorisnikId;//ucitelj kad pregledava ocijene mora vidjeti sve-zato odvajanje
    $http.get('api/korisnik?id=' + id)
        .then(function (response) {
            korisnik = response.data;
            $scope.korisnikP = korisnik.Predmeti;
        }, function () {
            console.log("Can't get response.");
        });
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    };
});