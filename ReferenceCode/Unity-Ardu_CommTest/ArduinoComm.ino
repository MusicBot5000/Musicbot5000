int incomingByte = 0;   // for incoming serial data

int direction =12;
int solenoid = 3;
int brake = 9;

void setup() {
        Serial.begin(9600);     // opens serial port, sets data rate to 9600 bps
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
                Serial.read();
                digitalWrite(solenoid,HIGH);
                delay(9);
                digitalWrite(solenoid,LOW);
        }
                
}
