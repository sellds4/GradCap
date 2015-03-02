'use strict';

angular.module('gradCapApp.controllers').controller('CampusCtrl', ['$scope', '$location', 'LoginService', 'SchoolService',
    function($scope, $location, Login, School) {

    var init = function() {
        School.getAllSchools().then(function(success) {
            $scope.schools = success;
        });
    };
    
    $scope.logout = function() {
        Login.logout().then(function(success) {
            $location.path('/');
        }, function(error) {
            console.log(error);
            alert('Failed');
        });
    };

    init();

}]);
