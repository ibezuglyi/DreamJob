window.djApplication
    .controller('RecruiterPanelController', function ($scope, $http, $modal) {

        $scope.JobOffer = {
            DeveloperId: 0,
        };

        $scope.init = function (developerId, salary, title) {
            $scope.JobOffer.DeveloperId = developerId;
            $scope.JobOffer.MinSalary = salary;
            $scope.JobOffer.Title = title;
        };

        $scope.prepareJobOffer = function () {
            var modalInstance = $modal.open({
                templateUrl: 'myModalContent.html',
                controller: RecruiterPanelJobEditorController,
                resolve: {
                    jobOffer: function() {
                        return $scope.JobOffer;
                    }
                }
            });

            modalInstance.result.then(function (result) {
                result.DeveloperId = $scope.JobOffer.DeveloperId;
                sendJobOffer(result);
            }, function () {
                // canceled
            });
        };

        var sendJobOffer = function (offer) {
            $http.post('/offer/send', offer)
                .success(function () {
                    alert('success');
                })
                .error(function () {
                    alert('error');
                });

        };
    });


