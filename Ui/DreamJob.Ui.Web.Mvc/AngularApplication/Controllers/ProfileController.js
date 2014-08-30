(function (messages) {
    window.djApplication.controller('ProfileController', function ($scope, $http) {
        $scope.profile = null;
        $scope.alerts = [];;
        $scope.closeAlert = function (index) {
            $scope.alerts.splice(index, 1);
        };

        $scope.saveProfile = function () {
            var profileData =
            {
                profile: $scope.profile
            };
            $http({
                url: "profile/CurrentUser",
                method: "POST",
                data: profileData
            }).success(function (response) {
                $scope.alerts.push(messages.updateSucceded);
            });
        };
        $scope.init = function () {
            $http.get('profile/CurrentUser')
                 .success(function (response) {
                     $scope.profile = response;

                 });
        };
    });
}(window.LocalizationTexts));


