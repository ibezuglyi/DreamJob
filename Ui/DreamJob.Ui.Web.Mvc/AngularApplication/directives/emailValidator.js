
djApplication.directive("uniqueVal", function (djClientApi) {
    
    var isValid = function (val, toVal, cb) {
        djClientApi
            .validateUnique(toVal, val)
            .then(cb);
    };
    return {
        require: "ngModel",
        link: function (scope, elm, attr, ngModelCtrl) {
            var toValidate = attr.uniqueVal;
            ngModelCtrl.$parsers.unshift(function (viewValue) {
                isValid(viewValue, toValidate, function (resp) {
                    var isValidValue = resp.data === "true";
                    ngModelCtrl.$setValidity("unique" + toValidate, isValidValue);
                });
                return viewValue;
            });

            ngModelCtrl.$formatters.unshift(function (modelValue) {
                isValid(modelValue, toValidate, function (resp) {
                    var isValidValue = resp.data === "true";
                    ngModelCtrl.$setValidity("unique" + toValidate, isValidValue);
                });
                return modelValue;
            });
        }
    }
});