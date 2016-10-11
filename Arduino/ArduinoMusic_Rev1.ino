void setup()
{
  Serial.begin(111530); // TODO: Configure the Baud rate
}

void loop() {
  for (int noteAddr = 0; noteAddr < 5; noteAddr++) 
  {
    digitialWrite(noteAddr, HIGH);
    delay(1000);
    digitalWrite(noteAddr, LOW);
    delay(1000);
  }
}
