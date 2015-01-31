'use strict';
app.factory('donorService', ['$http', '$q', 'localStorageService', 'ngAuthSettings', function ($http, $q, localStorageService, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var donorServiceFactory = {};

    var loadSearch = function () {
        return $http.get(serviceBase + 'api/donors/loadSearch').then(function (response) {
            return response;
        });
    };
    
    //?pincode=12&bloodGroup='A'&pincodeRange=22
    var searchDonor = function (pincode, bloodGroup, pincodeRange) {
        return $http.get(serviceBase + 'api/donors/searchdonors?pincode=' + pincode + '&bloodGroup='+ bloodGroup +'&pincodeRange=' + pincodeRange).then(function (response) {
            return response;
        });
    };

    var sendChosenDonor = function(donors) {
        return $http.post(serviceBase + 'api/donors/PostSendSms', donors).then(function (response) {
            return response;
        });
    };
    
    donorServiceFactory.loadSearch = loadSearch;
    donorServiceFactory.searchDonor = searchDonor;
    donorServiceFactory.sendChosenDonor = sendChosenDonor;
    return donorServiceFactory;
}]);
