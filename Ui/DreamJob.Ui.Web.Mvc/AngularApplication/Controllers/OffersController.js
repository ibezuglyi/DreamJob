window.djApplication.controller('OfferController', function($scope, $http, DjClientApi) {

    $scope.offers = [];
    $scope.offer = {};
    $scope.offerComments = [];
    $scope.comment = {
        text: ''
    };

    $scope.init = function() {
        DjClientApi.getMyOffers()
            .success(function(response) {
                $scope.offers = response;
            })
    };

    $scope.details = function(offerId) {
        DjClientApi.getOfferDetails(offerId)
            .success(function(response) {
                $scope.offer = response;
                $scope.offerComments = response.JobOfferComments;
            });
    };

    $scope.addOfferComment = function() {
        var data = {
            offerId: $scope.offer.Id,
            text: $scope.comment.text
        };
        DjClientApi.addComment(data)
            .success(function(response) {
                if (response.IsSuccess) {
                    $scope.offerComments.push(response.Data);
                    $scope.comment.text = '';
                }
            });
    };
});