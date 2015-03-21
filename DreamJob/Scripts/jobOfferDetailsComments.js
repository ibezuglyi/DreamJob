var jobOfferDetailsComments = (function($) {
    var module = {};
    var _options = {};


    var onJobOfferDetailsAddCommentSuccess = function(data, status) {
        if (data.Success === true) {
            $(_options.containerJobOfferComments).append(data.Data);
            $(_options.formAddComment)[0].reset();
        }
    };

    var onJobOfferDetailsAddCommentError = function(data, status) {
         console.log("!ERROR: onJobOfferDetailsAddCommentError");
        console.log("\t- " + data);
        console.log("\t- " + status);
    };

    var onButtonJobOfferDetailAddCommentClicked = function(e) {
        e.preventDefault();
        var form = $(_options.formAddComment);
        var data = form.serialize();
        var ajaxOptions = {
            url:_options.urlJobOfferAddComment,
            type: "POST",
            dataType: "JSON",
            data: data,
            success: onJobOfferDetailsAddCommentSuccess,
            error: onJobOfferDetailsAddCommentError
        };
        $.ajax(ajaxOptions);
    };

    module.initialize = function(options) {
        _options = options;

        $(_options.buttonJobOfferDetailAddComment).on("click", onButtonJobOfferDetailAddCommentClicked);

    };
    return module;


})(jQuery);