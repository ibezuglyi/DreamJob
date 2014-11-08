(function (messages) {
    angular
        .module('djapp')
        .controller('OfferController', function ($scope, $modal, djClientApi, AlertsService, offersCountService) {
            var offerStatus = {
                New: "New",
                Accepted: "Accepted",
                Rejected: "Rejected",
                Canceled: "Canceled"
            };
            $scope.offers = [];
            $scope.offer = null;
            $scope.offerComments = [];
            $scope.comment = {
                text: ''
            };
            $scope.IsOfferDetailsMode = false;

            $scope.init = function (currentUser) {
                $scope.currentUser = angular.fromJson(currentUser);
                djClientApi.getMyOffers()
                    .success(function (response) {
                        $scope.offers = response;
                    });
            };
            $scope.switchToOfferList = function () {
                $scope.IsOfferDetailsMode = false;
            };
            $scope.details = function (offer) {
                $scope.comment.text = '';
                djClientApi.offerDetails(offer.Id)
                    .success(function (response) {
                        $scope.offer = response;
                        $scope.IsOfferDetailsMode = true;
                        $scope.offerComments = response.JobOfferComments;
                        $scope.offer.IsLocked = isOfferLocked(response.OfferStatus);
                    });
            };
            $scope.addOfferComment = function () {
                var data = {
                    offerId: $scope.offer.Id,
                    text: $scope.comment.text
                };
                djClientApi.addComment(data)
                    .success(function (response) {
                        if (response.IsSuccess) {
                            $scope.offerComments.push(response.Data);
                            $scope.comment.text = '';
                            AlertsService.alerts = [messages.commentSuccessfullyAdded];
                        }
                    });
            };

            $scope.cancelOffer = function () {
                var data = {
                    id: $scope.offer.Id,
                };
                djClientApi.cancelOffer(data)
                    .success(function (response) {
                        changeOfferStatus(offerStatus.Canceled);
                        AlertsService.alerts = [messages.offerSuccessfullyCanceled];
                        updateJobOfferStatus(response);
                    });
            };

            $scope.acceptOffer = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'acceptOfferTemplate.html',
                    controller: AcceptOfferController
                });


                modalInstance.result.then(function (result) {
                    result.Id = $scope.offer.Id,
                        djClientApi.acceptOffer(result)
                            .success(function (response) {
                                changeOfferStatus(offerStatus.Accepted);
                                AlertsService.alerts = [messages.offerSuccessfullyAccepted];
                                updateJobOfferStatus(response);
                            });
                });
            };

            $scope.rejectOffer = function () {
                var data = {
                    id: $scope.offer.Id,
                };
                djClientApi.rejectOffer(data)
                    .success(function (response) {
                        changeOfferStatus(offerStatus.Rejected);
                        AlertsService.alerts = [messages.offerSuccessfullyRejected];
                        updateJobOfferStatus(response);
                    });
            };

            var changeOfferStatus = function (status) {
                if ($scope.offer.OfferStatus === offerStatus.New) {
                    offersCountService.NewOffersCount -= 1;
                };
                markOffer(status);
            };
            var markOffer = function (status) {
                $scope.offer.OfferStatus = status;
                angular.forEach($scope.offers, function (offer, key) {
                    if (offer.Id === $scope.offer.Id) {
                        offer.OfferStatus = status;
                    };
                });
            };
            var updateJobOfferStatus = function (response) {
                if (response.IsSuccess) {
                    $scope.offer.IsLocked = true;
                } else {
                    AlertsService.alerts = [{ mgs: response.Errors[0] }];
                }
            };

            var isOfferLocked = function (status) {
                return status === offerStatus.Rejected
                    || status === offerStatus.Accepted
                    || status === offerStatus.Canceled;
            };

        });
}(window.LocalizationTexts));