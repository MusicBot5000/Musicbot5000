var MCP23017 = require('node-mcp23017');
var notesInProgress = {
	//xylophone
	"xC1": false,
	"xD1": false,
	"xE1": false,
	"xF1": false,
	"xG1": false,
	"xA2": false,
	"xB2": false,
	"xC2": false,
	"xD2": false,
	"xE2": false,
	"xF2": false,
	
	//snare drum
	"S1": false,
	"S2": false,
	"S3": false,
	"S4": false,
	
	//cowbell
	"dB1": false,
};
var mcp1 = new MCP23017({
	address: 0x20,
	device: '/dev/i2c-1',
	debug: true
});

var mcp2 = new MCP23017({
	address: 0x21,
	device: '/dev/i2c-1',
	debug: true
});

//var mcp3 = new MCP23017({
//	address: 0x22,
//	device: '/dev/i2c-1',
//	debug: true
//});

//var mcp4 = new MCP23017({
//	address: 0x23,
//	device: '/dev/i2c-1',
//	debug: true
//});

function I2CGPIOController() {
	this.setupPins = function() {
		for (var i = 0; i < 16; i++) {
			console.log('writing pin: '+i+'as output');
			mcp1.pinMode(i,mcp1.OUTPUT);
			console.log('writing pin to second board: '+i);
			mcp2.pinMode(i,mcp2.OUTPUT);
			//mcp3.pinMode(i,mcp3.OUTPUT);
			//mcp4.pinMode(i,mcp4.OUTPUT);
		}
	}

	this.writeToPin = function(key) {
		if (!notesInProgress.key)
		{
			//these vars need to be declared every time to prevent a race condition
			var pin;
			var board;
			var timeout;

			//tells the server not to try and turn the note on again if it's already on
			//prevents issues with contention on the solenoids and timing problems etc.
			console.log(key);
			if ((notesInProgress[key] != null) && (notesInProgress[key] == false)) {
				//if the note exists and is off, tell the server it's on and continue
				notesInProgress[key] = true;
				console.log('hello');
			}
			else if ((notesInProgress[key] == null) || (notesInProgress[key] == true)) {
				//if the note doesn't exist or was on, do nothing and exit the function
				console.log(notesInProgress[key]);
				console.log('brokeennn');
				return;
			}

			//xylophone notes
			if (key == "xC1"){
				board = mcp1;
				pin = 7;
				timeout = 5;
			}
			else if (key == "xD1") {
				board = mcp1;
				pin = 6;
				timeout = 5;
			}
			else if (key == "xE1") {
				board = mcp1;
				pin = 5;
				timeout = 5;
			}
			else if (key == "xF1") {
				board = mcp1;
				pin = 4;
				timeout = 5;
			}
			else if (key == "xG1") {
				board = mcp1;
				pin = 3;
				timeout = 5;
			}
			else if (key == "xA2") {
				board = mcp1;
				pin = 2;
				timeout = 5;
			}
			else if (key == "xB2") {
				board = mcp1;
				pin = 1;
				timeout = 5;
			}
			else if (key == "xC2") {
				board = mcp1;
				pin = 0;
				timeout = 5;
			}
			else if (key == "xD2") {
				board = mcp2;
				pin = 7;
				timeout = 5;
			}
			else if (key == "xE2") {
				board = mcp2;
				pin = 6;
				timeout = 5;
			}
			else if (key == "xF2") {
				board = mcp2;
				pin = 5;
				timeout = 5;
			}

			//snare drum notes
			else if (key == "S1") {
				board = mcp2;
				pin = 4;
				timeout = 5;
			}
			else if (key == "S2") {
				board = mcp2;
				pin = 3;
				timeout = 5;
			}
			else if (key == "S3") {
				board = mcp2;
				pin = 2;
				timeout = 5;
			}
			else if (key == "S4") {
				board = mcp2;
				pin = 1;
				timeout = 5;
			}
			
			//cowbell notes
			else if (key == "dB1") {
				board = mcp2;
				pin = 0;
				timeout = 5;
			}
			else {
				console.log('incorrect note')
			}
			console.log("writing pin "+pin+" as high");
			//write the correct pin on the correct board as high
			board.digitalWrite(pin,board.HIGH);
			console.log('turned on');
			//console.log("Done");
			//wait specified amount of time and write it low again
			//also tell the server you have written it low by setting note in progress to false
			setTimeout(function() {
				console.log('turning off');
				console.log('board: '+board.device+'pin: '+pin);
				board.digitalWrite(pin,board.LOW);
				notesInProgress[key] = false;
				console.log("key done being played: "+key);
			},timeout);
		}
	}
}	
module.exports = new I2CGPIOController;
