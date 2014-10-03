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
            .success(function () {
                $scope.alerts = [messages.updateSucceded];
            });
        };

        $scope.init = function () {
            djClientApi.getProfile()
                    .success(function (response) {
                        $scope.profile = response;

                    });
        };
        $scope.deleteSkill = function (indx) {
            $scope.profile.Skills.splice(indx, 1);
        };
        $scope.addSkill = function () {
            $scope.profile.Skills.splice(0, 0, { SelfRate: 0, Description: "" });
        };

        $scope.getCities = function (val) {
            djClientApi.getCities(val)
                        .then(function (resp) {
                            return resp.data;
                        });
        };
    });
}(window.LocalizationTexts));


