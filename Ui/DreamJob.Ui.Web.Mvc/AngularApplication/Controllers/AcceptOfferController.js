var AcceptOfferController = function ($scope, $modalInstance) {
    $scope.AcceptedOffer = {
        Id:'',
        Name: '',
        Note: '',
        ContactMethod: '',
        Email: '',
        Phone: ''
    };

    $scope.IsOfferValid = function () {
        return !(
                 $scope.AcceptedOffer.Name.length > 0 &&
                 $scope.AcceptedOffer.ContactMethod.length > 0 &&
                ($scope.AcceptedOffer.Email.length > 0 ||
                 $scope.AcceptedOffer.Phone.length > 0));
    }

    $scope.ok = function () {
        $modalInstance.close($scope.AcceptedOffer);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('canceled');
    };
};