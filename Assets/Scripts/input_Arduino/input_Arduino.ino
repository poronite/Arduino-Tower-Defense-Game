int buttonInput = 0;
int inputRotation = 0;
int constrainedRotation = 0;

void setup() {
  Serial.begin(9600);
  pinMode(3, INPUT_PULLUP);
}

void loop() {
  readInput();
}

void readInput() {
  buttonInput = digitalRead(3);
  inputRotation = map(analogRead(A1), 0, 1024, -90, 90);
  constrainedRotation = constrain(inputRotation, -90, 90);
  Serial.println((String)buttonInput +" "+ constrainedRotation);
}
