int speed = 10;
int dir1 = 2;
int dir2 = 3;
char incomingData;

void setup() {
  pinMode(speed,OUTPUT);
  pinMode(dir1,OUTPUT);
  pinMode(dir2,OUTPUT);
  Serial.begin(9600);
  Serial.println("Hi");
  // put your setup code here, to run onc
}

void loop() {
  //if 시러얼 통신에 특정 값이 input 되면 loop 동작 시작(3초동안)-> off
  if (Serial.available()>0){
    Serial.println("WHat");
    incomingData = Serial.read();
    Serial.println("Wow");
    if (incomingData == 'f'){
      digitalWrite(dir1,HIGH);
      digitalWrite(dir2,LOW);
      analogWrite(speed,127); 
      delay(3000);
      digitalWrite(speed,0);
      Serial.println("Hot");
    }
    else if (incomingData == 'i'){
      digitalWrite(dir1,LOW);
      digitalWrite(dir2,HIGH);
      analogWrite(speed,127); 
      delay(3000);
      digitalWrite(speed,0);
      Serial.println("Cold");
    }
    else{
      digitalWrite(dir1,LOW);
      digitalWrite(dir2,LOW);
      Serial.println("Nothing");
    }
  }
  

  //digitalWrite(speed,0);
  // 정지
  
  // put your main code here, to run repeatedly:

}
