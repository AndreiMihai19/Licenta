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

 
}

uint8_t readnumber(void) {
  uint8_t num = 0;

  while (num == 0) {
    while (! Serial.available());
    num = Serial.parseInt();
  }
  return num;
}

void loop()                   
{

  lcd.setCursor(0, 0);
  lcd.print("R - Acces");
  lcd.setCursor(0, 1);
  lcd.print("B - Inregistrare");
  
 if (espSerial.available()) { // Verificare dacă datele sunt disponibile pentru citire de la ESP
    char receivedChar = espSerial.read(); // Citirea caracterului de la ESP

    // Afisarea caracterului primit pe portul serial al Arduino
    Serial.print("Caracter primit de la ESP: ");
    Serial.println(receivedChar);
  }

  if (digitalRead(pinButtonBlue) == LOW) {
    lcd.clear();
    espSerial.end();
    
    lcd.println("Enroll...       ");

    delay(1000);  

      Serial.println("Ready to enroll a fingerprint!");
      lcd.println("Introduceti id:");
      id=readnumber();
      if (id == 0) {// ID #0 not allowed, try again!
        return;
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
  Serial.print("Waiting for valid finger to enroll as #"); Serial.println(id);
  while (p != FINGERPRINT_OK) {
    p = finger.getImage();
    switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image taken");
      break;
    case FINGERPRINT_NOFINGER:
      Serial.println(".");
      break;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      break;
    case FINGERPRINT_IMAGEFAIL:
      Serial.println("Imaging error");
      break;
    default:
      Serial.println("Unknown error");
      break;
    }
  }

  // OK success!

  p = finger.image2Tz(1);
  switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image converted");
      break;
    case FINGERPRINT_IMAGEMESS:
      Serial.println("Image too messy");
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      return p;
    case FINGERPRINT_FEATUREFAIL:
      Serial.println("Could not find fingerprint features");
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      Serial.println("Could not find fingerprint features");
      return p;
    default:
      Serial.println("Unknown error");
      return p;
  }

  Serial.println("Remove finger");
  delay(2000);
  p = 0;
  while (p != FINGERPRINT_NOFINGER) {
    p = finger.getImage();
  }
  Serial.print("ID "); Serial.println(id);
  p = -1;
  Serial.println("Place same finger again");
  while (p != FINGERPRINT_OK) {
    p = finger.getImage();
    switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image taken");
      break;
    case FINGERPRINT_NOFINGER:
      Serial.print(".");
      break;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      break;
    case FINGERPRINT_IMAGEFAIL:
      Serial.println("Imaging error");
      break;
    default:
      Serial.println("Unknown error");
      break;
    }
  }

  // OK success!

  p = finger.image2Tz(2);
  switch (p) {
    case FINGERPRINT_OK:
      Serial.println("Image converted");
      break;
    case FINGERPRINT_IMAGEMESS:
      Serial.println("Image too messy");
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      return p;
    case FINGERPRINT_FEATUREFAIL:
      Serial.println("Could not find fingerprint features");
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      Serial.println("Could not find fingerprint features");
      return p;
    default:
      Serial.println("Unknown error");
      return p;
  }

  // OK converted!
  Serial.print("Creating model for #");  Serial.println(id);

  p = finger.createModel();
  if (p == FINGERPRINT_OK) {
    Serial.println("Prints matched!");
  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    Serial.println("Communication error");
    return p;
  } else if (p == FINGERPRINT_ENROLLMISMATCH) {
    Serial.println("Fingerprints did not match");
    return p;
  } else {
    Serial.println("Unknown error");
    return p;
  }

  Serial.print("ID "); Serial.println(id);
  p = finger.storeModel(id);
  if (p == FINGERPRINT_OK) {
    Serial.println("Stored!");
    // Trimite ID-ul la ESP8266
     espSerial.print("Enroll"+ String(id));

  } else if (p == FINGERPRINT_PACKETRECIEVEERR) {
    Serial.println("Communication error");
    return p;
  } else if (p == FINGERPRINT_BADLOCATION) {
    Serial.println("Could not store in that location");
    return p;
  } else if (p == FINGERPRINT_FLASHERR) {
    Serial.println("Error writing to flash");
    return p;
  } else {
    Serial.println("Unknown error");
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
      Serial.println("Image converted");
      break;
    case FINGERPRINT_IMAGEMESS:
      Serial.println("Image too messy");
      return p;
    case FINGERPRINT_PACKETRECIEVEERR:
      Serial.println("Communication error");
      return p;
    case FINGERPRINT_FEATUREFAIL:
      Serial.println("Could not find fingerprint features");
      return p;
    case FINGERPRINT_INVALIDIMAGE:
      Serial.println("Could not find fingerprint features");
      return p;
    default:
      Serial.println("Unknown error");
      return p;
  }

  // OK converted!
  p = finger.fingerSearch();
  if (p == FINGERPRINT_OK) {
    Serial.println("Found a print match!");

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
    Serial.println("Communication error");
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
    Serial.println("Unknown error");
    return p;
  }

  // found a match!

  id=finger.fingerID;
  espSerial.print("Login"+ String(id));

  Serial.print("Found ID #"); Serial.print(finger.fingerID);
  Serial.print(" with confidence of "); Serial.println(finger.confidence);
  //option = 1;

  return finger.fingerID;
}

// returns -1 if failed, otherwise returns ID #
int getFingerprintIDez() {
  uint8_t p = finger.getImage();
  if (p != FINGERPRINT_OK)  return -1;

  p = finger.image2Tz();
  if (p != FINGERPRINT_OK)  return -1;

  p = finger.fingerFastSearch();
  if (p != FINGERPRINT_OK)  return -1;
 
  // found a match!
  Serial.print("Found ID #"); Serial.print(finger.fingerID);
  Serial.print(" with confidence of "); Serial.println(finger.confidence);
 
  return finger.fingerID;
}


