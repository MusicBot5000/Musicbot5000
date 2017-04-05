var _userId = '';
var _drumRolling = false;
var _rollSolenoid = 'S1';
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
		_rollTimeout = setInterval(function(){
			if (_rollSolenoid == 'S1') {
				send('S2');
				_rollSolenoid = 'S2';
			}
			else if (_rollSolenoid == 'S2') {
				send('S1');
				_rollSolenoid = 'S1';
			}
		},100)
	}
	else if (_drumRolling = true) {
		$('#drumRollButton').removeClass('btn-danger');
		$('#drumRollButton').addClass('btn-success');
		$('#drumRollButton').text('Start Roll');
		_drumRolling = false;
		clearInterval(_rollTimeout);
	}
}
