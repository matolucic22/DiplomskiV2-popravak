app.service('predmetiService', function ($http) {

    var httpReqPr = 'api/predmeti';

    this.add = function (obj) {
        return $http.post(httpReqPr, obj);
    };

    this.delete = function (Id) {
        return $http.delete(httpReqPr+'?Id=' + Id);
    };

    this.getAll = function () {
        return $http.get(httpReqPr);
    };

    this.get = function (Id) {
        return $http.get(httpReqPr+'?Id=' + Id);
    };

    this.update = function (update) {
        return $http.put(httpReqPr, update);
    };
    
    this.spf = function (redoslijed, trazeniPojam, brStr) {
        return $http.get(httpReqPr+'/spf?redoslijed=' + redoslijed + '&trazeniPojam=' + trazeniPojam + '&brStr=' + brStr);
    };

});