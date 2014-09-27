window.djApplication.controller('DevelopersSearchController', function ($scope, $http, djClientApi) {
    $scope.searchString = "";
    $scope.searchCity = "";
    $scope.developers = [];

    $scope.searchForDevelopers = function () {
        djClientApi
            .searchProfile($scope.searchString, $scope.searchCity)
            .then(function (resp) {
                $scope.developers = resp.data;
            });
    };

    $scope.getCities = function () {
        $scope.getCities = function (val) {
            return djClientApi.getCities(val)
                    .then(function (resp) {
                        return resp.data;
                    });
        };
    };
});

