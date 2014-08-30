window.djApplication
    .controller('OfferController', function($scope, $http) {

        $scope.offers = [];
        $scope.offer = {};
        $scope.offerComments = [];
        $scope.comment = {
            text: ''
        };
        $scope.init = function() {
            $http.get('offers/MyOffers').success(function(response) {
                $scope.offers = response;
            });

            $scope.details = function(offerId) {
                $http.get('offers/OfferDetails/' + offerId)
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
                $http.post('comments/add', data)
                    .success(function(response) {
                        if (response.IsSuccess) {
                            $scope.offerComments.push(response.Data);
                            $scope.comment.text = '';
                        }
                    });
            }
        }
    });