angular.module('app').factory('AuthenticationService', Service);

function Service($http, $localStorage, localStorageService) {

    var service = {};

    service.Login = Login;
    service.Logout = Logout;
    service.CheckIsStoraged = CheckIsStoraged;
    service.Check = Check;
    service.GetUsername = GetUsername;
    service.GetId = GetId;
    return service;

    function Login(korisnicko_ime, lozinka, callback) {
        var obj = {
            Korisnicko_ime: korisnicko_ime,
            Lozinka: lozinka
        };//funkcija login 

        $http.post('api/Korisnik/logintoken', obj)//dodaj korisnika
            .then(function successCallback(response) {
                if (response.data.KorisnikId && response.data.Korisnicko_ime && response.data.Token && response.data.Uloga) {
                    $localStorage.currentUser = {
                        KorisnikId: response.data.KorisnikId,
                        Korisnicko_ime: response.data.Korisnicko_ime,
                        Token: response.data.Token,
                        Uloga: response.data.Uloga
                    };

                    

                    // add jwt token to auth header for all requests made by the $http service
                    $http.defaults.headers.common.Authorization = 'Bearer ' + response.data.Token.TokenString;

                    //execute callback with true to indicate successful login
                   

                    callback(true);
                } else {
                    // execute callback with false to indicate failed login
                    callback(false);
                }
            }, function errorCallback(response){
                if (response.status == 404) {

                    // execute callback with 404 to indicate that username is not found
                    callback(404);
                } else if (response.status == 400) {
                    // execute callback with 404 to indicate that password is incorrect
                    callback(400);
                }
                else {
                    callback(false);
                }
            
            });
    }

    function Logout() {
        //remove user from local storage and clear http auth header

        delete $localStorage.currentUser;
        $http.defaults.headers.common.Authorization = '';
    }

    function CheckIsStoraged() {
        var dateTime = new Date();
        var miliseconds = dateTime.getTime();

        if($localStorage.currentUser!=undefined)
        {
            
            if($localStorage.currentUser.Token.ExpirationTime<miliseconds) 
            {
                Logout();
                console.log("PREDUGO LOGIRAN");
            }
        }
    }

    function Check() {
        if($localStorage.currentUser!=undefined && $http.defaults.headers.common.Authorization != '')
        {
            return true;
        }else
        {
            return false;
        }
    }

    function GetUsername() {
        if ($localStorage.currentUser != undefined) {
            return $localStorage.currentUser.Korisnicko_ime;
        }


    }

    function GetId() {
        if($localStorage.currentUser!=undefined)
        {
            return $localStorage.currentUser.KorisnikId;
        }
    }


}


