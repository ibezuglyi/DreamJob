window.djApplication.factory('djClientApi', function ($http) {
    var self = this;
    self.addComment = function (comment) {
        var postRequest = $http.post('comment/add', comment);
        return postRequest;
    };

    self.getMyOffers = function () {
        var getRequest = $http.get('offer/MyOffers');
        return getRequest;
    };

    self.offerDetails = function (offerId) {
        var getRequest = $http.get('offer/OfferDetails/' + offerId);
        return getRequest;
    };

    self.getProfile = function () {
        var getProfileRequest = $http.get('profile/CurrentUser');
        return getProfileRequest;
    };

    self.saveProfile = function (profile) {
        var profileData = { profile: profile };
        var saveRequest = $http({
            url: "profile/CurrentUser",
            method: "POST",
            data: profileData
        });
        return saveRequest;
    };

    self.getCities = function (cityVal) {
        return $http.get("profile/GetCities", {
            params: { cityPart: cityVal }
        });
    };

    self.cancelOffer = function (data) {
        return $http.post('offer/cancelOffer', data);
    };
    self.acceptOffer = function (data) {
        alert(data);
        return $http.post('offer/acceptOffer', data);

    };
    self.rejectOffer = function (data) {
        return $http.post('offer/rejectOffer', data);
    };

    return self;
});