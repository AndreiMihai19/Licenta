#include <MySQL_Connection.h>
#include <MySQL_Cursor.h>
#include <ESP8266WiFi.h>
#include <SoftwareSerial.h>
#include <ArduinoJson.h>

SoftwareSerial espSerial(D7, D6);

const char *ssid[] = {"LinksysB019","Sam IL Yei","DIGI-6888"};
const char *wifiPassword[] = {"wm83y3fby4","camera503503camera","7JpqVMzk"};
const int numberOfSSID=3;

IPAddress server_addr(34,78,19,175); 
char user[] = "root"; 
char password[] = "parolalicenta"; 

WiFiClient client;
MySQL_Connection conn((Client *)&client);

String dataFromArduino=" ";
int id=0;

void setup() {

Serial.begin(9600);
espSerial.begin(9600);

while (!Serial) continue;

ConnectToWiFi();
}

void ConnectToWiFi() {
  Serial.println("Incercam sa ne conectam la o rețea WiFi...");
  
  for (int i = 0; i < numberOfSSID; i++) {
    Serial.print("Incercam sa ne conectam la ");
    Serial.println(ssid[i]);
    
    WiFi.begin(ssid[i], wifiPassword[i]);

    int testing = 0;
    while (WiFi.status() != WL_CONNECTED && testing < 20) {
      delay(500);
      Serial.print(".");
      testing++;
    }

    if (WiFi.status() == WL_CONNECTED) {
      Serial.println("");
      Serial.println("Conectat la reteaua WiFi!");
      Serial.print("Adresa IP: ");
      Serial.println(WiFi.localIP());
      break;  
    } else {
      Serial.println("");
      Serial.println("Nu am reusit sa ne conectam la aceasta retea.");
      if (i == numberOfSSID - 1) {
        Serial.println("Nu am putut sa ne conectam la nicio retea disponibila.");
      }
    }
  }
  
  if (conn.connect(server_addr, 3306, user, password)) 
    {
    Serial.println("Connectat la MySQL");
    } 
  else 
    {
      Serial.println("Conectare esuata.");
      conn.close();
    }
}

void loop()
{
  if (espSerial.available() > 0) {
    dataFromArduino = espSerial.readStringUntil('\n');
    Serial.print("Date primite de la Arduino: ");
    Serial.println(dataFromArduino);
    espSerial.flush();

    int indexOfEnroll = dataFromArduino.indexOf("Enroll");
    int indexOfLogin = dataFromArduino.indexOf("Login");

    if (indexOfEnroll != -1)
    {
      int indexOfNumber = indexOfEnroll + 6;
      String numberData = dataFromArduino.substring(indexOfNumber);
      id = numberData.toInt();
      UpdateIDIntoMySQL();
      InsertInTimeValueIntoMySQL();
      InsertInStatusEmployeesIntoMySQL();
    }

    if (indexOfLogin != -1)
    {
      int indexOfNumber = indexOfLogin + 5;
      String numberData = dataFromArduino.substring(indexOfNumber);
      id = numberData.toInt();
      if (id != 0) 
      {
        UpdateTimeValueIntoMySQL();
      }
    }
  }
}

void UpdateIDIntoMySQL() 
{
  MySQL_Cursor *cur_mem = new MySQL_Cursor(&conn);

  String sqlCmd = "UPDATE biometrichubaccess.Angajati SET id='" + String(id) + "' ORDER BY id DESC LIMIT 1";

  cur_mem->execute(sqlCmd.c_str());

  delete cur_mem;
}

void UpdateTimeValueIntoMySQL() 
{
  MySQL_Cursor *cur_mem = new MySQL_Cursor(&conn);

  String sqlCmd = "UPDATE biometrichubaccess.Valoare_timp SET valoare = CASE WHEN valoare < 4 THEN valoare + 1 ELSE 1 END WHERE id = '" + String(id) + "'";

  cur_mem->execute(sqlCmd.c_str());

  delete cur_mem;
}

void InsertInStatusEmployeesIntoMySQL()
{
  MySQL_Cursor *cur_mem = new MySQL_Cursor(&conn);

  String sqlCmd = "INSERT INTO biometrichubaccess.Status_angajati (id) VALUES ('" + String(id) + "')";

  cur_mem->execute(sqlCmd.c_str());

  delete cur_mem;
}

void InsertInTimeValueIntoMySQL()
{
  MySQL_Cursor *cur_mem = new MySQL_Cursor(&conn);

  String sqlCmd = "INSERT INTO biometrichubaccess.Valoare_timp (id,valoare) VALUES ('" + String(id) + "','" + String(0) + "')";

  cur_mem->execute(sqlCmd.c_str());

  delete cur_mem;
}


