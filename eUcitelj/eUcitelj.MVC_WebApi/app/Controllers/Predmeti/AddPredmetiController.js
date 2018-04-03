app.controller("AddPredmetiController", function ($scope, $http, $location, $window) {

    var KorisnikIds = {
        KorisnikId:undefined
    };

    var Predmeti = [];

    var PredmetiI = [];

    $http.get('/api/Korisnik/getAllKorisnikId').then(function (response) {
        KorisnikIdovi = response.data;

        if (KorisnikIdovi.length == 0) {
            var addK = {
                Ime_korisnika: 'Test',
                Prezime_korisnika: 'Test',
                Korisnicko_ime: 'Test',
                Lozinka: 'Test',
                PotvrdaLozinke: 'Test',
                Potvrda: "Da",
                Uloga: "ucenik"
            };
            $http.post('/api/Korisnik', addK)
        .then(function (data) {
            $scope.response = data;
            $window.alert("Učenika trenutno nemate u bazi. Kako bi ste mogli dodati predmete kreiran je testni učenik. Predmeti se obavezno moraju pridružiti učenicima. Kada se registrira barem jedan učenik, slobodno možete obrisati testnog. Predmeti će ostati pohranjeni. Vratite se nazad i ponovno upišite predmet.");

        }
            , function (jqXHR) {

                window.alert("Greška prilikom stvaranja testnog korisnika.");
            });
     }
    });
        

    $scope.addPredmeti = function () {

        $http.get('api/Predmeti').then(function (response) {
            Predmeti = response.data;
            for (i = 0; i < Predmeti.length; i++)
            {
                PredmetiI[i] = Predmeti[i].Ime_predmeta;
            }
                        
            if (PredmetiI.indexOf($scope.Ime_predmeta) == -1) {
                for (i = 0; i < KorisnikIdovi.length; i++) {
                    var objAdd = {
                        KorisnikId: KorisnikIdovi[i].KorisnikId,
                        Ime_predmeta: $scope.Ime_predmeta
                    };

                    $http.post('api/Predmeti', objAdd).then(function (data) {
                        $scope.response = data;
                        $location.path('/predmeti/predmetiIndex');
                    });
                }
            }else
            {
                $window.alert("Predmet već postoji u bazi.");
            }
        });       
    };
});