djApplication.config(function ($provide, $httpProvider) {
    $provide.factory('httpInterceptor', function ($q) {
        return {
            response: function (response) {
                var isHtml = typeof response.data === "string"
                    && /DOCTYPE/.test(response.data);

                if (isHtml) {
                    var loginPage = response.headers("x-login");
                    var errorPage = response.headers("x-error");
                    if (loginPage) {
                        window.location.href = loginPage;
                    }
                    if (errorPage) {
                        window.location.href = errorPage;
                    }
                }
                return response || $q.when(response);
            }
        };
    });

    $httpProvider.interceptors.push('httpInterceptor');

});