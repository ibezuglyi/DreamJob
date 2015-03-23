var jobOfferDetailsComments = (function($) {
    var module = {};
    var _options = {};


    var onGetNewCommentsSuccess = function(data) {
        $(_options.containerJobOfferComments).append(data.Data);
        var form = $(_options.formAddComment);
        form[0].reset();
    };

    var onGetNewCommentsError = function(data, status) {
        console.log("!ERROR: onGetNewCommentsError");
        console.log("\t- " + data);
        console.log("\t- " + status);
    };

    var fetchNewComments = function() {
        var currentCommentCount = $(_options.selectorComment).length;
        var ajaxOptions = {
            data: {
                commentsCount: currentCommentCount,
                jobOfferId: _options.dataJobOfferId
            },
            url: _options.urlGetNewComments,
            type: "GET",
            dataType: "JSON",
            success: onGetNewCommentsSuccess,
            error: onGetNewCommentsError
        }
        $.ajax(ajaxOptions);
    };


    var onJobOfferDetailsAddCommentSuccess = function(data, status) {
        if (data.Success === true) {
            fetchNewComments();
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