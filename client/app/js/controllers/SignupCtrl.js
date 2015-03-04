'use strict';

angular.module('gradCapApp.controllers').controller('SignUpCtrl', ['$scope', '$location', 'AccountService',
    function($scope, $location, Account) {

    $scope.submit = function() {
        var s = $scope,
            req = {
            FirstName: s.firstname,
            LastName: s.lastname,
            HomeState: s.homestate,
            Email: s.email,
            Password: s.password,
            ConfirmPassword: s.password
        };
        Account.register(req).then(function(success) {
            alert('Yes');
            $location.path('/campus');
        }, function(error) {
            alert('Failed');
        });
    };
}]);
