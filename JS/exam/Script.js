var firstTime = true;
var rememberedImg = "";
var abledImgs = 16;
var start = true;
var startTime = new Date();
var finTime = new Date();


$(document).ready(function () {

    $(".flip-container").click(function () {

        //if (start)
        //{
        //    start = false;
        //    //startTime = 
        //}

        //if (firstTime)
        //{
        //    firstTime = false;
        //    //rememberedImg = this.childNodes[1].childNodes[2].childNodes[1].src;
        //}
        //else
        //{
        //    firstTime = true;
        //    if(rememberedImg == this.childNodes[1].childNodes[2].childNodes[1].src)
        //    {
        //        //улетают rememberedImg и текущая картинка  animate({ opacity: "hide" }, "slow")
        //        // неактивны
        //        abledImgs -= 2;
        //        if(abledImgs == 0)
        //        {
        //            //finTime = 
        //            var score = finTime - startTime;
        //            // сообщение о выйгрыше
        //        }
        //    }
        //}

        this.childNodes[1].style.transform = "rotateY(180deg)";

    });

    

})



function generateArray() {

    var arr = [];

    for(var i = 0; i < 8; ++i)
    {
        arr[i] = i;
    }

    //arr = arr.shuffle().concat(arr.shuffle());
    arr = arr.concat(arr);

    return arr;
}


function onLoad() {

    var arr = generateArray();

    var src = "";
    var i = 0;
    for(img in document.getElementsByClassName("back_side"))
    {
        switch(arr[i])
        {
            case 0: src = "img/bird.jpg";
                break
            case 1: src = "img/sun.jpg";
                break
            case 2: src = "img/pumpkin.jpg";
                break
            case 3: src = "img/heart.jpg";
                break
            case 4: src = "img/balls.jpg";
                break
            case 5: src = "img/barash.jpg";
                break
            case 6: src = "img/spider.jpg";
                break
            case 7: src = "img/nyusha.jpg";
                break
            default: src = "img/error.jpg"
                break
        }

        img.src = src;
        ++i;
    }
}

window.onload = onLoad;




