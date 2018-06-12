app.controller('LoginController', function ($scope, $http, $stateParams, $window, $state, $location, AuthenticationService, md5) {//singin
    
        InitController();

        function InitController() { 
            AuthenticationService.CheckIsStoraged();
        };

        $scope.doStuff = function () {
            var userToLogin = {
                Korisnicko_ime: $scope.korisnicko_ime,
                Lozinka: undefined
            };

            userToLogin.Lozinka = md5.createHash($scope.lozinka || '');
           
            AuthenticationService.Login(userToLogin.Korisnicko_ime, userToLogin.Lozinka, function (result) {
                if (result == true) {
                   $location.path('/korisnik/home');//reload stranice
                   $window.location.reload();
                   
                } else if (result == 404) {
                    $window.alert("Korisničko ime nije pronađeno.");
                } else if (result == 400) {
                    $window.alert("Lozinka nije pronađena.");
                } else {
                    $window.alert("Greška prilikom logiranja.");
                }
            });    
        };  
});



