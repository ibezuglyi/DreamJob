djApplication.controller("RegisterController", function ($scope, djClientApi) {
    var self = this;
    $scope.registerVm = {
        login: "",
        password: "",
        displayName: "",
        email: ""
    };
    $scope.validationResults = {
        login: true,
        displayname: true,
        email: true,
        isValid: function() {
            return this.login && this.displayname && this.email;
        }
};
    
    $scope.registerDeveloper = function () {
        if ($scope.validationResults.isValid()) {

            djClientApi.registerDeveloper($scope.registerVm)
                .then(function (resp) {

                });
        };
    };
    $scope.registerRecruiter = function () {
        if ($scope.validationResults.isValid()) {
            djClientApi.registerRecruiter($scope.registerVm)
                .then(function(resp) {

                });
        };
    };
});