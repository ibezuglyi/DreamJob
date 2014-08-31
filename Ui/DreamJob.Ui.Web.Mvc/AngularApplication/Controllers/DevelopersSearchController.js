(function() {
    window.djApplication.controller('DevelopersSearchController', function($scope, $http) {
        $scope.searchString = "";
        $scope.searchCity = "";
        $scope.developers = [];

        $scope.searchForDevelopers = function() {
            $http.get("profile/search", {
                    params: {
                        technology: $scope.searchString,
                        city: $scope.searchCity
                    }
                })
                .then(function(resp) {
                    $scope.developers = resp.data;
                });
        };

        $scope.getCities = function() {
            $scope.getCities = function(val) {
                return $http.get("profile/GetCities", {
                    params: { cityPart: val }
                }).then(function(resp) {
                    return resp.data;
                });
            };
        };

    });
}());
