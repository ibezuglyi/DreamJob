angular
    .module('djapp')
    .factory('offersCountService', function () {
        var self = this;
        self.NewOffersCount = 0;
        self.offers = [];
        self.getNewOffersCount = function () {
            self.NewOffersCount = 0;
            angular.forEach(self.offers, function(offerItem) {
                if (offerItem.Status === "New") {
                    self.NewOffersCount++;
                };
            });
            return self.NewOffersCount;
        };
        self.updateOffer = function (offer) {
            angular.forEach(self.offers, function (offerItem, index) {
                if (offerItem.Id === offer.Id) {
                    self.offers[index] = offer;
                };
            });
        }
        return self;
    });