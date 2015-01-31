'use strict';

var app = angular.module('app', ['ngRoute', 'ngAnimate', 'ngSanitize', 'mgcrea.ngStrap', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {
    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });
    $routeProvider.when("/dashboard", {
        controller: "dashboardController",
        templateUrl: "/app/views/dashboard.html"
    });
    $routeProvider.when("/searchDonor", {
        controller: "searchDonorController",
        templateUrl: "/app/views/searchDonor.html"
    });
    $routeProvider.when("/facebook", {
        //controller: "searchDonorController",
        templateUrl: "/app/views/facebook.html"
    });
    $routeProvider.when("/smssent", {
        //controller: "searchDonorController",
        templateUrl: "/app/views/smssent.html"
    });
    $routeProvider.otherwise({ redirectTo: "/dashboard" });

});

var serviceBase = 'http://localhost:59463/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    
});

app.config(function($popoverProvider) {
    angular.extend($popoverProvider.defaults, {
        html: true
    });
});

app.config(function ($httpProvider) {
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
  });

app.run(['authService', function (authService) {

}]);    