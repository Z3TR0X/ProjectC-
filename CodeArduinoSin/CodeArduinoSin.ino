void setup() {
  Serial.begin(115200);
}

void loop() {
  float time_mod_5 = ((millis() % 5000)/5000.0)*3.14;
  float sin_val = sin(time_mod_5);
  Serial.println(sin_val);
  delay(50);

}
