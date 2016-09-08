var positions;
var imgs;

function recalculate() {
    positions = [];
     imgs = [];
    $(".galeryImg").each(function (i, el) {
        positions.push($(el).offset().top);
        console.log($(el).offset().top);
        imgs.push(el);
    })

}

$(document).ready(recalculate)


$(window).scroll(function () {
    var pos = $(this).scrollTop();
    var i;
    for (i = 0; i < positions.length; i++) {
            
        if ((positions[i] - pos) <= (document.body.clientHeight / 2)) {
            $(imgs[i]).animate({ width: "60%" });
            $(imgs[i-1]).animate({ width: "40%" });
        }
        
        recalculate();
    }


});

