app.service('predmetKorisnikService', function ($http) {

    var httpReqPr = 'api/predmetkorisnik';

    this.getAll = function () {
        return $http.get(httpReqPr);
    };

    this.get = function (Id) {
        return $http.get(httpReqPr + '?Id=' + Id);
    };

    this.add = function (obj) {
        return $http.post(httpReqPr, obj);
    };

    //this.update = function (update) {
    //    return $http.put(httpReqPr, update);
    //};

    //this.delete = function (Id) {
    //    return $http.delete(httpReqPr + '?Id=' + Id);
    //};

});