

function loadText() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', 'text.txt', false);
    xhr.send();
    return xhr.responseText;
}

var word_list = new Array();
var count;

function main()
{
    var str = loadText();

    var arr = str.split(" ");
    
    for (var i = 0; i < arr.length; ++i) {
        var word = arr[i];
        var index = word.length - 1;
        var lastSymbol = word[index];
        var firstSymbol = word[0];
        if (lastSymbol == "," || lastSymbol == "!" || lastSymbol == "." || lastSymbol == "?" || lastSymbol == '"')
        {
            arr[i] = arr[i].slice(0, -1);
            count = true;
            for(var key in word_list)
            {
                if(key == arr[i])
                {
                    word_list[arr[i]] += 1;
                    count = false;
                    break;
                }
            }
            if (count) {
                word_list[arr[i]] = 1;
            }
        }
    }

    var cloud = [];

    for (var key in word_list) {
        cloud.push({text: key, weight: word_list[key]});
    }

   
    $("#container").jQCloud(cloud);


     
}

window.onload = main;



