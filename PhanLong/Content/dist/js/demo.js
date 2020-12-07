/**
 * AdminLTE Demo Menu
 * ------------------
 * You should not use this file in production.
 * This file is for demo purposes only.
 */

/* eslint-disable camelcase */
function ChangeSettings(id) {
    $.ajax({
        url: "/Home/ChangeSettings",
        data: { id: id },
        dataType: "json",
        type: "POST",
        success: function (response) {
            location.reload();
        }
    });
}
(function ($) {

    if ($('#darkmode').is(':checked')) {
        $('body').addClass('dark-mode');
        $('.main-header').removeClass('navbar-light');
        $('.main-header').removeClass('bg-white');
        $('.main-header').addClass('navbar-dark');
        $('.main-header').addClass('bg-gray-dark');
    }

$('#darkmode').on('click', function () {
    if ($('#darkmode').is(':checked')) {
        $('body').addClass('dark-mode');
        $('.main-header').removeClass('navbar-light');
        $('.main-header').removeClass('bg-white');
        $('.main-header').addClass('navbar-dark');
        $('.main-header').addClass('bg-gray-dark');
    } else {
        $('body').removeClass('dark-mode');
        $('.main-header').removeClass('navbar-dark');
        $('.main-header').removeClass('bg-gray-dark');
        $('.main-header').addClass('navbar-light');
        $('.main-header').addClass('bg-white');
    }
  })


})(jQuery)
