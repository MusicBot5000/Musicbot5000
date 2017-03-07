var _userId = '';
var _drumRolling = false;
var _rollSolenoid = 'dS1';
var _rollTimeout = null;
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
	$('#instrumentSelectionDiv').removeClass('hide');
	$('.result').html('trying');
}

function changeInstrument(instrument) {
	$('#userIdDiv').addClass('hide');
	$('#xylophoneDiv').addClass('hide');
	$('#drumKitDiv').addClass('hide');
	if (instrument.indexOf("xylophone") >= 0){
		$('#xylophoneDiv').removeClass('hide');
		$('.result').html('xylophone');
		
	}
	else if (instrument.indexOf("drumKit")>= 0) {
		$('#drumKitDiv').removeClass('hide');
		$('.result').html('drum kit');
	}
	else {
		$('.result').html('what');
	}
}


function drumRoll() {
	if (_drumRolling == false) {
		$('#drumRollButton').removeClass('btn-success');
		$('#drumRollButton').addClass('btn-danger');
		$('#drumRollButton').text('Stop Roll');
		_drumRolling = true;
		_rollTimeout = setTimeout(function(){
			if (_rollSolenoid == 'dS1') {
				send('dS2');
				_rollSolenoid = 'dS2';
			}
			else if (_rollSolenoid == 'dS2') {
				send('dS1');
				_rollSolenoid = 'dS1';
			}
		},100)
	}
	else if (_drumRolling = true) {
		$('#drumRollButton').removeClass('btn-danger');
		$('#drumRollButton').addClass('btn-success');
		$('#drumRollButton').text('Start Roll');
		_drumRolling = false;
		clearTimeout(_rollTimeout);
	}
}
