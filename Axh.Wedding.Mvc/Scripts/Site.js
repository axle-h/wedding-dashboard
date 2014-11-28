
// Navigation Scripts to Show Header on Scroll-Up
jQuery(document).ready(function ($) {
    var MQL = 1170;

    //primary navigation slide-in effect
    if ($(window).width() > MQL) {
        var headerHeight = $('.navbar-custom').height();
        var previousTop = 0;

        $(window).scroll(function() {
            var currentTop = $(window).scrollTop();
            //check if user is scrolling up
            if (currentTop < previousTop) {
                //if scrolling up...
                if (currentTop == 0) {
                    $('.navbar-custom').removeClass('is-visible is-fixed');
                } else {
                    $('.navbar-custom').addClass('is-visible');
                }
            } else if (currentTop != previousTop) {
                //if scrolling down...
                $('.navbar-custom').removeClass('is-visible');
                if (currentTop > headerHeight && !$('.navbar-custom').hasClass('is-fixed')) $('.navbar-custom').addClass('is-fixed');
            }
            previousTop = currentTop;
        });
    }

});

// Init view models.
$(function () {
    if (document.getElementById("pg-info")) {
        new InformationViewModel(model);
    }
    else if (document.getElementById("pg-rsvp")) {
        new RsvpViewModel(model);
    }
    else if (document.getElementById("pg-login")) {
        new LoginViewModel(model);
    }
});


