app.controller('RegisterController', function ($scope, $http, md5, $location) {//singup
    var modal = document.getElementById('successModal');

    var provjeraKI = {
        Korisnicko_ime: undefined
    };

    $http.get('/api/Korisnik/getKI').then(function (response) {

        provjeraKI = response.data;

    }, function (response) {
        window.alert("Greška prilikom preuzimanja korisnika iz baze.");
    });

    $scope.doStuff = function () {
        var counter = 0;
        var addObj = {
            Ime_korisnika: $scope.Ime_korisnika,
            Prezime_korisnika: $scope.Prezime_korisnika,
            Korisnicko_ime: $scope.Korisnicko_ime,
            Password: $scope.Password,
            ConfirmPassword: $scope.ConfirmPassword,
            Potvrda: "???",
            Role: "???"
        };      

        for (var i = 0; i < provjeraKI.length; i++) {
            if (provjeraKI[i].Korisnicko_ime == addObj.Korisnicko_ime) {
               counter++;
                
                return window.alert("Unešeno korisničko ime već postoji u bazi.");
            }
        }

        if (addObj.Ime_korisnika == null || addObj.Prezime_korisnika == null || addObj.Korisnicko_ime == null || addObj.Password == null) {
            window.alert("Niste upisali sve tražene podatke.");
        }
        else if (counter != 0) {
            
            window.alert("Unešeno korisničko ime već postoji.");
            counter = 0;
        }
        else if (addObj.Password != addObj.ConfirmPassword) {
            window.alert("Potvrđena lozinka se ne podudara sa glavnom lozinkom.");
        }
        else {
            addObj.Password = md5.createHash($scope.Password || '');

            //upis korisnika u bazu
            $http.post('/api/Korisnik/addK', addObj)
                .then(function (data) {
                    $scope.response = data;
                    modal.style.display = "block";                   
                }
            , function (jqXHR) {

                window.alert("Unešeno korisničko ime već postoji.");

            });
        }

        $scope.close = function () {
            modal.style.display = "none";
            $location.path('#!/korisnik/login');
        };

        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
                $location.path('#!/korisnik/login');
            }
        };
    };
});

    
