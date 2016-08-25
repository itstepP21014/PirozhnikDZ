
function hide(e) {
	
	var chld_col = this.childNodes;
	for(var i = 0; i < chld_col.length; ++i)
	{
		if(chld_col[i].nodeName == "UL")
		{
			chld_col[i].style.display = "none";
			this.style.listStyleType = "square";
		}
	}

	e.stopPropagation();	
}

function onLoad() {
	var el = document.getElementById('wysiwyg'); 
	var str = parseElements(el);
	document.getElementById('struct').innerHTML = str;
	var li_collection = document.getElementsByTagName("li");
	for( var i=0; i<li_collection.length; i++)
	{
		li_collection[i].onclick = hide;
	}
}

function  parseElements(el) {
	var str = '';
	switch (el.nodeType) {
		case 1: // Element 
			str += '&lt;'+el.tagName + '&gt;<ul>';
			for( var i=0; i<el.childNodes.length; i++) {
				str+='<li>'+parseElements(el.childNodes[i])+ '</li>';
			}
			str+= '</ul>';
		break;
		
		case 3: // Text 
			str += '*TEXT*'+el.nodeValue+'';
		break;
	}
	return str;
}


window.onload=onLoad;