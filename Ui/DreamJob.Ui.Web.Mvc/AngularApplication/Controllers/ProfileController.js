(function (messages) {
    window.djApplication.controller('ProfileController', function ($scope, $http) {
        $scope.profile = { City: "" };
        $scope.preferredTitle = messages.preferredTitle;
        $scope.minSalary = messages.minSalary;
        $scope.alerts = [];
        $scope.closeAlert = function (index) {
            $scope.alerts.splice(index, 1);
        };

        $scope.saveProfile = function () {
            var profileData = { profile: $scope.profile };
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

        $scope.getCities = function(val) {
            return $http.get("profile/GetCities", {
                params: { cityPart: val }
            }).then(function(resp) {
                return resp.data;
            });
        };
    });
}(window.LocalizationTexts));


