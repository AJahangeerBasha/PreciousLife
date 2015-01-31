'use strict';
app.factory('donorService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var donorServiceFactory = {};

    var loadSearch = function () {

        return $http.post(serviceBase + 'api/donors/loadSearch').then(function (response) {
            return response;
        });
    };
    donorServiceFactory.loadSearch = loadSearch;
    return donorServiceFactory;
}]);