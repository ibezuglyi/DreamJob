djApplication.controller("RegisterController", function ($scope, $window, djClientApi) {
    $scope.registerVm = {
        login: "",
        password: "",
        displayName: "",
        email: ""
    };

    $scope.register = function(accountType) {
        if (!$scope.regform.$invalid) {
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