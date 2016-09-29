int incomingByte = 0;   // for incoming serial data

//These variables are required for the motorshield.
int direction =12;
int solenoid = 3;
int brake = 9;

void setup() {
        Serial.begin(9600);     // opens serial port, sets data rate to 9600 bps
        // might be good to look into higher baud rates? i don't know
        
        pinMode(direction,OUTPUT);
        pinMode(solenoid,OUTPUT);
        pinMode(brake,OUTPUT);
        
        digitalWrite(direction,HIGH);
        digitalWrite(brake,LOW);
}

void loop() {

        // send data only when you receive data:
        if (Serial.available() > 0) {
                // read the incoming byte:
                
                Serial.read(); // I read serial to empty the buffer. I don't do anything with the value. 
                               // You will be able to read the bytes unity sends you through this command
                
                // Engage and disengage the solenoid.
                digitalWrite(solenoid,HIGH);
                delay(9);
                digitalWrite(solenoid,LOW);
        }
                
}
