// JavaScript source code
//function loadXMLDoc(filename)
//{
	
//    xhttp = new XMLHttpRequest();
//    xhttp.open("GET", filename, false);
//    xhttp.send("");
//    return xhttp.responseXML;
//}

//function onclickMakerForDish(dish_) {

//}

function onclickMaker() {

}

function main()
{
    var button = document.getElementsById("loadEmail");
    button.onclick = onclickMaker();
     
}

window.onload = main;


function deleteImage($item) {
    $item.fadeOut(function () {
        var $list = $("img", $(".droppable")).length ?
          $("ul", $(".droppable")) :
          $('<img src="" alt="" class="draggable sortable" />').appendTo($(".droppable"));

        $item.find("a.ui-icon-trash").remove();
        $item.append(recycle_icon).appendTo($list).fadeIn(function () {
            $item
              .animate({ width: "48px" })
              .find("img")
                .animate({ height: "36px" });
        });
    });
}

$(function () {

    $('.droppable').droppable({
        accept: "#divForInboxÑorrespondence > img",
        drop: function (event, img) {
            deleteImage(img.draggable);
        }
    });

    $(".sortable").sortable({
        revert: true
    });
    $('.draggable').draggable({
        connectToSortable: ".sortable",
        helper: "clone",
        revert: "invalid",
        containment: "document",
        cancel: "a.ui-icon",
        cursor: "move"
    });

});


