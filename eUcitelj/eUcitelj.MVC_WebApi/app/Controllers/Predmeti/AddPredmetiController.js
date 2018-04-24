app.controller("AddPredmetiController", function ($scope, $http, $location, $window, $state, predmetiService, korisnikService, KONSTANTE) {

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
        }
            , function (jqXHR) {
                window.alert("Greška prilikom stvaranja testnog korisnika.");
            });
     }
    });
        

    $scope.addPredmet = function () {

        //PITANJE: "  •	stavljati item za update ili create na objekt, i onda se cijeli objekt može proslijediti u update/create metodu "
        //ODG: Nisam razumio pitanje. Prilikom create(add)/update sad stvorio objekt i na njega stavio potrebne item-e te poslao na metodu.

        predmetiService.getAll().then(function (response) {//prvo sam dohvatio sve predmete da mogu provjeriti dali unešeni string (Ime predmeta) već postoji u bazi. Taj način sam iskoristio ovdje, kasnije sam shvatio da potoji lakših, bržih, učinkovitijih načina za pretragu.
            predmeti = response.data;
            for (i = 0; i < predmeti.length; i++)
            {
                predmetiI[i] = predmeti[i].Ime_predmeta;
            }
                        
            if (predmetiI.indexOf($scope.Ime_predmeta) == -1) {// Jedan od načina koji sam koristio da vidim dali mi unešeni string (Ime predmeta) već postoji u bazi. 
                for (i = 0; i < korisnikIdovi.length; i++) { //Pokušavao sam još ranije postaviti itemu Ime_predmeta u bazi index 'unique', ali s obzirom da u tablici Predmet imam više istih Imena predmeta sa različitim ID-ovima i ID-ovima korisnika (Objašnjeno u PredmetiController.js skripti kao komentar pod  --> ***ODG:) logika nije dobro funkcionirala pa sam se odlučio na ovo.
                    var objAdd = {
                        KorisnikId: korisnikIdovi[i].KorisnikId,
                        Ime_predmeta: $scope.Ime_predmeta
                    };

                    predmetiService.add(objAdd).then(function (data) {
                        $scope.response = data;
                        $state.go('predmetiIndex');
                    });
                }
            }else
            {
                $window.alert(KONSTANTE.UNOS_POSTOJI);//poruka o validaciji je u ovom obliku. U slučaju unosa itema koji već postji u tablici, u Controlleru se kreira InternalServerError sa nekim Exceptionom 
                                                      //koji nije user friendly te je modificiran na frontendu. 
            }
        });       
    };
});