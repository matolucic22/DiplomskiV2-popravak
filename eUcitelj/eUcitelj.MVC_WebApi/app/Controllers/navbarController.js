app.controller('NavbarController', function navbarController($scope, $http, $stateParams, $window, $state, $localStorage, AuthenticationService) {
    $scope.logOut = function () {
        AuthenticationService.Logout();
        $window.location.href = '/#/korisnik/login';
        $window.location.reload();       
    };

    $scope.upitnik = function () {
        var korisnik = angular.fromJson($window.localStorage['ngStorage-currentUser']).Uloga;
        if (korisnik == '???') {
            return true;
        }
    };

    $scope.ucitelj = function () {
        var korisnik = angular.fromJson($window.localStorage['ngStorage-currentUser']).Uloga;
        if (korisnik == 'ucitelj') {
            return true;
        }
    };

    $scope.roditelj = function () {
        var korisnik = angular.fromJson($window.localStorage['ngStorage-currentUser']).Uloga;
        if (korisnik == 'roditelj') {
            return true;
        }
    };

    $scope.ucenik = function () {
        var korisnik = angular.fromJson($window.localStorage['ngStorage-currentUser']).Uloga;
        if (korisnik == 'ucenik') {
            return true;
        }
    };
});