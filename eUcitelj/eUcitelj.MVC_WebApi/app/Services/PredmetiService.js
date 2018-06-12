app.service('predmetiService', function ($http) {

    var httpReqPr = 'api/predmeti';

    this.add = function (obj) {
        return $http.post(httpReqPr, obj);
    };

    this.delete = function (id) {
        return $http.delete(httpReqPr+'?Id=' + id);
    };

    this.get = function (id) {
        return $http.get(httpReqPr+'?Id=' + id);
    };

    this.update = function (update) {
        return $http.put(httpReqPr, update);
    };

    this.getAllImePredmeta = function () {
        return $http.get(httpReqPr+'/imepredmeta');
    };

    this.getAll = function () {
        return $http.get(httpReqPr);
    };
    
    this.findPredmet = function (redoslijed, trazeniPojam, brStr) {
        return $http.get(httpReqPr+'/spf?redoslijed=' + redoslijed + '&trazeniPojam=' + trazeniPojam + '&brStr=' + brStr);
    };

});