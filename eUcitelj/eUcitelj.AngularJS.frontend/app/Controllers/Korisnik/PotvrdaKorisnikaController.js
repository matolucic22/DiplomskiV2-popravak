app.controller('PotvrdaKorisnikaController', function ($scope, $http, $stateParams, $window, $location, $rootScope, $state, korisnikService, predmetiService, predmetKorisnikService,  KONSTANTE) {
    $scope.korisnici = [];
    $scope.myVal = [];

    $scope.potvrdaNepotvrdeno = function () {

        korisnikService.getAllNepotvrdeno().then(function (response) {

            $scope.korisnici = response.data;

        }, function () {
            console.log(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
        });
    };

    $scope.potvrdaPotvrdeno = function () {

        korisnikService.getAllPotvrdeno().then(function (response) {

            $scope.korisnici = response.data;

        }, function () {
            console.log(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
        });
    };

    $scope.potvrdaOdbijeno = function () {

        korisnikService.getAllOdbijeno().then(function (response) {

            $scope.korisnici = response.data;

        }, function () {
            console.log(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
        });
    };



    $scope.da = function (korisnikId) {

        $rootScope.KorisnikId = korisnikId;
        var rola = prompt("Upišite ulogu potvrđenog korisnika (Ucitelj/Ucenik/Roditelj):", "");
        var rolaLower = rola.toString().toLowerCase();

        if (rolaLower == "ucitelj" || rolaLower == "ucenik" || rolaLower == "roditelj") {
            if (rolaLower == "roditelj") {
                $state.go('dodajUcenikeRoditelju');
                korisnikService.get(korisnikId).then(function (response) {
                    var korisnik = response.data;
                    korisnik2 = {
                        Id: korisnik.Id,
                        Ime_korisnika: korisnik.Ime_korisnika,
                        Prezime_korisnika: korisnik.Prezime_korisnika,
                        Korisnicko_ime: korisnik.Korisnicko_ime,
                        Lozinka: korisnik.Lozinka,
                        Potvrda: "Da",
                        Uloga: rola
                    };


                    korisnikService.update(korisnik2).then(function (data) {
                        $window.alert("Promijenjeno");
                        $state.go('potvrdaKorisnika');
                    }).catch(function (response) {
                        for (var key in response.data.ModelState)
                        {
                            alert(response.data.ModelState[key][0]);
                        }
                    });

                }, function () {

                    $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
                });

            } else {
                korisnikService.get(korisnikId).then(function (response)
                {
                    var korisnik = response.data;
                    korisnik2 = {
                        Id: korisnik.Id,
                        Ime_korisnika: korisnik.Ime_korisnika,
                        Prezime_korisnika: korisnik.Prezime_korisnika,
                        Korisnicko_ime: korisnik.Korisnicko_ime,
                        Lozinka: korisnik.Lozinka,
                        Potvrda: "Da",
                        Uloga: rola
                    };
                    korisnikService.update(korisnik2).then(function (data) {
                        $window.alert("Promijenjeno");
                        $state.go('potvrdaKorisnika');
                    }).catch(function (response) {
                        for (var key in response.data.ModelState)
                        {
                            alert(response.data.ModelState[key][0]);
                        }
                    });

                }, function () {

                    $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
                });
            }

        } else {
            $window.alert("U prazno polje upišite ulogu potvrđenog korisnika. Pazite da unos bude kao što je predloženo.");
        }

        if (rolaLower == "ucenik") {
            predmetiService.getAllImePredmeta().then(function (response) {

                predmeti = response.data;

                for (i = 0; i < predmeti.length; i++)
                {
                    var objAddPr = {
                        KorisnikId: korisnikId,
                        PredmetId: predmeti[i].PredmetId
                    };

                    predmetKorisnikService.add(objAddPr).then(function (data) {

                        $scope.response = data;
                        $state.go('potvrdaKorisnika');

                    }).catch(function (response) {
                        for (var key in response.data.ModelState) {
                            alert(response.data.ModelState[key][0]);
                        }
                    });
                }

                window.alert("Dodani predmeti učeniku.");

            }, function () {
                window.alert(KONSTANTE.DOHVACANJE_PREDMETA_GRESKA);
            });

        };
    }


        $scope.ne = function (korisnikId) {

            korisnikService.get(korisnikId).then(function (response) {
                var korisnik = response.data;
                if (korisnik.Ime_korisnika == 'ucitelj') {
                    $window.alert('Ucitelj se ostavlja kao obavezan u aplikaciji te mu kao takvom ne možete zabraniti pristup ili ga obrisati.');
                } else {
                    var korisnik2 = {
                        Id: korisnik.Id,
                        Ime_korisnika: korisnik.Ime_korisnika,
                        Prezime_korisnika: korisnik.Prezime_korisnika,
                        Korisnicko_ime: korisnik.Korisnicko_ime,
                        Lozinka: korisnik.Lozinka,
                        Potvrda: "Ne",
                        Uloga: "???"
                    };
                    korisnikService.update(korisnik2).then(function (data) {
                        $window.alert("Promijenjeno");
                        $state.go('potvrdaKorisnika');
                    }).catch(function (response)
                    {
                        for (var key in response.data.ModelState)
                        {
                            alert(response.data.ModelState[key][0]);
                        }
                    });
                }

            }, function () {

                $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
            });

        };

        $scope.deleteK = function (korisnikId) {

            korisnikService.delete(korisnikId).then(function (response) {
                $window.alert("Korisnik uklonjen.");
                $state.go('potvrdaKorisnika');
            }, function () {

                $window.alert(KONSTANTE.UKLANJANJE_KOR_GRESKA);

            });
        }; 
});