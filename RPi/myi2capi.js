var http = require('http');
var express = require('express');
var i2c = require('./I2CGPIOController.js')
i2c.setupPins();
var app = express();
app.use(express['static'](__dirname));
app.get('/note/:note/:userId',function(req,res) {
	i2c.writeToPin(req.params.note);
	res.status(200).send('user '+req.params.userId+' played note '+req.params.note);
	console.log('user '+req.params.userId+' played note '+req.params.note);
});
app.get('*',function(req,res) {
	res.status(400).send('Unrecognized API call');
});
console.log('Server Running');
app.listen(3000);
