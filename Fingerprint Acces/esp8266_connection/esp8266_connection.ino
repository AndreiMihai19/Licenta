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

String dataFromArduino=" ";
int id=0;

void loop(){

  if (espSerial.available() > 0) {
    dataFromArduino = espSerial.readStringUntil('\n');

    Serial.print("Date primite de la Arduino: ");
    Serial.println(dataFromArduino);


    int indexOfEnroll = dataFromArduino.indexOf("Enroll");
    int indexOfLogin = dataFromArduino.indexOf("Login");

    if (indexOfEnroll != -1)
    {
      int indexOfNumber = indexOfEnroll + 6;
      String numberData = dataFromArduino.substring(indexOfNumber);
      id = numberData.toInt();
      UpdateIDIntoMySQL();
      
    }

    if (indexOfLogin != -1)
    {
      int indexOfNumber = indexOfLogin + 5;
      String numberData = dataFromArduino.substring(indexOfNumber);
      id = numberData.toInt();
      if (id != 0) 
      {
       // GetNameOfIDMySQL();
      }
    }
     
  }

}


void UpdateIDIntoMySQL() 
{
  Serial.println("Recording data into MySQL.");
  MySQL_Cursor *cur_mem = new MySQL_Cursor(&conn);

  String sqlCmd = "UPDATE licenta.Angajati SET id='" + String(id) + "' ORDER BY id DESC LIMIT 1";

  cur_mem->execute(sqlCmd.c_str());

  delete cur_mem;
}

void GetNameOfIDMySQL()
{
    MySQL_Cursor *cur_mem = new MySQL_Cursor(&conn);
    char query[128];

    sprintf(query, "SELECT nume FROM licenta.Angajati WHERE ID = '%d'", id);

    cur_mem->execute(query);

    // Citeste coloanele
    column_names *columns = cur_mem->get_columns();

    int numColumns = columns->num_fields;

    // Verifică dacă există coloane
    if (numColumns > 0)
    {
        row_values *row = NULL;

        do
        {
            row = cur_mem->get_next_row();
            if (row)
            {
                // Accesează valorile coloanelor
                for (int i = 0; i < numColumns; i++)
                {
                    Serial.print(row->values[i]);
                }
            }
        } while (row);
    }
    else
    {
        Serial.println("Nu s-au găsit coloane.");
    }

    // Eliberează resursele
    delete columns;
    delete cur_mem;
}

