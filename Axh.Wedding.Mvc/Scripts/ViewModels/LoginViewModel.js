function LoginViewModel() {
    var self = this;

    self.validationMessagePopup = function(fieldLocator, xsPlacement) {
        var field = $(fieldLocator);

        if (field.data("content") == '') {
            return;
        }

        var placement = window.outerWidth < 850 ? xsPlacement : "right";

        field.popover({ trigger: "manual", placement: placement, delay: { show: 500, hide: 500 }, html: true });
        field.popover('show');
        field.on('click', function () {
            field.popover('hide');
        });
    };

    self.validationMessagePopup("#UserName", "top");
    self.validationMessagePopup("#Password", "bottom");
};