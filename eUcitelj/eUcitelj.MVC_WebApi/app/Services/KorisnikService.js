app.service('korisnikService', function ($http) {

    var httpReqKor='api/korisnik';

    this.add = function (obj) {
        return $http.post(httpReqKor, obj);
    };

    this.delete = function (Id) {
        return $http.delete(httpReqKor + '?Id=' + Id);
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