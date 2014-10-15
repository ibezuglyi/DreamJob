(function () {
    var application = angular.module('djapp');

    application.controller('NavigationController', ["$scope", "djClientApi", function ($scope, djClientApi) {

        $scope.Notification = {
            NewOffersCount: 0
        };

        $scope.init = function () {
            this.getNotificationCount();
        }


        $scope.getNotificationCount = function () {
            djClientApi.getNewOffersCount()
            .success(function (data, status) { $scope.Notification.NewOffersCount = data });
        };

    }]);

})();