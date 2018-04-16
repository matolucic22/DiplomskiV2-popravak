app.controller('DohvatiPredmeteController', function ($scope, $http, $stateParams) {
    var KorisnikIds = {
        KorisnikId:undefined
    };
    $scope.Korisnik = [];

    $http.get('/api/korisnik/getAllKorisnikId').then(function (response) {
        KorisnikIds = response.data;
        id=KorisnikIds[0].KorisnikId
        $http.get('/api/korisnik?id='+id)
    .then(function (response) {
        $scope.Korisnik = response.data;
        $scope.Predmeti = $scope.Korisnik.Predmeti;
    }
        , function (jqXHR) {
            window.alert("Greška prilikom dohvaćanja predmeta.");
        });
    });

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;//if true make it false and vice versa
    };
});