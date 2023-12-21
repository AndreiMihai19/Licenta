#include <MySQL_Connection.h>
#include <MySQL_Cursor.h>
#include <ESP8266WiFi.h>
#include <SoftwareSerial.h>
#include <ArduinoJson.h>

#ifndef STASSID
#define STASSID "DIGI-6888"
#define STAPSK "7JpqVMzk"
#endif

SoftwareSerial s(D7,D6);

const char *ssid = STASSID;
const char *wifiPassword = STAPSK;

IPAddress server_addr(34,118,79,104); 
char user[] = "root"; 
char password[] = "andreiandreiandrei191919"; 

WiFiClient client;
MySQL_Connection conn((Client *)&client);

char INSERT_SQL[] = "INSERT INTO licenta.student (nume) VALUES (?)";


void setup() {


Serial.begin(115200);
s.begin(115200);

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

String value = " ";

void loop(){

  StaticJsonDocument<1000> jsonBuffer;
  DeserializationError error = deserializeJson(jsonBuffer, s);
  if (error)
    return;

   Serial.println("JSON received and parsed");
   serializeJsonPretty(jsonBuffer,Serial);
   Serial.print("Data 1");
   Serial.println(" ");
   String data1=jsonBuffer["data1"]; 
   value=data1; 
   Serial.print(data1);
   Serial.println("");
   Serial.println("----------xxxxx----------");

  if (data1!=" ")
  {
    insertDataIntoMySQL();
    return;
  }

  delay(5000);

}


void insertDataIntoMySQL() {
  Serial.println("Recording data into MySQL.");
  MySQL_Cursor *cur_mem = new MySQL_Cursor(&conn);

  // Construiește comanda SQL cu datele primite
  String sqlCmd = "INSERT INTO licenta.student (name) VALUES ('" + String(value) + "')";

  // Executează comanda SQL
  cur_mem->execute(sqlCmd.c_str());

  delete cur_mem;
}

