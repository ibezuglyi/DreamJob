(function (messages) {
    angular
    .module('djapp')
    .controller('RecruiterPanelController', function ($scope, $http, $modal, AlertsService, djClientApi) {

        $scope.JobOffer = {
            DeveloperId: 0,
        };

        $scope.init = function (developerId, salary, title) {
            $scope.JobOffer.DeveloperId = developerId;
            $scope.JobOffer.MinSalary = salary;
            $scope.JobOffer.Title = title;
        };

        $scope.prepareJobOffer = function () {
            var modalInstance = $modal.open({
                templateUrl: 'myModalContent.html',
                controller: RecruiterPanelJobEditorController,
                resolve: {
                    jobOffer: function () {
                        return $scope.JobOffer;
                    }
                }
            });

            modalInstance.result.then(function (result) {
                result.DeveloperId = $scope.JobOffer.DeveloperId;
                sendJobOffer(result);
            }, function () {
                // canceled
            });
        };

        var sendJobOffer = function (offer) {
            djClientApi.sendOffer(offer)
                .success(function () {
                    AlertsService.alerts = [messages.offerSendSuccess];
                })
                .error(function () {
                    AlertsService.alerts = [messages.offerSendFailed];
                });
        };
    });
}(window.LocalizationTexts));
