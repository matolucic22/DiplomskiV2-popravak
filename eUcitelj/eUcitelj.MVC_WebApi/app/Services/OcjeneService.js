app.service('ocjeneService', function ($http) {

    var httpReqOc='api/ocjene';

    this.add = function (obj) {
        return $http.post(httpReqOc, obj);
    };

    this.delete = function (Id) {
        return $http.delete(httpReqOc + '?Id=' + Id);
    };

    this.getAll = function () {
        return $http.get(httpReqOc);
    };

    this.get = function (Id) {
        return $http.get(httpReqOc+'?Id=' + Id);
    };

    this.update = function (obj) {
        return $http.put(httpReqOc, obj);
    };

});