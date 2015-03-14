var sendJobOffer = (function ($) {

    var module = {};
    var _options = {};

    var onSendJobOfferDialogSubmitSuccess = function (data, status) {
        var content = module._dialog.find(_options.contentSendJobOfferDialog);
        if (data && data.length > 0) {
            content.html(data);
            $(_options.buttonSendJobOfferSubmit).on("click", onButtonSendJobOfferSubmitClicked);
        } else {
            content.html('');
            module._dialog.modal("hide");
        }
    };
    var onSendJobOfferDialogSubmitError = function (data, status) {
        console.log("!ERROR: onSendJobOfferDialogSubmitSuccss");
        console.log("\t- " + data);
        console.log("\t- " + status);
    };

    var onButtonSendJobOfferSubmitClicked = function (e) {
        e.preventDefault();
        var form = $(_options.formSendJobOffer);
        var data = form.serialize();
        var ajaxOptions = {
            data: data,
            dataType: "JSON",
            url: _options.urlSendJobOfferDialog,
            type: "POST",
            success: onSendJobOfferDialogSubmitSuccess,
            error: onSendJobOfferDialogSubmitError
        };
        $.ajax(ajaxOptions);
    };

    var onGetSendJobOfferDialogSuccess = function (data, status) {
        var dialog = $(_options.placeholderSendJobOfferDialog);
        var content = dialog.find(_options.contentSendJobOfferDialog);
        content.html(data);
        $(_options.buttonSendJobOfferSubmit).on("click", onButtonSendJobOfferSubmitClicked);
        module._dialog = dialog.modal("show");
    };


    var onGetSendJobOfferDialogError = function (data, status) {
        console.log("!ERROR: onGetSendJobOfferDialogError");
        console.log("\t- " + data);
        console.log("\t- " + status);
    };

    var onButtonSendJobOfferClick = function (e) {
        e.preventDefault();
        var ajaxOptions = {
            url: _options.urlSendJobOfferDialog,
            dataType: "JSON",
            success: onGetSendJobOfferDialogSuccess,
            error: onGetSendJobOfferDialogError,
            type: "GET"
        };
        $.ajax(ajaxOptions);
    };

    module.initialize = function (options) {
        _options = options;
        $(_options.buttonSendJobOffer).on('click', onButtonSendJobOfferClick);

    };

    return module;

})(jQuery);