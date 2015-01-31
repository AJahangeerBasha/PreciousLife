'use strict';
app.factory('dashboardService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var dashboardServiceFactory = {};

    var getDashboardData = function () {
        return $http.get(serviceBase + 'api/dashboard/dashboarddata').then(function (response) {
            return response;
        });
    };
    
    
    dashboardServiceFactory.getDashboardData = getDashboardData;
    return dashboardServiceFactory;
}]);
