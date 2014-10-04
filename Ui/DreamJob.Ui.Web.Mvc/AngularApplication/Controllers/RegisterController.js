djApplication.controller("RegisterController", function ($scope, $window, djClientApi) {
    $scope.registerVm = {
        login: "",
        password: "",
        displayName: "",
        email: ""
    };
    $scope.registerDisabled = false;
    $scope.isRegisterDisabled = function() {
        return $scope.regform.$invalid || $scope.registerDisabled;
    };

    $scope.register = function(accountType) {
        if (!$scope.isRegisterDisabled()) {
            $scope.registerDisabled = true;
            var regAccessor = "register" + accountType;
            djClientApi[regAccessor]($scope.registerVm)
                .then(function(resp) {
                    if (resp.data && resp.data === "true") {
                        $window.location.href = "register/registered";
                    }
                });
        };
    };
});