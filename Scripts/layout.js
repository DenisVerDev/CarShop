$(document).ready(function () {

    $(function () {
        UpdateNav();
    });

    $(window).resize(function () {
        UpdateNav();
    });

    $('.btn-cab').hover(function () {
        $(this).attr("src","Content/Images/btnloginhover.svg");
    }, function () {
        $(this).attr("src", "Content/Images/btnlogin.svg");
    });

});

function UpdateNav() {
    if ($('.navbar-toggler').is(":visible") && $('nav').hasClass("navbar-padding")) {
        $('nav').removeClass("navbar-padding");
    }
    else if (!$('.navbar-toggler').is(":visible")) {
        $('nav').addClass("navbar-padding");
    }
}