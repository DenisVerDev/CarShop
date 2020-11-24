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

    $('.btn-cart').hover(function () {
        $(this).attr("src", "Content/Images/shopping-carthover.svg");
    }, function () {
        $(this).attr("src", "Content/Images/shopping-cart.svg");
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