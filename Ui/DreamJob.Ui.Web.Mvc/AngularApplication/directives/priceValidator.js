djApplication.directive("minPrice", function () {
    var minValue = 0;
    var isValid = function (val) {
        var value = parseFloat(val);
        if (isNaN(value)) {
            return false;
        };
        var isok = value >= minValue;
        return isok;
    };
    return {
        require: "ngModel",
        link: function (scope, elm, attr, ngModelCtrl) {
            minValue = parseInt(attr.minVal);

            ngModelCtrl.$parsers.unshift(function (viewValue) {
                ngModelCtrl.$setValidity("priceValidation", isValid(viewValue));
                return viewValue;
            });

            ngModelCtrl.$formatters.unshift(function (modelValue) {
                ngModelCtrl.$setValidity("priceValidation", isValid(modelValue));
                return modelValue;
            });
        }
    };
});