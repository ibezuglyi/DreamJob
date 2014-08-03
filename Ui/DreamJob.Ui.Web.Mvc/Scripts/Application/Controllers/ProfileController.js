angular.module('djpa', [])
    .controller('ProfileController', function ($scope, $http) {

        $scope.foo = function () {
            $http.get('offers/get').success(function (response) {
                alert(response);
            });
        }
    });