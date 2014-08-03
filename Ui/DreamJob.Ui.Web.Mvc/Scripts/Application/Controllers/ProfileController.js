angular.module('djpa', [])
    .controller('ProfileController', function ($scope, $http) {

        $scope.offers = [];

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
                        $scope.offerDetails = response
                    });
            };
        }
    });