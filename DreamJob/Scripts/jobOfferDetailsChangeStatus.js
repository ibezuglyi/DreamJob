var jobOfferDetailsChangeStatus = (function($) {
    var module = {};
    var _options = {};

    var onGetJobOfferStatusSuccess = function(data, status) {
        $(_options.containerJobOfferStatusChangeContent).html(data);
        $(_options.containerJobOfferStatusChangeDialog).modal("show");

    };
    var onGetJobOfferStatusError = function() {
        console.log("!ERROR: onGetJobOfferStatusError");
        console.log("\t- " + data);
        console.log("\t- " + status);
    };

    var onButtonJobOfferStatusChangeClicked = function(e) {
        e.preventDefault();
        var newJobStatusType = $(e.target).data(_options.dataJobOfferDataAttributeStatus);
        var ajaxOptions = {
            type: "GET",
            dataType: "JSON",
            url: _options.urlJobOfferStatusChange,
            data: {
                id: _options.dataJobOfferId,
                status: newJobStatusType
            },
            success: onGetJobOfferStatusSuccess,
            error: onGetJobOfferStatusError
        };

        $.ajax(ajaxOptions);
    };


    module.initialize = function(options) {
        _options = options;
        $(_options.buttonJobOfferStatusChange).on('click', onButtonJobOfferStatusChangeClicked);
    }

    return module;

})(jQuery);