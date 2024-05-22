#include <Adafruit_Fingerprint.h>
#include <ArduinoJson.h>
#include <SoftwareSerial.h>
#include <LiquidCrystal.h>

const int rs = 13, en = 12, d4 = 11, d5 = 10, d6 = 9, d7 = 8;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);
const int buzzerPin = 3;
#define solenoidPin 2


#if (defined(__AVR__) || defined(ESP8266)) || defined(__AVR_ATmega2560__)
SoftwareSerial mySerial(A1, A0);
SoftwareSerial espSerial(6,7);
#else
#endif

const int pinButtonBlue = 4;  // Pinul la care este conectat butonul 1
const int pinButtonRed = 5;  // Pinul la care este conectat butonul 2
unsigned int option = -1;

Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);

uint8_t id;

int idArray[127];

void setup()
{
  pinMode(pinButtonRed, INPUT_PULLUP);  
  pinMode(pinButtonBlue, INPUT_PULLUP);
  pinMode(buzzerPin, OUTPUT);
  pinMode(solenoidPin, OUTPUT);
  digitalWrite(solenoidPin, HIGH);

  Serial.begin(9600);

  lcd.begin(16, 2);

  while (!Serial);  
  Serial.println("\n\n SRL");
  espSerial.begin(9600);
  finger.begin(57600);
  if (finger.verifyPassword()) {
    Serial.println("Found fingerprint sensor!");
  } else {
    Serial.println("Did not find fingerprint sensor :(");
    while (1) { delay(1); }
  }


  Serial.println(F("Reading sensor parameters"));
  finger.getParameters();
  Serial.print(F("Status: 0x")); Serial.println(finger.status_reg, HEX);
  Serial.print(F("Sys ID: 0x")); Serial.println(finger.system_id, HEX);
  Serial.print(F("Capacity: ")); Serial.println(finger.capacity);
  Serial.print(F("Security level: ")); Serial.println(finger.security_level);
  Serial.print(F("Device address: ")); Serial.println(finger.device_addr, HEX);
  Serial.print(F("Packet len: ")); Serial.println(finger.packet_len);
  Serial.print(F("Baud rate: ")); Serial.println(finger.baud_rate);
 
  finger.getTemplateCount();

    if (finger.templateCount == 0) {
      Serial.print("Sensor doesn't contain any fingerprint data. Please run the 'enroll' example.");
    }
    else {
      Serial.println("Waiting for valid finger...");
        Serial.print("Sensor contains "); Serial.print(finger.templateCount); Serial.println(" templates");
    }

   for (int indexId = 1; indexId < 128;indexId++)
   {
      idArray[indexId]=0;
   }

   for (int fingerId = 1; fingerId < 128; fingerId++) 
   {
    downloadFingerprintTemplate(fingerId);
   }
///////////////////
  Serial.println("All id stored");

  for ( int fingerId = 1; fingerId < 128; fingerId++)
  {
    if (idArray[fingerId] != 0)
    Serial.println(fingerId);
  }

}

uint8_t downloadFingerprintTemplate(uint16_t id)
{
  uint8_t p = finger.loadModel(id);
  switch (p) {
    case FINGERPRINT_OK:
     idArray[id] = 1;
      break;
    case FINGERPRINT_PACKETRECIEVEERR:
      return p;
    default:
      return p;
  }
  return p;
}

void loop()                   
{

  lcd.setCursor(0, 0);
  lcd.print("R - Acces");
  lcd.setCursor(0, 1);
  lcd.print("B - Inregistrare");

  if (digitalRead(pinButtonBlue) == LOW) {
    lcd.clear();

    lcd.println("Inregistrare...                ");

    for ( int fingerId = 1; fingerId < 128; fingerId++)
  {
    if (idArray[fingerId] == 0)
    {
       id=fingerId;
       Serial.println(id);
       break;
    }
  }
      Serial.print("Enrolling ID #");
      Serial.println(id);

      while (!  getFingerprintEnroll() );
  }

  if (digitalRead(pinButtonRed) == LOW) {
    option = -1;
    lcd.clear();
    lcd.setCursor(3, 0);
    lcd.print("Apropiati");
    lcd.setCursor(4, 1);
    lcd.print("degetul");
    while(option!=1)
    {
      getFingerprintID();
      delay(50);
    }  
  }
  
}


uint8_t getFingerprintEnroll() {

  int p = -1;

  while (p != FINGERPRINT_OK) {
    p = finger.getImage();
    switch (p) {
    case FINGERPRINT_OK:
      break;
    case FINGERPRINT_NOFINGER:
      Serial.println(".");
      break;
    case FINGERPRINT_PACKETRECIEVEERR:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Eroare la");
      lcd.setCursor(4, 1);
      lcd.print("comunicare");
      break;
    case FINGERPRINT_IMAGEFAIL:
      lcd.clear();
      lcd.setCursor(4, 0);
      lcd.print("Eroare");
      lcd.setCursor(4, 1);
      lcd.print("imagine");
      break;
    default:
      lcd.clear();
      lcd.setCursor(4, 0);
      lcd.print("Eroare");
      lcd.setCursor(3, 1);
      lcd.print("necunoscuta");
      break;
    }
  }

  p = finger.image2Tz(1);
  switch (p) {
    case FINGERPRINT_OK:
      lcd.clear();
      lcd.setCursor(8, 0);
      lcd.print("OK");
      break;
    case FINGERPRINT_IMAGEMESS:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Imagine");
      lcd.setCursor(3, 1);
      lcd.print("neclara");
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Eroare la");
      lcd.setCursor(4, 1);
      lcd.print("comunicare");
      return p;
    case FINGERPRINT_FEATUREFAIL:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Eroare la");
      lcd.setCursor(4, 1);
      lcd.print("comunicare");
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Imagine");
      lcd.setCursor(4, 1);
      lcd.print("invalida");
      return p;
    default:
      lcd.clear();
      lcd.setCursor(4, 0);
      lcd.print("Eroare");
      lcd.setCursor(3, 1);
      lcd.print("necunoscuta");
      return p;
  }

  lcd.clear();
  lcd.setCursor(3, 0);
  lcd.print("Indepartati");
  lcd.setCursor(4, 1);
  lcd.print("degetul");
  delay(2000);

  p = 0;
  while (p != FINGERPRINT_NOFINGER) {
    p = finger.getImage();
  }
  Serial.print("ID "); Serial.println(id);

  p = -1;

  lcd.clear();
  lcd.setCursor(3, 0);
  lcd.print("Apropiati");
  lcd.setCursor(1, 1);
  lcd.print("acelasi deget");
  while (p != FINGERPRINT_OK) {
    p = finger.getImage();
    switch (p) {
    case FINGERPRINT_OK:
      lcd.clear();
      lcd.setCursor(8, 0);
      lcd.print("OK");
      delay(2000);
      break;
    case FINGERPRINT_NOFINGER:
      Serial.print(".");
      break;
    case FINGERPRINT_PACKETRECIEVEERR:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Eroare la");
      lcd.setCursor(4, 1);
      lcd.print("comunicare");
      delay(2000);
      break;
    case FINGERPRINT_IMAGEFAIL:
      lcd.clear();
      lcd.setCursor(4, 0);
      lcd.print("Eroare");
      lcd.setCursor(4, 1);
      lcd.print("imagine");
      delay(2000);
      break;
    default:
      lcd.clear();
      lcd.setCursor(4, 0);
      lcd.print("Eroare");
      lcd.setCursor(3, 1);
      lcd.print("necunoscuta");
      delay(2000);
      break;
    }
  }

  p = finger.image2Tz(2);
  switch (p) {
    case FINGERPRINT_OK:
      lcd.clear();
      lcd.setCursor(4, 0);
      lcd.print("Imagine");
      lcd.setCursor(3, 1);
      lcd.print("Convertita");
      delay(2000);
      break;
    case FINGERPRINT_IMAGEMESS:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Imagine");
      lcd.setCursor(3, 1);
      lcd.print("neclara");
      delay(2000);
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Eroare la");
      lcd.setCursor(4, 1);
      lcd.print("comunicare");
      delay(2000);
      return p;
    case FINGERPRINT_FEATUREFAIL:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Eroare la");
      lcd.setCursor(4, 1);
      lcd.print("comunicare");
      delay(2000);
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Imagine");
      lcd.setCursor(4, 1);
      lcd.print("invalida");
      delay(2000);
      return p;
    default:
      lcd.clear();
      lcd.setCursor(4, 0);
      lcd.print("Eroare");
      lcd.setCursor(3, 1);
      lcd.print("necunoscuta");
      delay(2000);
      return p;
  }

  p = finger.createModel();
  if (p == FINGERPRINT_OK) {
    lcd.clear();
    lcd.setCursor(3, 0);
    lcd.print("Imaginile");
    lcd.setCursor(1, 1);
    lcd.print("s-au potrivit");
    delay(2000);
    lcd.clear();
  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    lcd.clear();
    lcd.setCursor(3, 0);
    lcd.print("Eroare la");
    lcd.setCursor(4, 1);
    lcd.print("comunicare");
    delay(2000);
    lcd.clear();
    return p;
  } else if (p == FINGERPRINT_ENROLLMISMATCH) {
    lcd.clear();
    lcd.setCursor(3, 0);
    lcd.print("Imaginile nu");
    lcd.setCursor(1, 1);
    lcd.print("s-au potrivit");
    delay(2000);
    lcd.clear();
    return p;
  } else {
    lcd.clear();
    lcd.setCursor(4, 0);
    lcd.print("Eroare");
    lcd.setCursor(3, 1);
    lcd.print("necunoscuta");
    delay(2000);
    lcd.clear();
    return p;
  }

  p = finger.storeModel(id);
  if (p == FINGERPRINT_OK) {
    lcd.clear();
    lcd.setCursor(2, 0);
    lcd.print("Inregistrare");
    lcd.setCursor(3, 1);
    lcd.print("cu succes!");
    // Trimite ID-ul la ESP8266
    espSerial.print("Enroll"+ String(id));
    delay(2000);
    lcd.clear();
  } else 
  {
    lcd.clear();
    lcd.setCursor(3, 0);
    lcd.print("Inregistrare");
    lcd.setCursor(4, 1);
    lcd.print("esuata");
    delay(2000);
    lcd.clear();
    return p;
  } 
  return true;
}

uint8_t getFingerprintID() {
  uint8_t p = finger.getImage();
  switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image taken");
      break;
    case FINGERPRINT_NOFINGER:
      Serial.println("No finger detected");
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      return p;
    case FINGERPRINT_IMAGEFAIL:
      Serial.println("Imaging error");
      return p;
    default:
      Serial.println("Unknown error");
      return p;
  }

  // OK success!

  p = finger.image2Tz();
  switch (p) {
    case FINGERPRINT_OK:
      break;
    case FINGERPRINT_IMAGEMESS:
       lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Imagine");
      lcd.setCursor(3, 1);
      lcd.print("neclara");
      delay(2000);
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Eroare la");
      lcd.setCursor(4, 1);
      lcd.print("comunicare");
      delay(2000);
      return p;
    case FINGERPRINT_FEATUREFAIL:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Eroare la");
      lcd.setCursor(4, 1);
      lcd.print("comunicare");
      delay(2000);
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      lcd.clear();
      lcd.setCursor(3, 0);
      lcd.print("Eroare la");
      lcd.setCursor(4, 1);
      lcd.print("comunicare");
      delay(2000);
      return p;
    default:
      lcd.clear();
      lcd.setCursor(4, 0);
      lcd.print("Eroare");
      lcd.setCursor(3, 1);
      lcd.print("necunoscuta");
      delay(2000);
      return p;
  }

  p = finger.fingerSearch();
  if (p == FINGERPRINT_OK) {

    tone(buzzerPin, 300,1000); // activez buzzer ul timp de 1 sec

    lcd.clear();
    lcd.setCursor(0, 0);
    lcd.print("Bine ati venit!");

    digitalWrite(solenoidPin, LOW);
    delay(5000);
    digitalWrite(solenoidPin, HIGH);

    lcd.clear();

    option=1;

  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    lcd.clear();
    lcd.setCursor(3, 0);
    lcd.print("Eroare la");
    lcd.setCursor(4, 1);
    lcd.print("comunicare");
    delay(2000);
    return p;
  } else if (p == FINGERPRINT_NOTFOUND) {
   
    option = 1;

    lcd.clear();
    lcd.setCursor(1, 0);
    lcd.print("Acces respins!");
    delay(2000);
    lcd.clear();

    return p;
  } else {
     lcd.clear();
     lcd.setCursor(4, 0);
     lcd.print("Eroare");
     lcd.setCursor(3, 1);
     lcd.print("necunoscuta");
    delay(2000);
    return p;
  }

  id=finger.fingerID;
  espSerial.print("Login"+ String(id));

  return finger.fingerID;
}



