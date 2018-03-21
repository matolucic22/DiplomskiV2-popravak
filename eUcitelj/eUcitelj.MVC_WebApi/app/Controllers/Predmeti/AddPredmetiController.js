app.controller("AddPredmetiController", function ($scope, $http, $location, $window) {

    var KorisnikIds = {
        KorisnikId:undefined
    };

    var Predmeti = [];

    var PredmetiI = [];

    $http.get('/api/Korisnik/getAllKorId').then(function (response) {
        KorisnikIds = response.data;

        if (KorisnikIds.length == 0) {
            var addK = {
                Ime_korisnika: 'Test',
                Prezime_korisnika: 'Test',
                Korisnicko_ime: 'Test',
                Password: 'Test',
                ConfirmPassword: 'Test',
                Potvrda: "Da",
                Role: "ucenik"
            };
            $http.post('/api/Korisnik/addK', addK)
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

        $http.get('api/Predmeti/getAllP').then(function (response) {
            Predmeti = response.data;
            for (i = 0; i < Predmeti.length; i++)
            {
                PredmetiI[i] = Predmeti[i].Ime_predmeta;
            }
                        
            if (PredmetiI.indexOf($scope.Ime_predmeta) == -1) {
                for (i = 0; i < KorisnikIds.length; i++) {
                    var objAdd = {
                        KorisnikId: KorisnikIds[i].KorisnikId,
                        Ime_predmeta: $scope.Ime_predmeta
                    };

                    $http.post('api/Predmeti/addP', objAdd).then(function (data) {
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