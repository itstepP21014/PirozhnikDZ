$("#scrollable").scroll(function() {
	var pos = $(this).scrollTop();
	console.log(pos);
	
	for (var i=0;i<6;i++) {
	if (pos < positions[i]) {
		$("#infobox").text(caps[i]);
		break;
	}
	}
});

var positions = [];
var caps = ["*","**","***","****","*****","******"];

$(document).ready (function () {
	$("h1").each(function(i,el) {
		positions.push($(el).offset().top);
	})
	
})

