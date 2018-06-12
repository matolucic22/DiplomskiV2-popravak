app.service('korisnikService', function ($http) {

    var httpReqKor='api/korisnik';

    this.add = function (obj) {
        return $http.post(httpReqKor, obj);
    };

    this.delete = function (id) {
        return $http.delete(httpReqKor + '?Id=' + id);
    };

    this.get = function (id) {
        return $http.get(httpReqKor + '?Id=' + id);
    };

    this.update = function (update) {
        return $http.put(httpReqKor, update);
    };

    this.loginToken = function (userCredentials) {
        return $http.post(httpReqKor+'/logintoken', userCredentials);
    };

    this.getKorisnickoIme = function () {
        return $http.get(httpReqKor + '/getkorisnickoime');
    };

    this.getAllUcenik = function () {
        return $http.get(httpReqKor + '/getallucenik');
    };

    this.getAllNepotvrdeno = function () {
        return $http.get(httpReqKor + '/getallnepotvrdeno');
    };

    this.getAllPotvrdeno = function () {
        return $http.get(httpReqKor + '/getallpotvrdeno');
    };

    this.getAllOdbijeno = function () {
        return $http.get(httpReqKor + '/getallodbijeno');
    };
});