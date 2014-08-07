angular.module('djpa', [])
    .controller('ProfileController', function ($scope, $http) {

        $scope.offers = [];
        $scope.offer = {};
        $scope.comment = {
            text: ''
        };


        $scope.init = function () {
            this.foo();
        }

        $scope.foo = function () {
            $http.get('offers/MyOffers').success(function (response) {
                $scope.offers = response;
            });

            $scope.details = function (offerId) {
                $http.get('offers/OfferDetails/' + offerId)
                    .success(function (response) {
                        $scope.offer = response
                    });
            };

            $scope.addOfferComment = function () {
                var data = {
                    offerId: $scope.offer.Id,
                    text: $scope.comment.text
                };
                $http.post('comments/add', data);
            }
        }
    });