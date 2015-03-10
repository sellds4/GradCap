'use strict';

angular.module('gradCapApp.controllers').controller('CampusCtrl', ['$scope', '$location', 'LoginService', 'SchoolService', 'AccountService',
    function($scope, $location, Login, School, Account) {

    angular.extend($scope, {
        data: {
            view: 'favorites'
        }
    });
    
    var viewedSchoolArray = [];

    function init() {
        Account.getViewedSchools().then(function(success) {
            $scope.viewedSchools = success;
            for(var i=0; i < success.length; i++) {
                viewedSchoolArray.push(success[i].Name);
            }
            School.getAllSchools().then(function(success) {
                $scope.allSchools = success;
            });
        });
        Account.getFavoriteSchools().then(function(success) {
            $scope.favoriteSchools = success;
        });
    };

    $scope.isUnviewed = function(school) {
        if(viewedSchoolArray.indexOf(school.Name) === -1) {
            return school;
        }
    };

    $scope.changeView = function(view) {
        console.log($scope, view)
        $scope.data.view = view;
    };
    
    $scope.logout = function() {
        Login.logout().then(function(success) {
            $location.path('/');
        }, function(error) {
            console.log(error);
            alert('Failed');
        });
    };

    $scope.viewSchool = function(school, isFavorite) {
        var req = {
            SchoolName: school,
            IsFavoriteSchool: isFavorite
        };
        Account.addViewedSchool(req).then(function(success) {
            alert('success');
        }, function(error) {
            console.log(error);
        });
    };

    $scope.addFavorite = function(school) {
        var req = {
            SchoolName: school
        };
        Account.addFavoriteSchool(req).then(function(success) {
            alert('added');
        }, function(error) {
            console.log(error);
        });
    };

    $scope.removeFavorite = function(school) {
        var req = {
            SchoolName: school
        };
        Account.removeFavoriteSchool(req).then(function(success) {
            alert('removed');
        }, function(error) {
            console.log(error);
        });
    };

    init();

    // $scope.apply();

}]);
