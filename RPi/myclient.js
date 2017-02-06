var _userId = '';
function send(note) {
  $('.result').html(note);
  $.ajax({
    type: "GET",
    url: '/note/'+note+'/'+_userId,
    data: null,
    success: function(data,status,jqXHR){
      $('.result').html(status);
    },
    dataType: null
  });
}

function enterUserId() {
	_userId = $('#userId').val();
	changeInstrument("xylophone");
	$('.result').html('trying');
}

function changeInstrument(instrument) {
	$('#userIdDiv').addClass('hide');
	$('#xylophoneDiv').addClass('hide');
	$('#drumKitDiv').addClass('hide');
	if (instrument.indexOf("xylophone") >= 0){
		$('#xylophoneDiv').removeClass('hide');
		$('.result').html('changing to xylophone');
		
	}
	else if (instrument.indexOf("drumKit")>= 0) {
		$('#drumKitDiv').removeClass('hide');
		$('.result').html('changing to drum kit');
	}
	else {
		$('.result').html('what');
	}
}
