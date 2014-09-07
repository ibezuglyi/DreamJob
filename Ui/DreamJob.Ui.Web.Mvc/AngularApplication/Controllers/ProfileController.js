(function (messages) {
    window.djApplication.controller('ProfileController', function ($scope, djClientApi) {
        $scope.profile = { City: "" };
        $scope.preferredTitle = messages.preferredTitle;
        $scope.minSalary = messages.minSalary;
        $scope.alerts = [];
        $scope.closeAlert = function (index) {
            $scope.alerts.splice(index, 1);
        };

        $scope.saveProfile = function () {
            djClientApi.saveProfile($scope.profile)
            .success(function (response) {
                $scope.alerts.push(messages.updateSucceded);
            });
        };

        $scope.init = function () {
            djClientApi.getProfile()
                    .success(function (response) {
                        $scope.profile = response;
                    });
        };

        $scope.getCities = function (val) {
            djClientApi.getCities(val)
                        .then(function (resp) {
                            return resp.data;
                        });
        };
    });
}(window.LocalizationTexts));


