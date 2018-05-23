app.controller("PredmetiController", function ($window, $scope, $http, predmetiService, KONSTANTE, $rootScope, $state) {
       $scope.spfPredmeti = function (redoslijed, trazeniPojam, brStr) {
        predmetiService.spf(redoslijed, trazeniPojam, brStr)
       .then(function (response) {
           $scope.predmeti = response.data;
       }, function () {
           $window.alert("Došlo je progreške prilikom SPF-a.")
       });
    };

    $scope.del=function (PredmetId)
    {
        predmetiService.delete(PredmetId).then(
            function (data)
            {
                $state.go('predmetiIndex');
            },function ()
            {
                window.alert(KONSTANTE.BRISANJE_GRESKA);
            });
    }
});