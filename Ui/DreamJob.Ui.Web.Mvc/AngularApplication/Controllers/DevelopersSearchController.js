angular
    .module('djapp')
    .controller('DevelopersSearchController', function ($scope, $http, djClientApi) {
        $scope.searchString = "";
        $scope.searchCity = "";
        $scope.developers = [];
        var htmlCleanerRxp = /(<([^>]+)>)/ig;

        $scope.searchForDevelopers = function () {
            djClientApi
                .searchProfile($scope.searchString.replace(htmlCleanerRxp, ''), $scope.searchCity.replace(htmlCleanerRxp, ''))
                .then(function (resp) {
                    $scope.developers = resp.data;
                });
        };

        $scope.getCities = function (val) {
            return djClientApi.getCities(val)
                .then(function (resp) {
                    return resp.data;
                });
        };
    });