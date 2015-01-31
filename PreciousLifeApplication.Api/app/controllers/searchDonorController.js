'use strict';
app.controller('searchDonorController', ['$scope', 'donorService', function ($scope, donorService) {

    $scope.selectedCenter = "";
    $scope.showResults = false;
    $scope.searchDonors = function() {
        console.log("inside search fn");
        console.log($scope.selectedCenter);
        console.log($scope.selectedBloodGroup);
        console.log($scope.pincodeRange);


        donorService.searchDonor($scope.selectedCenter.Pincode, $scope.selectedBloodGroup.type, $scope.pincodeRange).then(function(response) {
            console.log(response.data);
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
    
    //authService.login($scope.loginData).then(function (response) {
    //    //$location.path('/dashbaord');
    //},
    // function (err) {
    //     $scope.message = err.error_description;
    // });
    
    $scope.searchResultDonors = {        
        Donors: [
                  {
                      Id: 1,
                      Name: "DonorName1",
                      Address: "31, First Street, KoperKharanae",
                      City: "Mumbai",
                      PinCode: 123456,
                      DateOfBirth: "12/12/1980",
                      ContactNumber: "123456789",
                      AlternateNumber: "987654123",
                      Weight: "65Kg"
                  }, {
                      Id: 2,
                      Name: "DonorName2",
                      Address: "28, Second Street, KoperKharanae",
                      City: "Mumbai",
                      PinCode: 123444,
                      DateOfBirth: "10/10/1980",
                      ContactNumber: "123456789",
                      AlternateNumber: "987654123",
                      Weight: "65Kg"
                  }, {
                      Id: 3,
                      Name: "DonorName3",
                      Address: "31, First Street, KoperKharanae",
                      City: "Mumbai",
                      PinCode: 123456,
                      DateOfBirth: "12/12/1980",
                      ContactNumber: "123456789",
                      AlternateNumber: "987654123",
                      Weight: "65Kg"
                  }, {
                      Id: 4,
                      Name: "DonorName4",
                      Address: "28, Second Street, KoperKharanae",
                      City: "Mumbai",
                      PinCode: 123444,
                      DateOfBirth: "10/10/1980",
                      ContactNumber: "123456789",
                      AlternateNumber: "987654123",
                      Weight: "65Kg"
                  }
        ]
    };
}]);