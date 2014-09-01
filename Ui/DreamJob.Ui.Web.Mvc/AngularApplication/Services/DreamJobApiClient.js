window.djApplication.factory('djClientApi', function ($http) {

    var addComment = function (comment) {
        var postRequest = $http.post('comment/add', comment);
        return postRequest;
    };

    var getMyOffers = function () {
        var getRequest = $http.get('offer/MyOffers');
        return getRequest;
    };

    var offerDetails = function (offerId) {
        var getRequest = $http.get('offer/OfferDetails/' + offerId);
        return getRequest;
    };

    var client = {
        addComment: addComment,
        getMyOffers: getMyOffers,
        getOfferDetails: offerDetails
    };

    return client;
});