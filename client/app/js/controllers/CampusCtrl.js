'use strict';

angular.module('gradCapApp.controllers').controller('CampusCtrl', ['$scope', '$location', 'LoginService', 'SchoolService', 'AccountService',
    function($scope, $location, Login, School, Account) {

    var init = function() {
        School.getAllSchools().then(function(success) {
            $scope.schools = success;
        });
        Account.getFavoriteSchools().then(function(success) {
            $scope.favoriteSchools = success;
        })
    };
    
    $scope.logout = function() {
        Login.logout().then(function(success) {
            $location.path('/');
        }, function(error) {
            console.log(error);
            alert('Failed');
        });
    };

    $scope.addFavorite = function(school) {
        var req = {
            SchoolName: school,
            IsFavoriteSchool: true
        };
        Account.addViewedSchool(req).then(function(success) {
            alert('success');
        }, function(error) {
            console.log(error);
        });
    };

    init();

}]);
