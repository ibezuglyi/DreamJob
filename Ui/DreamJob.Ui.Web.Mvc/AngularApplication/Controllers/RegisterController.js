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
        email: true
    };
    
    $scope.registerDeveloper = function () {
        
        djClientApi.registerDeveloper($scope.registerVm)
            .then(function (resp) {
            });
    };
    $scope.registerRecruiter = function () {
        djClientApi.registerRecruiter($scope.registerVm)
        .then(function (resp) {

        });
    };
});