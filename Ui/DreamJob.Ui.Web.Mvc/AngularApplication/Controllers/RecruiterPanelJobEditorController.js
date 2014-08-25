var RecruiterPanelJobEditorController = function ($scope, $modalInstance) {
    $scope.JobOffer = {
        Subject: '',
        Description: '',
        MinSalary: '',
        MaxSalary: '',
        MatchesDeveloperRequirements: false
    };

    $scope.ok = function () {
        $modalInstance.close($scope.JobOffer);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('canceled');
    };
};