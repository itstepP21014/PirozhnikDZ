/**
 * Created by admin on 15.08.2016.
 */

function make(el) {
	var x=el;
	return function() {
		alert(x);
	};
}

function main()
 {
	 var button_collection = document.getElementsByTagName("button");
	 for(i = 0; i < button_collection.length; ++i)
	 {
		button_collection[i].onclick = make("Была нажата кнопка " + (i+1).toString());
	 }
 }
 

 
 function make_onclick(isBomb_) {
	 isBomb=isBomb_;
	 return function(){
		 if(isBomb)
		{		
			this.innerHTML = "x";
			alert("Вы проиграли (((");		
		}
		else
		{
			this.innerHTML = "-";
		}
	 }
}


 function bomb_generation()
 {
	 var random;
	 var button_collection = document.getElementsByTagName("button");
	 for(i = 0; i < button_collection.length; ++i)
	 {
		 button_collection[i].onclick = make_onclick((Math.random()<0.5));
	
	 }
 }
 
  function field_generation()
 {
 
	size = 8;
	var string = "";
	
	for(j=0; j<size; ++j)
	{
		for(i=0; i<size; ++i)
		{
			string+="<button>&nbsp;</button>";
		}

		string+="<br/>";
	}

	document.write(string);
	bomb_generation();

 }
 
 window.onload = field_generation;