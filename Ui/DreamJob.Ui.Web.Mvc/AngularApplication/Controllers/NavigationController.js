angular
.module('djapp')
    .controller('NavigationController', ["$scope", "djClientApi", function ($scope, djClientApi) {

        var onGetNotificationSuccess = function (data, status) {
            $scope.Notification.NewOffersCount = data;
        };

        $scope.Notification = {
            NewOffersCount: 0
        };

        $scope.init = function () {
            this.getNotificationCount();
        };

        $scope.getNotificationCount = function () {
            djClientApi.getNewOffersCount()
            .success(onGetNotificationSuccess);
        };

    }]);
