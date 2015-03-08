'use strict';

angular.module('gradCapApp.services').service('AccountService', ['$q', '$http', function($q, $http) {
    
    this.register = function(req) {
        var d = $q.defer();
        $http.post('/api/Account/Register', req).success(function(data) {
            d.resolve(data);
        }).error(function(error) {
            d.reject(error);
        });
        return d.promise;
    };

    this.getFavoriteSchools = function() {
        var d = $q.defer();
        $http.get('/api/Account/GetFavoriteSchools').success(function(data) {
            d.resolve(data);
        }).error(function(error) {
            d.reject(error);
        });
        return d.promise;
    };

    this.addViewedSchool = function(req) {
        var d = $q.defer();
        $http.post('/api/Account/AddViewedSchool', req).success(function(data) {
            d.resolve(data);
        }).error(function(error) {
            d.reject(error);
        });
        return d.promise;
    };

    this.removeFavoriteSchool = function(req) {
        var d = $q.defer();
        $http.post('api/Account/RemoveFavoriteSchool', req).success(function(data) {
            d.resolve(data);
        }).error(function(error) {
            d.reject(error);
        });
        return d.promise;
    };

}]);
