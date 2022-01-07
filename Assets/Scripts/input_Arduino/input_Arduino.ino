void setup() {
  Serial.begin(9600);
}

void loop() {
  readInput();
}

void readInput() {
  Serial.println(analogRead(A0));
  Serial.print(" ");
  Serial.print(-map(analogRead(A1), 0, 1024, -90, 90));
  delay(20);
}
