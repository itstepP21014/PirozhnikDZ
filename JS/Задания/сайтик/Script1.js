// JavaScript source code
function loadXMLDoc(filename)
{
	
    xhttp = new XMLHttpRequest();
    xhttp.open("GET", filename, false);
    xhttp.send("");
    return xhttp.responseXML;
}

function onclickMakerForDish(dish_) {

}

function onclickMaker(type_) {

    var type = type_;
    return function () {
        document.getElementById('divForTable').innerHTML = '';
        xml = loadXMLDoc("XML.xml");
        xsl = loadXMLDoc("XSL.xsl");
        xsltProcessor = new XSLTProcessor();
        xsltProcessor.importStylesheet(xsl);
        xsltProcessor.setParameter("","category", type);
        resultDocument = xsltProcessor.transformToFragment(xml, document);
        document.getElementById("divForTable").appendChild(resultDocument);

        var dish = document.getElementsByClassName("dish");
        for (var i = 0; i < dish.length; ++i) {
            dish[i].onclick = onclickMakerForDish(dish[i]);
        }

    }
}

function main()
{
    var menu = document.getElementsByClassName("menu");
    for (var i = 0; i < menu.length; ++i) {
        menu[i].onclick = onclickMaker(menu[i].id);  
    }  
}

window.onload = main;