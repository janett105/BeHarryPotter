int speed = 10;
int dir1 = 2;
int dir2 = 3;

void setup() {
  pinMode(speed,OUTPUT);
  pinMode(dir1,OUTPUT);
  pinMode(dir2,OUTPUT);
  Serial.begin(9600);
  // put your setup code here, to run onc
}

void loop() {
  //if 시러얼 통신에 특정 값이 input 되면 loop 동작 시작(5초동안)-> off
  if (Serial.available()>0){
    incomingData = Serial.read();
    if (incomingData == 'Failed'){
      digitalWrite(dir1,HIGH);
      digitalWrite(dir2,LOW);
      analogWrite(speed,127); 
      delay(5000);
      digitalWrite(speed,0);
    }
    }
  }
  

  //뜨겁게 만들기 

  //digitalWrite(dir1,LOW);
 // digitalWrite(dir2,HIGH);
  //analogWrite(speed,127);
  //delay(10000);
  // 차갑게 만들기

  //digitalWrite(speed,0);
  // 정지
  
  // put your main code here, to run repeatedly:

}
