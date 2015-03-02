'use strict';

angular.module('gradCapApp.services').service('UserService', ['$q', '$http', function($q, $http) {
    this.getUserInfo = function(userID) {
        var d = $q.defer();
        $http.get('/api/user/current').success(function(data, status) {
            d.resolve(data);
        }).error(function(data, status) {
            d.reject(status);
        });
        return d.promise;
    };
}]);
