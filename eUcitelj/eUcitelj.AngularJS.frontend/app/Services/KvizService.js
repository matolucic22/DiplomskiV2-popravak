app.service('kvizService', function ($http) {

    var httpReqKv='api/kviz';

    this.add = function (obj) {
        return $http.post(httpReqKv, obj);
    };

    this.delete = function (id) {
        return $http.delete(httpReqKv+'?Id=' + id);
    };

    this.getAll = function () {
        return $http.get(httpReqKv);
    };

    this.get = function (id) {
        return $http.get(httpReqKv+'?Id=' + id);
    };

    this.update = function (obj) {
        return $http.put(httpReqKv, obj);
    };

});