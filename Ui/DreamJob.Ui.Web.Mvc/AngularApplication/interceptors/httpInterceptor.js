djApplication.config(function ($provide, $httpProvider) {
    $provide.factory('httpInterceptor', function ($q) {
        return {
            response: function (response) {
                var isLoginHtml = typeof response.data === "string" && /DOCTYPE/.test(response.data);
                if (isLoginHtml) {
                    window.location.href = "/Login";
                }

                return response || $q.when(response);
            }
        };
    });

    $httpProvider.interceptors.push('httpInterceptor');

});