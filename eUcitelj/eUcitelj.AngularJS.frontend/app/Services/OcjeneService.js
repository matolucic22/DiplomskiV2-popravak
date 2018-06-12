app.service('ocjeneService', function ($http) {

    var httpReqOc='api/ocjene';

    this.add = function (obj) {
        return $http.post(httpReqOc, obj);
    };

    this.delete = function (id) {
        return $http.delete(httpReqOc + '?Id=' + id);
    };

    this.getAll = function () {
        return $http.get(httpReqOc);
    };

    this.get = function (id) {
        return $http.get(httpReqOc+'?Id=' + id);
    };

    this.update = function (obj) {
        return $http.put(httpReqOc, obj);
    };

    this.getByKorisnikIdAsync = function (id) {
        return $http.get(httpReqOc + '?KorisnikId=' + id);
    };

});