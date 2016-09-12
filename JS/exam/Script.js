$(document).ready(function () {

    $(".square").hover(function () {
        $(this).fadeOut("fast").fadeIn("fast");
    });

    $(".card-grid").flip('toggle');
})




