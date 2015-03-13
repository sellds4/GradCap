'use strict';
 
var gradCapApp = angular.module('gradCapApp', [
    'ngRoute',
    'ngCookies',
    'gradCapApp.controllers',
    'gradCapApp.services',
    'gradCapApp.directives',
    'LocalStorageModule'
]);

angular.module('gradCapApp.controllers', []);
angular.module('gradCapApp.directives', []);
angular.module('gradCapApp.services', []);

gradCapApp.config(function($routeProvider, $locationProvider) {
    var loginResolve = ['$q', '$location', 'localStorageService', function($q, $location, localStorage) {
        if (localStorage.get('sessionData')) {
            return $q.when(true);
        } else {
            return $q.reject($location.path('/login'));
        }
    }];
    
    $routeProvider
        .when('/', {
            templateUrl: './Static/app/partials/prelogin.html',
            controller: ''
        })
        .when('/login', {
            templateUrl: './Static/app/partials/login.html',
            controller: 'LoginCtrl',
            resolve: {
                loggedInResolve: ['$q', '$location', 'localStorageService', function($q, $location, localStorage) {
                    if (!localStorage.get('sessionData')) {
                        return $q.when(true);
                    } else {
                        return $q.reject($location.path('/campus'));
                    }
                }]
            }
        })
        .when('/signup', {
            templateUrl: './Static/app/partials/signup.html',
            controller: 'SignUpCtrl'
        })
        .when('/campus', {
            templateUrl: './Static/app/partials/campus.html',
            controller: 'CampusCtrl',
            resolve:{
                loginResolve: loginResolve
            }
        })
        .otherwise({
            redirectTo: '/'
        });

    $locationProvider.html5Mode(true);
});

gradCapApp.run(function ($http, $cookies) {
    $http.defaults.headers.common['X-XSRF-TOKEN'] = $cookies['XSRF-TOKEN'];
});

gradCapApp.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});