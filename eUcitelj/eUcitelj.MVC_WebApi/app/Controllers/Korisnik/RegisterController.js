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
            Ime_korisnika: $scope.Ime_korisnika,
            Prezime_korisnika: $scope.Prezime_korisnika,
            Korisnicko_ime: $scope.Korisnicko_ime,
            Lozinka: $scope.Lozinka,
            PotvrdaLozinke: $scope.PotvrdaLozinke,
            Potvrda: "???",
            Uloga: "???"
        };      

        for (var i = 0; i < provjeraKI.length; i++) {
            if (provjeraKI[i].Korisnicko_ime == addObj.Korisnicko_ime) {
               //counter++;
                
                return window.alert("Unešeno korisničko ime već postoji u bazi.");
            }
        }
        //if (counter != 0) {//nepotrebna provjera. Ako postoji korisnicko ime u bazi returna se poruka iz gornje funkcije.
            
        //    window.alert("Unešeno korisničko ime već postoji.");
        //    counter = 0;
        //}
       if (addObj.Lozinka != addObj.PotvrdaLozinke) {
            window.alert("Potvrđena lozinka se ne podudara sa glavnom lozinkom.");
        }
        else {
            addObj.Lozinka = md5.createHash($scope.Lozinka || '');

           //upis korisnika u bazu
           korisnikService.add(addObj)
                .then(function (data) {
                    $scope.response = data;
                    modal.style.display = "block";                   
                }
            , function (jqXHR) {

                window.alert("Sve rubrike moraju biti popunjene.");
                //Validacijske poruke se prikazuju u obliku popup-a (alert) iz kontrolera.

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

    
