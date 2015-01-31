'use strict';
app.controller('dashboardController', ['$scope', 'dashboardService', 'common', function ($scope, dashboardService, common) {
    dashboardService.getDashboardData().then(function(response) {
        $scope.dashboardData = response.data;
        _($scope.dashboardData).forEach(function(item) {
            _(item.ExpectedDates).forEach(function(i) {
                i.Date = common.convertToDDMMYYYY(i.Date);
                _(i.Requestors).forEach(function(req) {
                    req.ExpectedDate = common.convertToDDMMYYYY(req.ExpectedDate);
                    req.DeliveredDate = common.convertToDDMMYYYY(req.DeliveredDate);
                });
                
                _(i.IntrestedDonors).forEach(function (donor) {
                    donor.SmsSentDate = common.convertToDDMMYYYY(donor.SmsSentDate);
                    donor.RepliedOn = common.convertToDDMMYYYY(donor.RepliedOn);
                    donor.AppointmentScheduled = common.convertToDDMMYYYY(donor.AppointmentScheduled);
                    donor.DonatedDate = common.convertToDDMMYYYY(donor.DonatedDate);
                });
            });
        });
    });
    $scope.selectedDonor = function (donor) {
        $scope.chosenDonor = donor;
        console.log(donor);
    };
    $scope.updateDonor = function (donor) {
        console.log(donor);
    };
    
}]);