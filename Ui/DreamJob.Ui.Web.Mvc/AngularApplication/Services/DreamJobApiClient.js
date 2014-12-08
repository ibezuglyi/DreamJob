window.djApplication.factory('djClientApi', function ($http) {
    var self = this;

    var saveProfile = function(profile, url) {
        var saveRequest = $http({
            url: url,
            method: "POST",
            data: profile
        });
        return saveRequest;
    }

    self.addComment = function (comment) {
        var postRequest = $http.post('/comment/add', comment);
        return postRequest;
    };
    self.getMyOffers = function () {
        var getRequest = $http.get('/offer/MyOffers');
        return getRequest;
    };
    self.offerDetails = function (offerId) {
        var getRequest = $http.get('/offer/OfferDetails/' + offerId);
        return getRequest;
    };
    self.getProfile = function () {
        var getProfileRequest = $http.get('/profile/CurrentUser');
        return getProfileRequest;
    };
    self.searchProfile = function (searchString, searchCity) {
        return $http.get("/profile/search", {
            params: {
                technology: searchString,
                city: searchCity
            }
        });
    },
    self.getCities = function (token) {
        return $http.get("/profile/GetCities", {
            params: { cityPart: token }
        });
    },

    self.saveDeveloperProfile = function (profile) {
        var saveRequest = saveProfile(profile, "/profile/SaveDeveloperProfile");
        return saveRequest;
    };
    self.saveRecruiterProfile = function (profile) {
        var saveRequest = saveProfile(profile, "/profile/SaveRecruiterProfile");
        return saveRequest;
    };
    self.getCities = function (cityVal) {
        return $http.get("/profile/GetCities", {
            params: { cityPart: cityVal }
        });
    };

    self.cancelOffer = function (data) {
        return $http.post('/offer/cancelOffer', data);
    };
    self.acceptOffer = function (data) {
        return $http.post('/offer/acceptOffer', data);

    };
    self.rejectOffer = function (data) {
        return $http.post('/offer/rejectOffer', data);
    };
    self.validateUnique = function (type, value) {
        return $http({ url: '/register/check' + type, params: { val: value }, method: "GET" });
    };
    self.registerDeveloper = function (vm) {
        return $http.post("/register/RegisterDeveloper", vm);
    };

    self.registerRecruiter = function(vm) {
        return $http.post("/register/registerRecruiter", vm);
    };

    self.getNewOffersCount = function() {
        var http = $http.get("/Notification/GetNewOffersCount");
        return http;
    };
    self.sendOffer = function(offer) {
        var httpReq = $http.post('/offer/send', offer);
        return httpReq;
    };

    return self;
});