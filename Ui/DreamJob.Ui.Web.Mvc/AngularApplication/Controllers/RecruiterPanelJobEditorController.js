var RecruiterPanelJobEditorController = function ($scope, $modalInstance, jobOffer) {
    $scope.JobOffer = {
        NameSubject: '',
        Description: '',
        MinSalary: jobOffer.MinSalary,
        MaxSalary: '',
        MatchesDeveloperRequirements: false,
        Subject: jobOffer.Title,
    };

    $scope.IsOfferValid = function () {
        return !($scope.JobOffer.Subject.length > 0 &&
            $scope.JobOffer.Description.length > 0 &&
            $scope.JobOffer.MinSalary.length > 0 &&
            $scope.JobOffer.MatchesDeveloperRequirements === true);
    }

    $scope.ok = function () {
        $modalInstance.close($scope.JobOffer);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('canceled');
    };
};
