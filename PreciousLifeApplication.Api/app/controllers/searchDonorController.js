'use strict';
app.controller('searchDonorController', ['$scope', '$location', 'donorService', function ($scope, $location, donorService) {

    $scope.selectedCenter = "";
    $scope.showResults = false;
    $scope.searchDonors = function() {
        donorService.searchDonor($scope.selectedCenter.Pincode, $scope.selectedBloodGroup.type, $scope.pincodeRange).then(function(response) {
            $scope.searchResultDonors = response.data;
        });
        $scope.showResults = true;
    };
    $scope.pincodeRange = 10;
    $scope.bloodGroupType = [ { type:'A', Id: 1}, { type:'AB', Id: 2},{ type:'B', Id: 3},{ type:'O', Id: 4}];
    $scope.selectedBloodGroup = "";
    donorService.loadSearch().then(function(response) {
        $scope.CollectionCenters = response.data;
    });

    $scope.sendSms = function () {
        $location.path('/smssent');
        console.log($scope.searchResultDonors);
        //donorService.sendChosenDonor($scope.searchResultDonors).then(function(response) {
        //    console.log("sent sms");
        //});
    };
    //authService.login($scope.loginData).then(function (response) {
    //    //$location.path('/dashbaord');
    //},
    // function (err) {
    //     $scope.message = err.error_description;
    // });

    //$scope.searchResultDonors = {        
    //    Donors: [
    //              {
    //                  Id: 1,
    //                  Name: "DonorName1",
    //                  Address: "31, First Street, KoperKharanae",
    //                  City: "Mumbai",
    //                  PinCode: 123456,
    //                  DateOfBirth: "12/12/1980",
    //                  ContactNumber: "123456789",
    //                  AlternateNumber: "987654123",
    //                  Weight: "65Kg"
    //              }, {
    //                  Id: 2,
    //                  Name: "DonorName2",
    //                  Address: "28, Second Street, KoperKharanae",
    //                  City: "Mumbai",
    //                  PinCode: 123444,
    //                  DateOfBirth: "10/10/1980",
    //                  ContactNumber: "123456789",
    //                  AlternateNumber: "987654123",
    //                  Weight: "65Kg"
    //              }, {
    //                  Id: 3,
    //                  Name: "DonorName3",
    //                  Address: "31, First Street, KoperKharanae",
    //                  City: "Mumbai",
    //                  PinCode: 123456,
    //                  DateOfBirth: "12/12/1980",
    //                  ContactNumber: "123456789",
    //                  AlternateNumber: "987654123",
    //                  Weight: "65Kg"
    //              }, {
    //                  Id: 4,
    //                  Name: "DonorName4",
    //                  Address: "28, Second Street, KoperKharanae",
    //                  City: "Mumbai",
    //                  PinCode: 123444,
    //                  DateOfBirth: "10/10/1980",
    //                  ContactNumber: "123456789",
    //                  AlternateNumber: "987654123",
    //                  Weight: "65Kg"
    //              }
    //    ]
    //};
}]);