var houses=document.getElementsByClassName("house");

console.log(houses[0]);
for (var i=0;i < houses.length; i++) {
   houses[i].onclick = function () {alert(i);}
   houses[i].onmouseover = function () {console.log(i);}
}
   setInterval(function() { 
     var windows = document.getElementsByTagName("rect");
	 windows[Math.floor((Math.random() * windows.length) )].style.fill = Math.random()>0.5?"red":"yellow";
   },100 );
