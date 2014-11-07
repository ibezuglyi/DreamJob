angular
    .module('djapp')
    .controller('OfferController', function($scope, $modal, djClientApi) {

        $scope.offers = [];
        $scope.offer = null;
        $scope.offerComments = [];
        $scope.comment = {
            text: ''
        };
        $scope.IsOfferDetailsMode = false;

        $scope.init = function(currentUser) {
            $scope.currentUser = angular.fromJson(currentUser);

            djClientApi.getMyOffers()
                .success(function(response) {
                    $scope.offers = response;
                });
        };
        $scope.switchToOfferList = function() {
            $scope.IsOfferDetailsMode = false;
        };
        $scope.details = function(offer) {
            $scope.deselectOffers();
            $scope.comment.text = '';
            djClientApi.offerDetails(offer.Id)
                .success(function(response) {
                    $scope.offer = response;
                    $scope.IsOfferDetailsMode = true;
                    $scope.offerComments = response.JobOfferComments;
                    $scope.offer.IsLocked = isOfferLocked(response.OfferStatus);
                });
        };
        $scope.deselectOffers = function() {
            angular.forEach($scope.offers, function(offer, k) {
                offer.selected = false;
            });
        };
        $scope.addOfferComment = function() {
            var data = {
                offerId: $scope.offer.Id,
                text: $scope.comment.text
            };
            djClientApi.addComment(data)
                .success(function(response) {
                    if (response.IsSuccess) {
                        $scope.offerComments.push(response.Data);
                        $scope.comment.text = '';
                    }
                });
        };

        $scope.cancelOffer = function() {
            var data = {
                id: $scope.offer.Id,
            };
            djClientApi.cancelOffer(data)
                .success(function(response) {
                    updateJobOfferStatus(response);
                });
        };

        $scope.acceptOffer = function() {
            var modalInstance = $modal.open({
                templateUrl: 'acceptOfferTemplate.html',
                controller: AcceptOfferController
            });


            modalInstance.result.then(function(result) {
                result.Id = $scope.offer.Id,
                    djClientApi.acceptOffer(result)
                        .success(function(response) {
                            updateJobOfferStatus(response);
                        });
            }, function() {
                // canceled
            });
        };

        $scope.rejectOffer = function() {
            var data = {
                id: $scope.offer.Id,
            };
            djClientApi.rejectOffer(data)
                .success(function(response) {
                    updateJobOfferStatus(response);
                });
        };


        var updateJobOfferStatus = function(response) {
            if (response.IsSuccess) {
                $scope.offer.IsLocked = true;
            } else {
                alert(response.Errors[0]);
            }
        };

        var isOfferLocked = function(offerStatus) {
            return offerStatus === "Rejected"
                || offerStatus === "Accepted"
                || offerStatus === "Canceled";
        };

    });