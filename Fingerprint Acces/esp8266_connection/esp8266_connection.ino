#include <MySQL_Connection.h>
#include <MySQL_Cursor.h>
#include <ESP8266WiFi.h>
#include <SoftwareSerial.h>
#include <ArduinoJson.h>

#ifndef STASSID
#define STASSID "Sam IL Yei"
#define STAPSK "camera503503camera"
#endif

//SoftwareSerial s(D7,D6);
SoftwareSerial espSerial(D7, D6);

const char *ssid = STASSID;
const char *wifiPassword = STAPSK;

IPAddress server_addr(34,118,79,104); 
char user[] = "root"; 
char password[] = "andreiandreiandrei191919"; 

WiFiClient client;
MySQL_Connection conn((Client *)&client);


void setup() {

Serial.begin(115200);
espSerial.begin(9600);

while (!Serial) continue;


Serial.println();
Serial.println();
Serial.print("Connecting to ");
Serial.println(ssid);


WiFi.mode(WIFI_STA);
WiFi.begin(ssid, wifiPassword);

while (WiFi.status() != WL_CONNECTED) 
  {
  delay(500);
  Serial.print(".");
  }
Serial.println("");
Serial.println("WiFi connected");
Serial.println("IP address: ");
Serial.println(WiFi.localIP());
Serial.println("Connecting...");

if (conn.connect(server_addr, 3306, user, password)) 
  {
   Serial.println("Connected to MySQL");
  } 
else 
  {
    Serial.println("Connection failed.");
    conn.close();
  }

}

String data=" ";
int id=0;

void loop(){

  if (espSerial.available() > 0) {
    data = espSerial.readStringUntil('\n');

    Serial.print("Date primite de la Arduino: ");
    Serial.println(data);
    id=data.toInt();
    updateIDIntoMySQL();
  }

}


void updateIDIntoMySQL() {
  Serial.println("Recording data into MySQL.");
  MySQL_Cursor *cur_mem = new MySQL_Cursor(&conn);

  String sqlCmd = "UPDATE licenta.Angajati SET id='" + String(id) + "' ORDER BY id DESC LIMIT 1";

  cur_mem->execute(sqlCmd.c_str());

  delete cur_mem;
}

