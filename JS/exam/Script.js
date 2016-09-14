$(document).ready(function () {

    $(".flip-container").click(function () {

        //$(this.childNodes[1]).animate({ transform: 'rotateY(180deg)' }, 1000);
        this.childNodes[1].style.transform = "rotateY(180deg)";
    });

})




