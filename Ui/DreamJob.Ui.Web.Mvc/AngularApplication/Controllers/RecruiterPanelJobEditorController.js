var RecruiterPanelJobEditorController = function ($scope, $modalInstance) {
    $scope.JobOffer = {
        Subject: '',
        Description: '',
        MinSalary: '',
        MaxSalary: '',
        MatchesDeveloperRequirements: false
    };

    $scope.ok = function () {
        alert('ok');
        $modalInstance.close($scope.JobOffer);
    };

    $scope.cancel = function () {
        alert('cancel');
        $modalInstance.dismiss('canceled');
    };
};