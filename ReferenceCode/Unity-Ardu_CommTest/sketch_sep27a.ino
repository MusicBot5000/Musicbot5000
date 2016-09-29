int incomingByte = 0;   // for incoming serial data

int hello =12;
int bye = 3;
int brake = 9;

void setup() {
        Serial.begin(9600);     // opens serial port, sets data rate to 9600 bps
        pinMode(hello,OUTPUT);
        pinMode(bye,OUTPUT);
        pinMode(brake,OUTPUT);
        
        digitalWrite(hello,HIGH);
        digitalWrite(brake,LOW);
}

void loop() {

        // send data only when you receive data:
        if (Serial.available() > 0) {
                // read the incoming byte:
                Serial.read();
                digitalWrite(bye,HIGH);
                delay(9);
                digitalWrite(bye,LOW);
        }
                
}
