var jobOfferContactDetails = (function() {
    var module = {};
    var _options = {};

    var onContactDetailsGetSuccess = function(data, status) {
        if (data.Success) {
            $(_options.content).html(data.Data);
            module.modal = $(_options.dialog).modal("show");
            $(_options.buttonCloseContactDetails).on("click", function() {
                $(_options.content).html("");
                module.modal.modal("hide");
            });
        }
    };

    var onContactDetailsGetError = function(data, status) {};

    var onContactDetailsButtonClicked = function(e) {
        e.preventDefault();
        var button = $(e.target);
        var contactDetailsId = button.data(_options.dataContactDetailsId);
        var url = _options.urlGetContactDetails;

        var ajaxOptions = {
            type: "GET",
            dataType: "JSON",
            url: url,
            data: { id: contactDetailsId },
            success: onContactDetailsGetSuccess,
            error: onContactDetailsGetError
        };

        $.ajax(ajaxOptions);
    };


    module.initialize=function(options) {
        _options = options;
        $(_options.buttonContactDetails).on("click", onContactDetailsButtonClicked);
    }

    return module;
})();