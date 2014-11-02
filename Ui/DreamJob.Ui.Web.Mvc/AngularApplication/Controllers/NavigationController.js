angular
.module('djapp')
    .controller('NavigationController', ["$scope", "djClientApi", "AlertsService", function ($scope, djClientApi, alertsService) {

        var onGetNotificationSuccess = function (data, status) {
            $scope.Notification.NewOffersCount = data;
        };

        $scope.Notification = {
            NewOffersCount: 0
        };
        $scope.closeAlert = function (index) {
            alertsService.alerts.splice(index, 1);
        };
        $scope.alertsService = alertsService;
        
        $scope.init = function () {
            this.getNotificationCount();
        };

        $scope.getNotificationCount = function () {
            djClientApi.getNewOffersCount()
            .success(onGetNotificationSuccess);
        };

    }]);
