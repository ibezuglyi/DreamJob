var jobOfferDetailsChangeStatus = (function($) {
    var module = {};
    var _options = {};

    var onJobOfferStatusSubmitSuccess = function(data, status) {
            var content = $(_options.containerJobOfferStatusChangeContent);
        if (data.Success === true) {
            content.html("");
            module.modal.modal("hide");
            document.location.reload();
        } else {
            var errorsHolder = content.find(_options.contentHolderValidationError);
            var errorsList = $("<ul></ul>");
            $.each(data.Errors, function(index, errorMessage) {
                errorsList.append("<li>" + errorMessage + "</li>");
            });
            errorsHolder.html(errorsList);
        }
    };

    var onJobOfferStatusSubmitError = function(data, status) {
        console.log("!ERROR: onJobOfferStatusSubmitError");
        console.log("\t- " + data);
        console.log("\t- " + status);
    };

    var onButtonJobOfferStatusChangeSubmitClicked = function(e) {
        e.preventDefault();
        var form = $(e.target).closest("form");
        var formData = form.serialize() + "&status=" + _options.status;

        var ajaxOptions = {
            url: _options.urlJobOfferStatusChange,
            data: formData,
            dataType: "JSON",
            type: "POST",
            success: onJobOfferStatusSubmitSuccess,
            error: onJobOfferStatusSubmitError
        };
        $.ajax(ajaxOptions);
    };

    var onGetJobOfferStatusSuccess = function(data, status) {
        if (data.Success) {
            $(_options.containerJobOfferStatusChangeContent).html(data.Data);
            module.modal = $(_options.containerJobOfferStatusChangeDialog).modal("show");
            $(_options.buttonJobOfferStatusChangeSubmit).on("click", onButtonJobOfferStatusChangeSubmitClicked);
        }
    };
    var onGetJobOfferStatusError = function() {
        console.log("!ERROR: onGetJobOfferStatusError");
        console.log("\t- " + data);
        console.log("\t- " + status);
    };

    var onButtonJobOfferStatusChangeClicked = function(e) {
        e.preventDefault();
        var newJobStatusType = $(e.target).data(_options.dataJobOfferDataAttributeStatus);
        _options.status = newJobStatusType;
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