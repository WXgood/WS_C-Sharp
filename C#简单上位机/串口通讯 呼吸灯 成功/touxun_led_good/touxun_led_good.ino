//串口通讯 呼吸灯 成功
int led = 6;
int led1 = 7;
void setup() {
pinMode(led,OUTPUT);
pinMode(led1,OUTPUT);
Serial.begin(9600,SERIAL_8N1);
}

void loop() {
delay(1000);
Serial.available();
//Serial.print(data);
if(Serial.read()>=99)//大于或者等于99点亮led
{

  digitalWrite(led, HIGH);
  delay(1000);
  digitalWrite(led,LOW);
while(1)
{
  for (int a = 0; a <= 255; a = a + (1))
  {
    analogWrite(led,a);
    delay(10);
  }
  for (int a = 255; a >= 0; a = a + (-1))
  {
    analogWrite(led,a);
    delay(10);
  }
  delay(10);
}
}

if(Serial.read()==8)
{
    digitalWrite(led,LOW);
}
}
