app.service('kvizService', function ($http) {

    var httpReqKv='api/kviz';

    this.add = function (obj) {
        return $http.post(httpReqKv, obj);
    };

    this.delete = function (Id) {
        return $http.delete(httpReqKv+'?Id=' + Id);
    };

    this.getAll = function () {
        return $http.get(httpReqKv);
    };

    this.get = function (Id) {
        return $http.get(httpReqKv+'?Id=' + Id);
    };

    this.update = function (obj) {
        return $http.put(httpReqKv, obj);
    };

});