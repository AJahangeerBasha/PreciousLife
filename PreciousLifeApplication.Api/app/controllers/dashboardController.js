'use strict';
app.controller('dashboardController', ['$scope', function ($scope) {
    $scope.items = ['hi', 'hey', 'hello'];

    $scope.dashboardData = {
        CollectionCenters:
        [
{
    Id: 1,
    Name: "CollectionCenter1",
    ExpectedDates: [
		{
		    ExpectedDate: "31/01/2015",
		    ExpectedQuantity: 900,
		    Requestors:
			[
				{
				    Id: 1,
				    Name: "ReqName1",
				    Patient: "Pat1",
				    ContactNumber: "987654321",
				    BloodGroup: "A",
				    Quantity: 300
				}, {
				    Id: 2,
				    Name: "ReqName2",
				    Patient: "Pat2",
				    ContactNumber: "123456789",
				    BloodGroup: "A+",
				    Quantity: 600
				}
			],
		    Donors:
			[
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
				}
			]
		}, {
		    ExpectedDate: "28/01/2015",
		    ExpectedQuantity: 700,
		    Requestors:
			[
				{
				    Id: 7,
				    Name: "ReqName7",
				    Patient: "Pat7",
				    ContactNumber: "987654321",
				    BloodGroup: "A",
				    Quantity: 300
				}, {
				    Id: 8,
				    Name: "ReqName8",
				    Patient: "Pat8",
				    ContactNumber: "123456789",
				    BloodGroup: "A+",
				    Quantity: 600
				}
			],
		    Donors:
			[
				{
				    Id: 9,
				    Name: "DonorName9",
				    Address: "31, First Street, KoperKharanae",
				    City: "Mumbai",
				    PinCode: 123456,
				    DateOfBirth: "12/12/1980",
				    ContactNumber: "123456789",
				    AlternateNumber: "987654123",
				    Weight: "65Kg"
				}, {
				    Id: 10,
				    Name: "DonorName10",
				    Address: "28, Second Street, KoperKharanae",
				    City: "Mumbai",
				    PinCode: 123444,
				    DateOfBirth: "10/10/1980",
				    ContactNumber: "123456789",
				    AlternateNumber: "987654123",
				    Weight: "65Kg"
				}
			]
		}
    ],

}, {
    Id: 1,
    Name: "CollectionCenter2",
    ExpectedDates: [
		{
		    ExpectedDate: "30/01/2015",
		    ExpectedQuantity: 600,
		    Requestors:
			[
				{
				    Id: 3,
				    Name: "ReqName3",
				    Patient: "Pat3",
				    ContactNumber: "987654321",
				    BloodGroup: "A",
				    Quantity: 300
				}, {
				    Id: 4,
				    Name: "ReqName4",
				    Patient: "Pat4",
				    ContactNumber: "123456789",
				    BloodGroup: "A+",
				    Quantity: 600
				}
			],
		    Donors:
			[
				{
				    Id: 5,
				    Name: "DonorName5",
				    Address: "31, First Street, KoperKharanae",
				    City: "Mumbai",
				    PinCode: 123456,
				    DateOfBirth: "12/12/1980",
				    ContactNumber: "123456789",
				    AlternateNumber: "987654123",
				    Weight: "65Kg"
				}, {
				    Id: 6,
				    Name: "DonorName6",
				    Address: "28, Secnd Street, KoperKharanae",
				    City: "Mumbai",
				    PinCode: 123444,
				    DateOfBirth: "10/10/1980",
				    ContactNumber: "123456789",
				    AlternateNumber: "987654123",
				    Weight: "65Kg"
				}
			]
		}
    ],
}
        ]
    }; //end of scope
    //$scope.popover = { title: 'Title', content: 'Hello Popover<br />This is a multiline message!' };
    $scope.selectedDonor = function(donor) {
        $scope.chosenDonor = donor;
        console.log(donor);
    };
    $scope.updateDonor = function(donor) {
        console.log(donor);
    };
}]);