unsigned long last_time = 0;
int speed = 10;
int dir1 = 2;
int dir2 = 3;

void setup() {
  Serial.begin(9600);
  pinMode(speed,OUTPUT);
  pinMode(dir1,OUTPUT);
  pinMode(dir2,OUTPUT);

}

void loop() {
  if (millis() > last_time + 2000)
    {
        // Serial.println("Arduino is alive!!");
        last_time = millis();
    }

    // Send some message when I receive an 'A' or a 'Z'.
    switch (Serial.read())
    {
        case 'A':
            Serial.println("FIRE!!!!!!!!!!!!!!.");
            digitalWrite(dir1,LOW);
            digitalWrite(dir2,HIGH);
            analogWrite(speed,127);
            delay(3000);
            digitalWrite(speed,0);

            break;
        case 'Z':
            Serial.println("ICE!!!!!!!!!!!!!");
            digitalWrite(dir1,HIGH);
            digitalWrite(dir2,LOW);
            analogWrite(speed,250);
            delay(3000);
            digitalWrite(speed,0);
            break;
    }
  // put your main code here, to run repeatedly:

}
