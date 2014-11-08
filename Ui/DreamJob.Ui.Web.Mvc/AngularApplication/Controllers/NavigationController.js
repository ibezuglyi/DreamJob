angular
.module('djapp')
    .controller('NavigationController', ["$scope", "djClientApi", "AlertsService", "offersCountService", function ($scope, djClientApi, alertsService, offersCountService) {

        var onGetNotificationSuccess = function (data, status) {
            $scope.offersCountService.NewOffersCount = data;
        };

        $scope.Notification = {
            NewOffersCount: 0
        };
        $scope.closeAlert = function (index) {
            alertsService.alerts.splice(index, 1);
        };
        $scope.alertsService = alertsService;
        $scope.offersCountService = offersCountService;
        
        $scope.init = function () {
            this.getNotificationCount();
        };

        $scope.getNotificationCount = function () {
            djClientApi.getNewOffersCount()
            .success(onGetNotificationSuccess);
        };

    }]);
