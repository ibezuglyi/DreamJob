var RecruiterPanelJobEditorController = function ($scope, $modalInstance) {
    $scope.JobOffer = {
        Subject: '',
        Description: '',
        MinSalary: '',
        MaxSalary: '',
        MatchesDeveloperRequirements: false
    };

    $modalInstance.ok = function () {
        alert('ok');
        $modalInstance.close($scope.JobOffer);
    };

    $modalInstance.cancel = function () {
        $modalInstance.close('canceled');

    };
};