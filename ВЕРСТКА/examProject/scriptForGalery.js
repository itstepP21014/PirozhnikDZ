var positions = [];
var imgs = [];

$(document).ready(function () {
    $(".galeryImg").each(function (i, el) {
        positions.push($(el).offset().top);
        imgs.push(el);
    })
    console.log(positions);

})


$(window).scroll(function () {
    var pos = $(this).scrollTop();
    console.log(pos);
    var i;
    for (i = 0; i < positions.length; i++) {
        if (pos >= positions[i] && pos < positions[i + 1]) {
            $(imgs[i]).animate({ width: "80%" });
            console.log(i);
            break;
        }
    }
    

});