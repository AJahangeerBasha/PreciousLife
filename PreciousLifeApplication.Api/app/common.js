
app.factory('common', [function () {
    var commonServiceFactory = {};

    var convertToDDMMYYYY = function (input) {
        if (input == undefined)
            return null;
        return moment(input).format("DD/MM/YYYY");
    };

    commonServiceFactory.convertToDDMMYYYY = convertToDDMMYYYY;
    return commonServiceFactory;
}]);
