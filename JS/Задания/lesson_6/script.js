/**
 * Created by admin on 15.08.2016.
 */
 
 function main() {
	 var parent = document.getElementById("wysiwyg");
	 var nodes = parent.childNodes;
	 for(i = 0; i < nodes.length; ++i)
	 {
		 var ul_el = document.createElement("ul");
		 var parent2 = document.getElementById("tree");
		 parent2.innerHTML += "<ul><li>" + nodes[i].type + "</li></ul>";
	 }

 }
 
 
  window.onload = main;
