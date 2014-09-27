var RecruiterPanelJobEditorController = function ($scope, $modalInstance, jobOffer) {
    var minSalary = jobOffer.MinSalary;
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
            $scope.JobOffer.Description &&
            $scope.JobOffer.Description.length > 0 &&
            $scope.JobOffer.MatchesDeveloperRequirements === true);
    }

    $scope.ok = function () {
        $modalInstance.close($scope.JobOffer);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('canceled');
    };
};
