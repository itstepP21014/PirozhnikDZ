var arrOfImgs = ["img/bird.jpg", "img/sun.jpg", "img/pumpkin.jpg", "img/heart.jpg", "img/balls.jpg", "img/barash.jpg", "img/nyusha.jpg", "img/spider.jpg", ];

var firstTime = true;
var rememberedImg;
var abledImgs = 16;
var start = true;
var startTime = new Date();
var finTime = new Date();


function getImgFrom(el) {
    var img;

    var ch = $(el).children();
    var chch = $(ch).children()
    img = $(chch[1]).children();

    return img[0];
}

function sayEndGame() {
    alert("You are WIN!!!\nTHE END");
}

$(document).ready(function () {

    $(".flip-container").click(function () {

        this.childNodes[1].style.transform = "rotateY(180deg)";

        if (start)
        {
            start = false;
            //startTime = 
        }

        if (firstTime)
        {
            firstTime = false;
            rememberedImg = getImgFrom(this);

        }
        else
        {
            firstTime = true;
            var currentImg = getImgFrom(this);
            if (rememberedImg.src == currentImg.src)
            {
                //исчезают rememberedImg и текуща€ картинка  animate({ opacity: "hide" }, "slow")
                $(rememberedImg).animate({ opacity: "hide" }, 2000);
                $(currentImg).animate({ opacity: "hide" }, 2000);
                // неактивны

                var p = $(rememberedImg).parents(".flipper");
                var d = $(p[0]).parents(".flip-container");
                d[0].setAttribute("disabled", "disabled");

                var p2 = $(currentImg).parents(".flipper");
                var d2 = $(p2[0]).parents(".flip-container");
                d2[0].setAttribute("disabled", "disabled");


                abledImgs -= 2;
                if(abledImgs == 0)
                {
                    //finTime = 
                    var score = finTime - startTime;
                    setTimeout(sayEndGame, 2000);
                }
            }
            else
            {
                var flipper_1 = $(currentImg).parents(".flipper")[0];

                setTimeout(function () { flipper_1.style.transform = "rotateY(0deg)"; }, 700);

                //flipper.style.transform = "rotateY(0deg)";
                var flipper_2 = $(rememberedImg).parents(".flipper")[0];

                setTimeout(function () { flipper_2.style.transform = "rotateY(0deg)"; }, 700);

                //flipper.style.transform = "rotateY(0deg)";

                rememberedImg = undefined;
            }
        }

       

    });

    

})



function shuffle(array) {
    var m = array.length, t, i;

    // While there remain elements to shuffleЕ
    while (m) {

        // Pick a remaining elementЕ
        i = Math.floor(Math.random() * m--);

        // And swap it with the current element.
        t = array[m];
        array[m] = array[i];
        array[i] = t;
    }

    return array;
}


function generateArray() {

    var arr = [];

    for(var i = 0; i < 8; ++i)
    {
        arr[i] = i;
    }

    arr = arr.concat(arr);
    arr = shuffle(arr);

    return arr;
}

function onLoad() {

    var arr = generateArray();

    var imgsArr = document.getElementsByClassName("back_side");
    for (var i = 0; i < imgsArr.length; ++i)
    {
        imgsArr[i].src = arrOfImgs[arr[i]];
    }

}

window.onload = onLoad;




