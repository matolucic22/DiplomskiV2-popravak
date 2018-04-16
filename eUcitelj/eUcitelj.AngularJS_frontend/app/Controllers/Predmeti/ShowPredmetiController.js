app.controller("ShowPredmetiController", function ($scope, $http) {
    $scope.predmeti = [];
    
    //$http.get('api/predmeti')
    //    .then(function (response) {
    //        $scope.predmeti = response.data;
    //    }, function () {
    //        console.log("Can't get response.");
    //    });


    //$scope.sort = function (keyname) {
    //    $scope.Redoslijed = keyname;
    //    $scope.reverse = !$scope.reverse;//if true make it false and vice versa
    //};



    //funkcija za paging, sorting, fltering
    $scope.spfPredmeti=function(redoslijed, trazeniPojam, brStr)
    {
        $http.get('api/predmeti/spf?redoslijed=' + redoslijed + '&trazeniPojam=' + trazeniPojam + '&brStr=' + brStr)
       .then(function (response) {
           $scope.predmeti = response.data;
       }, function () {
           console.log("Can't get response.");
       });
    }

});