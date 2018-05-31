var app = angular.module('app', ['ui.router', 'angularUtils.directives.dirPagination', 'angular-md5', 'LocalStorageModule', 'ngStorage', 'ui.filters']);

app.config(function ($stateProvider, $urlRouterProvider, localStorageServiceProvider)
{
    localStorageServiceProvider.setPrefix('app');
    localStorageServiceProvider.setStorageType('localStorage');
    $urlRouterProvider.otherwise('/korisnik/login');

    $stateProvider
        .state('predmeti', {
            url: '/predmeti',
            controller: 'PredmetiController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Predmeti/IndexPredmeti.html'
                }
            }
        }).state('register', {
            url: '/korisnik/registracija',
            controller: 'RegisterController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Korisnik/Register.html'
                }
            }
        }).state('login', {
            url: '/korisnik/login',
            controller: 'LoginController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Korisnik/Login.html'
                }
            }

        }).state('home', {
            url: '/korisnik/home',
            controller: 'HomeController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Korisnik/Home.html'
                }
            }

        }).state('potvrdaKorisnika', {
            url: '/korisnik/potvrdaKorisnika',
            controller: 'PotvrdaKorisnikaController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Korisnik/PotvrdaKorisnika.html'
                }
            }

        }).state('potvrdaKorisnikaPotvrdeno', {
            url: '/korisnik/potvrdaKorisnikaPotvrdeno',
            controller: 'PotvrdaKorisnikaController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Korisnik/PotvrdaKorisnikaPotvrdeno.html'
                }
            }

        }).state('potvrdaKorisnikaOdbijeno', {
            url: '/korisnik/potvrdaKorisnikaOdbijeno',
            controller: 'PotvrdaKorisnikaController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Korisnik/potvrdaKorisnikaOdbijeno.html'
                }
            }

        }).state('predmetiIndex', {
            url: '/predmeti/predmetiIndex',
            controller: 'PredmetiController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Predmeti/IndexPredmeti.html'
                }
            }

        }).state('editPredmeti', {
            url: '/predmeti/predmetiEdit/:PrId',
            controller: 'EditPredmetiController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Predmeti/EditPredmeti.html'
                }
            }

        }).state('addPredmeti', {
            url: '/predmeti/predmetiAdd',
            controller: 'AddPredmetiController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Predmeti/AddPredmeti.html'
                }
            }

        }).state('unosOcjena', {
            url: '/ocjene/ocjeneUnos',
            controller: 'UnosOcjenaController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Ocjene/UnosOcjena.html'
                }
            }

        }).state('unosOcjenaUcenik', {
            url: '/ocjene/ocjeneUnosUcenik/:KoId',
            controller: 'UnosOcjenaUcenikController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Ocjene/UnosOcjenaUcenik.html'
                }
            }

        }).state('unosOcjenaUcenikPredmet', {
            url: '/ocjene/ocjeneUnosUcenik/:KoId/:UcPrId',
            controller: 'UnosOcjenaUcenikPredmetiController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Ocjene/UnosOcjenaUcenikOcjena.html'
                }
            }

        }).state('pregledOcjena', {
            url: '/ocjene/ocjenePregled',
            controller: 'UnosOcjenaController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Ocjene/PregledOcjena.html'
                }
            }

        }).state('pregledOcjenaUcenik', {
            url: '/ocjene/ocjenePregledUcenik/:KoId',
            controller: 'UnosOcjenaUcenikController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Ocjene/PregledOcjenaUcenik.html'
                }
            }

        }).state('pregledOcjenaUcenikPredmet', {
            url: '/ocjene/ocjenePregledUcenik/:KoId/:UcPrId',
            controller: 'PregledOcjenaUcenikPredmetiController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Ocjene/PregledOcjenaUcenikOcjena.html'
                }
            }

        }).state('brisanjeOcjena', {
            url: '/ocjene/ocjeneBrisanje',
            controller: 'UnosOcjenaController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Ocjene/BrisanjeOcjena.html'
                }
            }

        }).state('brisanjeOcjenaUcenik', {
            url: '/ocjene/ocjeneBrisanjeUcenik/:KoId',
            controller: 'UnosOcjenaUcenikController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Ocjene/BrisanjeOcjenaUcenik.html'
                }
            }

        }).state('brisanjeOcjenaUcenikPredmet', {
            url: '/ocjene/ocjeneBrisanjeUcenik/:KoId/:UcPrId',
            controller: 'BrisanjeOcjeneController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Ocjene/BrisanjeOcjenaUcenikOcjena.html'
                }
            }

        }).state('dohvatiPredmeteUcenikaU', {//dohvaća da ucenik moze vidit samo svoje predmete
            url: '/ocjene/ocjenePregledPredmeti/',
            controller: 'DohvatiPredmeteController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Ocjene/DohvatiPredmeteUcenikRoditelj.html'
                }
            }

        }).state('dohvatiUcenikeR', {//dohvaća ucenike da roditelj moze vidit samo ucenike koji su mu dodjeljeni
            url: '/ocjene/ocjenePregledUceniciR/',
            controller: 'DohvatiPredmeteUcenikaZaRoditeljaController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Ocjene/DohvatiPredmeteUcenikaZaRoditelja.html'
                }
            }

        }).state('dohvatiPredmete', {
            url: '/kviz/dohvatiPredmete ',   
            controller: 'DohvatiPredmeteController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Kviz/DohvatiPredmete.html'
                }
            }

        }).state('dodajKviz', {
            url: '/kviz/dohvatiPredmete/dodajKviz/:UcPrId',
            controller: 'DodajKvizController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Kviz/DodajKviz.html'
                }
            }

        }).state('dohvatiPredmeteZaPregled', {
            url: '/kviz/dohvatiPredmeteZaPregled ',
            controller: 'DohvatiPredmeteController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Kviz/DohvatiPredmetePregled.html'
                }
            }

        }).state('pregledajKviz', {
            url: '/kviz/dohvatiPredmete/pregledajKviz/:UcPrId',
            controller: 'PregledajKvizController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Kviz/PregledajKviz.html'
                }
            }

        }).state('popraviKviz', {
            url: '/kviz/dohvatiPredmete/popraviKviz/:KvizId',
            controller: 'PopraviKvizController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Kviz/PopraviKviz.html'
                }
            }
        }).state('dohvatiPredmeteZaRijesavanje', {
            url: '/kviz/dohvatiPredmeteZaR',
            controller: 'DohvatiPredmeteController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Kviz/DohvatiPredmeteRjesavanje.html'
                }
            }
        }).state('rjesavajKviz', {
            url: '/kviz/rjesavajKviz/:UcPrId',
            controller: 'RjesavajKvizController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Kviz/RjesavajKviz.html'
                }
            }
        }).state('dodajUcenikeRoditelju', {//dodavanje ucenika roditelju
            url: '/korisnik/dodajUcenikeRoditelju',
            controller: 'DodajUcenikeRoditeljuController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Korisnik/DodajUcenikeRoditelju.html'
                }
            }
        }).state('izmjeniUcenikeRoditelju', {
            url: '/korisnik/izmjeniUcenikeRoditelju/:KorId',
            controller: 'IzmjeniUcenikeRoditeljuController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Korisnik/IzmjeniUcenikeRoditelju.html'
                }
            }
        }).state('obrisiUcenikeRoditelju', {
            url: '/korisnik/obrisiUcenikeRoditelju/:KorId',
            controller: 'ObrisiUcenikeRoditeljuController',
            views: {
                "root": {
                    templateUrl: 'app/Views/Korisnik/ObrisiUcenikeRoditelju.html'
                }
            }
        }).state('kontakt', {
            url: '/kontakt',
            views: {
                "root": {
                    templateUrl: 'app/Views/Kontakt.html'
                }
            }

        }).state('oAplikaciji', {
            url: '/oAplikaciji',
            views: {
                "root": {
                    templateUrl: 'app/Views/OAplikaciji.html'
                }
            }

        });
});

