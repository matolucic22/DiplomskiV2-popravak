app.service('predmetKorisnikService', function ($http) {

    var httpReqPr = 'api/predmetkorisnik';

    this.getAll = function () {
        return $http.get(httpReqPr);
    };

    this.get = function (id) {
        return $http.get(httpReqPr + '?Id=' + id);
    };

    this.add = function (obj) {
        return $http.post(httpReqPr, obj);
    };
});