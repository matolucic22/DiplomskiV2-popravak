app.controller('RegisterController', function ($scope, $http, md5, $location, $state, korisnikService, $window, KONSTANTE) {//singup

    var modal = document.getElementById('successModal');

    var provjeraKI = {
        Korisnicko_ime: undefined
    };

    korisnikService.getKorisnickoIme().then(function (response) {

        provjeraKI = response.data;

    }, function (response) {
        $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
    });

    $scope.doStuff = function () {
        var counter = 0;
        var addObj = {
            Ime_korisnika: $scope.ime_korisnika,
            Prezime_korisnika: $scope.prezime_korisnika,
            Korisnicko_ime: $scope.korisnicko_ime,
            Lozinka: $scope.lozinka,
            PotvrdaLozinke: $scope.potvrdaLozinke,
            Potvrda: "???",
            Uloga: "???"
        };      

        for (var i = 0; i < provjeraKI.length; i++) {
            if (provjeraKI[i].Korisnicko_ime == addObj.Korisnicko_ime) {
               
                
                return window.alert("Unešeno korisničko ime već postoji u bazi.");
            }
        }
        
       if (addObj.Lozinka != addObj.PotvrdaLozinke) {
            window.alert("Potvrđena lozinka se ne podudara sa glavnom lozinkom.");
        }
        else {
            addObj.Lozinka = md5.createHash($scope.Lozinka || '');

            korisnikService.add(addObj).then(function (data) { 
                $scope.response = data;
                modal.style.display = "block";                   
            }).catch(function (response) {
                for (var key in response.data.ModelState)
                {
                    alert(response.data.ModelState[key][0]);
                }
            });
        }

        $scope.close = function () {
            modal.style.display = "none";
            $state.go('login');
        };

        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
                $state.go('login');
            }
        };
    };
});

    
