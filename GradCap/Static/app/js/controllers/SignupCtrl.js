'use strict';

angular.module('gradCapApp.controllers').controller('SignUpCtrl', ['$scope', '$location', 'AccountService',
    function($scope, $location, Account) {

    $scope.submit = function() {
        var req = {
            Email: $scope.email,
            Password: $scope.password,
            ConfirmPassword: $scope.password
        };
        Account.register(req).then(function(success) {
            alert('Yes');
            $location.path('/campus');
        }, function(error) {
            alert('Failed');
        });
    };
}]);
