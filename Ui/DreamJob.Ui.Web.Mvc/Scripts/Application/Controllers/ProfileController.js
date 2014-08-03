angular.module('djpa', [])
    .controller('ProfileController', function ($scope, $http) {

        $scope.foo = function () {
            $http.get('api/offers').success(function (response) {
                alert(response);
            });
        }


    });