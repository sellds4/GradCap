'use strict';

angular.module('gradCapApp.services').service('SchoolService', ['$q', '$http', function($q, $http) {
    
    this.getAllSchools = function() {
        var d = $q.defer();
        $http.get('/api/School').success(function(data) {
            d.resolve(data);
        }).error(function(error) {
            d.reject(error);
        });
        return d.promise;
    };

}]);
