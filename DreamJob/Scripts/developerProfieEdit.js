var developerProfileEdit = (function($) {
    var module = {};
    var _options = {};

    var onSkillRemoveSuccess = function(data, status) {
        if (data.length > 0) {
            module._button.closest(_options.skillRow).remove();
        }
    };
    var onSkillRemoveError = function(data, status) {};

    var onButtonRemoveSkillClicked = function(e) {
        e.preventDefault();
        var button = $(e.target);
        module._button = button;
        var skillId = button.data(_options.dataSkillId);
        var ajaxOptions = {
            type: "POST",
            url: _options.urlRemoveSkill,
            dataType: "JSON",
            data: { skillId: skillId },
            success: onSkillRemoveSuccess,
            error: onSkillRemoveError
        };
        $.ajax(ajaxOptions);
    };

    module.initialize = function(options) {
        _options = options;
        $(options.buttonRemoveSkill).on('click', onButtonRemoveSkillClicked);
    };

    return module;

})(jQuery);