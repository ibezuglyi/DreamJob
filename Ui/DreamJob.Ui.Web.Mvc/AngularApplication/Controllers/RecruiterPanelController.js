angular.module('djapp', ['mm.foundation'])
    .controller('RecruiterPanelController', function ($scope, $http, $modal) {

        $scope.init = function () { };

        $scope.prepareJobOffer = function () {
            var modalInstance = $modal.open({
                templateUrl: 'myModalContent.html',
                controller: RecruiterPanelJobEditorController
            });

            modalInstance.result.then(function (result) {
            }, function () {
                alert('canceled');
                // canceled
            });
        };
    });


