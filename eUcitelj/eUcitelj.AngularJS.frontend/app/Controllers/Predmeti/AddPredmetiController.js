app.controller("AddPredmetiController", function ($scope, $http, $location, $window, $state, predmetiService, korisnikService, KONSTANTE, uuid, predmetKorisnikService) {

    var test = 'Test';
    var korisnikIdovi = {
        KorisnikId:undefined
    };

    var predmeti = [];

    var predmetiI = [];
    
    korisnikService.getAllKorisnikId().then(function (response) {
        korisnikIdovi = response.data;

        if (korisnikIdovi.length == 0) {
            var addK = {
                Ime_korisnika: test,
                Prezime_korisnika: test,
                Korisnicko_ime: test,
                Lozinka: test,
                PotvrdaLozinke: test,
                Potvrda: "Da",
                Uloga: "ucenik"
            };
            korisnikService.add(addK)
        .then(function (data) {
            $scope.response = data;
            $window.alert("Učenika trenutno nemate u bazi. Kako bi ste mogli dodati predmete kreiran je testni učenik. Predmeti se obavezno moraju pridružiti učenicima. Kada se registrira barem jedan učenik, slobodno možete obrisati testnog. Predmeti će ostati pohranjeni. Vratite se nazad i ponovno upišite predmet.");
        }).catch(function (response) {
            for (var key in response.data.ModelState)
            {
                alert(response.data.ModelState[key][0]);
            }
        });
     }
    });
        

    $scope.addPredmet = function () {

        PrId = uuid.new();

        var addPR = {
            Ime_predmeta: $scope.Ime_predmeta,
            PredmetId: PrId
        };

        predmetiService.add(addPR).then(function (data) {
            $scope.response = data;
        }).catch(function (response) {
            for (var key in response.data.ModelState) {
                alert(response.data.ModelState[key][0]);
            }
        });
    };
    
});

app.factory('uuid', function () {
    var svc = {
        new: function () {
            function _p8(s) {
                var p = (Math.random().toString(16) + "000000000").substr(2, 8);
                return s ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
            }
            return _p8() + _p8(true) + _p8(true) + _p8();
        },

        empty: function () {
            return '00000000-0000-0000-0000-000000000000';
        }
    };

    return svc;
});