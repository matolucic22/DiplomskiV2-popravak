app.controller('PregledOcjenaUcenikPredmetiController', function ($scope, $stateParams, $http, $window, $location, predmetiService, korisnikService, KONSTANTE, IDKOR, ocjeneService) {//unos ocjena uceniku
    var id = $stateParams.UcPrId;
    var idKorisnik = IDKOR.id;
    var oc = [];
    var ocjeneK = [];
    $scope.ocjene = [];
    

    //PRIKAZ IMENA KORISNIKA//-da se zna koji je korisnik u pitanju

    korisnikService.get(idKorisnik).then(function (response) {

        $scope.trKorisnik = response.data;

    }, function () {
        $window.alert(KONSTANTE.DOHVACANJE_KORISNIKA_GRESKA);
    });

    ocjeneService.getByKorisnikIdAsync(idKorisnik).then(function (respose)
    {

        ocjeneK = respose.data;

        for(i=0; i<ocjeneK.length; i++)
        {
            if(ocjeneK[i].PredmetId==id)
            {
                 oc[i] = ocjeneK[i];
            }
        }
        
        $scope.ocjene = oc;
        
    }, function ()
    {
            $window.alert(KONSTANTE.DOHVACANJE_OCJENE_GRESKA);
        });
});