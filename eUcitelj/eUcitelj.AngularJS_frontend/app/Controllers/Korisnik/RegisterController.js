app.controller('RegisterController', function ($scope, $http, md5, $location) {//singup
    var modal = document.getElementById('successModal');

    var provjeraKI = {
        Korisnicko_ime: undefined
    };

    $http.get('/api/korisnik/getKorisnickoIme').then(function (response) {

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
            $http.post('/api/korisnik', addObj)
                .then(function (data) {
                    $scope.response = data;
                    modal.style.display = "block";                   
                }
            , function (jqXHR) {

                window.alert("Sve rubrike moraju biti popunjene.");

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

    
