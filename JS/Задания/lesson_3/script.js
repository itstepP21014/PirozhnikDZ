/**
 * Created by admin on 15.08.2016.
 */

$(document).ready(function(){
	$("h2").css("color", "green").css("background", "pink").css("width", "150");
	
	$("#showEvenButton").click(function(){
	$("h2:even").show();
	});
	$("#hideEvenButton").click(function(){
	$("h2:even").hide();
	});
	
	$("#showOddButton").click(function(){
	$("h2:odd").show();
	});
	$("#hideOddButton").click(function(){
	$("h2:odd").hide();
	});
	
	$("#hideHref").click(function(){
	$("[href]").hide();
	});
	$("#showHref").click(function(){
	$("[href]").show();
	});
	
	$("#hideTargetBlank").click(function(){
	$("a[target='_blank']").hide();
	});
	$("#showTargetBlank").click(function(){
	$("a[target='_blank']").show();
	});

	 $("h2").dblclick(function () {
	 $(this).hide();
	 });

	$(".Zagolovok").mouseenter(function () {
	 alert("You entered h2!");
	 });
	 
	 $("input").focus(function () {
	 $(this).css("background-color", "#cccccc");
	 });
	 $("input").blur(function () {
	 $(this).css("background-color", "#ffffff");
	 });
	 
	 $("#speedButton").click(function () {
	 $("#speedP").toggle(1000);
	 });
	 
	 $("#toggleButton").click(function () {
	 $("p").toggle();
 });



	
});