(function(messages) {
    angular
        .module('djapp')
        .controller('ProfileController', function ($scope, djClientApi, AlertsService) {
            $scope.profile = { City: "" };
            $scope.preferredTitle = messages.preferredTitle;
            $scope.minSalary = messages.minSalary;
            
            
            $scope.isCityValid = function() {
                return /(<|>|\/|"|'|;|!|@|#)/.test($scope.profile.City) === false;
            };


            $scope.saveDeveloperProfile = function() {
                djClientApi.saveDeveloperProfile($scope.profile)
                    .success(function() {
                        AlertsService.alerts = [messages.updateSucceded];
                    });
            };

            $scope.saveRecruiterProfile = function() {
                djClientApi.saveRecruiterProfile($scope.profile)
                    .success(function() {
                        AlertsService.alerts = [messages.updateSucceded];
                    });
            };

            $scope.init = function() {
                djClientApi.getProfile()
                    .success(function(response) {
                        $scope.profile = response.Data;

                    });
            };
            $scope.deleteSkill = function(indx) {
                $scope.profile.Skills.splice(indx, 1);
            };
            $scope.addSkill = function() {
                $scope.profile.Skills.splice(0, 0, { SelfRate: 0, Description: "" });
            };

            $scope.getCities = function(val) {
                djClientApi.getCities(val)
                    .then(function(resp) {
                        return resp.data;
                    });
            };
        });
}(window.LocalizationTexts));