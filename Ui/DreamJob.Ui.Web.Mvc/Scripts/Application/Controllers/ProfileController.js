angular.module('djpa', [])
    .controller('ProfileController', ['$scope',
        function ($scope) {
            $scope.testText = 'test text goes here';

            $scope.foo = function () {
                return "return from foo()";
            };
        }]);