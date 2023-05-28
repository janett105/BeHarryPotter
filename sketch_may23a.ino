int speed = 10;
int dir1 = 2;
int dir2 = 3;

void setup() {
  pinMode(speed,OUTPUT);
  pinMode(dir1,OUTPUT);
  pinMode(dir2,OUTPUT);
  // put your setup code here, to run onc
}

void loop() {
  digitalWrite(dir1,HIGH);
  digitalWrite(dir2,LOW);
  analogWrite(speed,127); 
  delay(10000);

  //뜨겁게 만들기 

  digitalWrite(dir1,LOW);
  digitalWrite(dir2,HIGH);
  analogWrite(speed,127);
  delay(10000);
  // 차갑게 만들기

  digitalWrite(speed,0);
  // 정지
  
  // put your main code here, to run repeatedly:

}
