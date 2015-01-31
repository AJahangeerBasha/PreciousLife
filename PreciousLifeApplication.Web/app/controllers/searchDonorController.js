'use strict';
app.controller('searchDonorController', ['$scope', function ($scope) {

    $scope.showResults = false;
    $scope.searchDonors = function() {
        console.log("isnide search fn");
        $scope.showResults = true;
    };
    
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