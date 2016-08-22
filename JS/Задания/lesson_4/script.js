/**
 * Created by admin on 15.08.2016.
 */
 

 function main()
 {

	 var images_collection = document.getElementsByClassName("image");
	 for(i = 0; i < images_collection.length; ++i)
	 {
		images_collection[i].onmouseover = enlarge;
		images_collection[i].onmouseout = ensmall;
	 }
 }
 
 function enlarge()
 {
	 this.style.width="200px";
 }
 
 function ensmall()
 {
	 this.style.width="100px";
 }
  window.onload = main;
 
 function table()
 {
 
	var rows = 4;
	var cols = 5;

	var string = "<table>";
	var number;

	for(j=0; j<rows; ++j)
	{
		number = 1 + j
		
		string+="<tr>"
		
		for(i=0; i<cols; ++i)
		{
			string+="<td>" + (number++).toString() + "</td>"
		}

		string+="<tr>"
	}

	string += "</table>";

	document.write(string);

 }
/*
do
{
    surname=prompt("Ваша фамилия:");
    sex=prompt("Ваш пол:");

}
while(!(confirm("ФИО: "+surname+"\n" +
    "Пол: "+sex+"\n" +
    "Возраст: "+age+"\n" +
    "Е-mail: "+email+"\n\n" +
    "Все верно?")))
alert("Благодарим за предоставленную информацию");



img.onclick = enlarge;
*/
