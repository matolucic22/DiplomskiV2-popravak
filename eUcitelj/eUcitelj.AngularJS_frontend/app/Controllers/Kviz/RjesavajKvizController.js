﻿app.controller('RjesavajKvizController', function ($scope, $http, $stateParams, $window) {
    idPredmet = $stateParams.UcPrId;
    var Predmet = [];
    
    $http.get('api/predmeti?id=' + idPredmet).then(function (response) {
        Predmet = response.data;
        $scope.Pitanja = Predmet.Kviz;
        if($scope.Pitanja.length == 0)
        {
            $window.alert("Pitanja nisu dodana.");
            var button = document.getElementById("button");
            button.parentNode.removeChild(button);
        }
    }, function ()
    {
        $window.alert("Greška prilikom pronalasa kviza");
    });

    $scope.Snimi = function () {
        var a = 0;
        var b = 0;
        var odgDiv = document.getElementsByClassName('Odg');
        var OdgV = [];
        var OdgN = [];
        for (var i = 0; i < odgDiv.length; i++) {
            if (odgDiv[i].checked) {
                OdgV[a] = odgDiv[i].value;

                a++;
            }
        }

        for (var j = 0; j < odgDiv.length; j++) {
            if (odgDiv[j].checked) {
                OdgN[b] = odgDiv[j].name;

                b++;
            }
        }

        var e = 0;
            for (var d = 0; d < OdgN.length; d++)
            {
                if(OdgV[d]==OdgN[d])
                {
                    e++;
                }
            }
   
            
            document.getElementById("TocanOdgovor").innerHTML = e;
            var button = document.getElementById("button");
            button.parentNode.removeChild(button);
    };
});