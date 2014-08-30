window.djApplication.controller('ProfileController', function ($scope, $http) {
    $scope.profile = null;
    $scope.saveProfile = function () {
        $http({
            url: "profile/CurrentUser",
            method: "POST",
            params: $scope.profile
        })
            .success(function (response) {

        });;
    };
    $scope.init = function () {
        $http.get('profile/CurrentUser')
             .success(function (response) {
                 $scope.profile = response;
             });
    };
});
