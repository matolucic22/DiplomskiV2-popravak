﻿app.controller('PotvrdaKorisnikaController', function ($scope, $http, $stateParams, $window, $location, $rootScope) {
    $scope.korisnici = [];
    $scope.myVal = [];
   

    $http.get('/api/Korisnik/getAllK').then(function (response) {

        $scope.korisnici = response.data;       

    }, function ()
    {
        console.log("Greška prilikom preuzimanja korisnika iz baze.");
    });


    $scope.Da = function (KorisnikId) {
        
        $rootScope.KorisnikId = KorisnikId;
        var rola = prompt("Upišite ulogu potvrđenog korisnika (Ucitelj/Ucenik/Roditelj):", "");
        var rolaLower = rola.toString().toLowerCase();
        
        if (rolaLower == "ucitelj" || rolaLower == "ucenik" || rolaLower == "roditelj") {
            if (rolaLower == "roditelj") {
                $location.path('/korisnik/dodajUcenikeRoditelju');
                $http.get('/api/Korisnik/getK?id=' + KorisnikId).then(function (response) {
                    var Korisnik = response.data;
                    Korisnik2 = {
                        KorisnikId: Korisnik.KorisnikId,
                        Ime_korisnika: Korisnik.Ime_korisnika,
                        Prezime_korisnika: Korisnik.Prezime_korisnika,
                        Korisnicko_ime: Korisnik.Korisnicko_ime,
                        Password: Korisnik.Password,
                        Potvrda: "Da",
                        Role: rola
                    };

                    $http.put('api/Korisnik/updateK', Korisnik2).then(function (data) {
                        $window.alert("Promijenjeno");
                        $http.get('/api/Korisnik/getAllK').then(function (response) {
                            $scope.korisnici = response.data;
                        }, function () {
                            console.log("Greška prilikom preuzimanja korisnika iz baze.");
                        });
                    }, function () {
                        console.log("Greška prilikom postavljanja promjene u bazu.");
                    });

                }, function () {

                    console.log("Greška prilikom dohvata podataka iz baze");
                });

            } else {
                $http.get('/api/Korisnik/getK?id=' + KorisnikId).then(function (response) {
                    var Korisnik = response.data;
                    Korisnik2 = {
                        KorisnikId: Korisnik.KorisnikId,
                        Ime_korisnika: Korisnik.Ime_korisnika,
                        Prezime_korisnika: Korisnik.Prezime_korisnika,
                        Korisnicko_ime: Korisnik.Korisnicko_ime,
                        Password: Korisnik.Password,
                        Potvrda: "Da",
                        Role: rola
                    };

                    $http.put('api/Korisnik/updateK', Korisnik2).then(function (data) {
                        $window.alert("Promijenjeno");
                        $http.get('/api/Korisnik/getAllK').then(function (response) {
                            $scope.korisnici = response.data;
                        }, function () {
                            console.log("Greška prilikom preuzimanja korisnika iz baze.");
                        });
                    }, function () {
                        console.log("Greška prilikom postavljanja promjene u bazu.");
                    });

                }, function () {

                    console.log("Greška prilikom dohvata podataka iz baze");
                });
            }

        }else
        {
            alert("U prazno polje upišite ulogu potvrđenog korisnika. Pazite da unos bude kao što je predloženo.");
        }

        if(rolaLower=="ucenik")
        {
            
            $http.get('/api/Korisnik/getAllKorId').then(function (response) {

                korisniciId = response.data;       
                
                    ////dohvati sve predmete zbog imena.
                    $http.get('/api/Predmeti/getAllP')
                       .then(function (response) {
                           predmeti = response.data;

                           for (i = 0; i < predmeti.length; i++) {
                               //stvaranje polja za dodavanje korisniku svih predmeta

                               if(predmeti[i].KorisnikId == korisniciId[0].KorisnikId)
                               {
                    
                                   var objAddPr = {
                                       KorisnikId: KorisnikId,
                                       Ime_predmeta: predmeti[i].Ime_predmeta
                                   };
                                   $http.post('api/Predmeti/addP', objAddPr).then(function (data) {
                                       $scope.response = data;
                                   });
                               }
                           }
                       }, function () {
                           window.alert("Greška prilikom dohvaćanja predmeta.");
                       });
                                       
                
             }, function () {
                        window.alert("Greška prilikom dohvaćanja IDa korisnika.");
                    });         

                window.alert("Dodani predmeti učeniku.");
            }
    };
        

    $scope.Ne = function (KorisnikId) {

        $http.get('/api/Korisnik/getK?id=' + KorisnikId).then(function (response) {
            var Korisnik = response.data;
            if (Korisnik.Ime_korisnika == 'ucitelj')
            {
                $window.alert('Ucitelj se ostavlja kao obavezan u aplikaciji te mu kao takvom ne možete zabraniti pristup ili ga obrisati.');
            } else
            {
                var Korisnik2 = {
                    KorisnikId: Korisnik.KorisnikId,
                    Ime_korisnika: Korisnik.Ime_korisnika,
                    Prezime_korisnika: Korisnik.Prezime_korisnika,
                    Korisnicko_ime: Korisnik.Korisnicko_ime,
                    Password: Korisnik.Password,
                    Potvrda: "Ne",
                    Role: "???"
                };

                $http.put('api/Korisnik/updateK', Korisnik2).then(function (data) {
                    $window.alert("Promijenjeno");
                    $http.get('/api/Korisnik/getAllK').then(function (response) {
                        $scope.korisnici = response.data;
                    }, function () {
                        console.log("Greška prilikom preuzimanja korisnika iz baze.");
                    });
                }, function () {
                    console.log("Greška prilikom postavljanja promjene u bazu.");
                });
            }

            }, function () {

                console.log("Greška prilikom dohvata podataka iz baze");
            });
        
    };

    $scope.DeleteK = function (KorisnikId)
    {
        
        $http.delete('/api/Korisnik/deleteK?Id=' + KorisnikId).then(function (response) {
            $window.alert("Korisnik uklonjen.");

                $http.get('/api/Korisnik/getAllK').then(function (response) {
                    $scope.korisnici = response.data;
                }, function () {
                    console.log("Greška prilikom preuzimanja korisnika iz baze.");
                });
        }, function () {

            alert("Greska prilikom uklanjanja iz baze korisnika.");

        });
    };  
});