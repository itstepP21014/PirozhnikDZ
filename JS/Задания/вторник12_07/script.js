
function make() {
	 var xr = new XMLHttpRequest();
	 xr.onreadystatechange = function () {
		if((xr.readyState == 4) && (xr.status == 200))
		{
			var paragraph = document.getElementById("paragraph");
			paragraph.innerHTML = xr.responseText;
		}
	}
	var str = this.innerHTML + ".txt";
	 xr.open("GET", str, true);
	 xr.send();
}

function main() {
	 var button_collection = document.getElementsByTagName("button");
	 for(var i = 0; i < button_collection.length; ++i)
	 {
		button_collection[i].onclick = make;
	 }
 }
 
 
  window.onload = main;