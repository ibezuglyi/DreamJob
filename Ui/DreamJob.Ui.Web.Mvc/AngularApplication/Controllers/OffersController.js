window.djApplication.controller('OfferController', function ($scope, djClientApi) {

    var isOfferLocked = function (offerStatus) {
        return offerStatus === "Rejected"
            || offerStatus === "Accepted"
            || offerStatus === "Canceled";
    };

    $scope.offers = [];
    $scope.offer = {};
    $scope.offerComments = [];
    $scope.comment = {
        text: ''
    };

    $scope.init = function () {
        djClientApi.getMyOffers()
            .success(function (response) {
                $scope.offers = response;
            });
    };

    $scope.details = function (offerId) {
        djClientApi.offerDetails(offerId)
            .success(function (response) {
                $scope.offer = response;
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
                }
            });
    };

    $scope.cancelOffer = function () {
        var data = {
            id: $scope.offer.Id,
        };
        djClientApi.cancelOffer(data)
            .success(function (response) {
                updateJobOfferStatus(response);
            });
    };

    $scope.acceptOffer = function () {
        var data = {
            id: $scope.offer.Id,
        };
        djClientApi.acceptOffer(data)
            .success(function (response) {
                updateJobOfferStatus(response);
            });
    };

    $scope.rejectOffer = function () {
        var data = {
            id: $scope.offer.Id,
        };
        djClientApi.rejectOffer(data)
            .success(function (response) {
                updateJobOfferStatus(response);
            });
    };


    var updateJobOfferStatus = function (response) {
        if (response.IsSuccess) {
            $scope.offer.IsLocked = true;
        } else {
            alert(response.Errors[0]);
        }
    };

});