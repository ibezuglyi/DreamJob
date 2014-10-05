var AcceptOfferController = function ($scope, $modalInstance) {
    $scope.AcceptedOffer = {
        Id:'',
        Name: '',
        Note: '',
        ContactMethod: '',
        Email: '',
        Phone: ''
    };



    $scope.ok = function () {
        $modalInstance.close($scope.AcceptedOffer);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('canceled');
    };
};