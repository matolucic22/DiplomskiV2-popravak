app.service('korisnikService', function ($http) {

    var httpReqKor='api/korisnik';

    this.add = function (obj) {
        return $http.post(httpReqKor, obj);
    };

    this.delete = function (Id) {
        return $http.delete(httpReqKor + '?Id=' + Id);
    };

    this.getAll = function () {
        return $http.get(httpReqKor);
    };

    this.get = function (Id) {
        return $http.get(httpReqKor + '?Id=' + Id);
    };

    this.update = function (Update) {
        return $http.put(httpReqKor, Update);
    };

    this.loginToken = function (userCredentials) {
        return $http.post(httpReqKor+'/logintoken', userCredentials);
    };

    this.getKorisnickoIme = function () {
        return $http.get(httpReqKor + '/getKorisnickoIme');
    };

    this.getAllKorisnikId = function () {
        return $http.get(httpReqKor + '/getAllKorisnikId');
    };
});