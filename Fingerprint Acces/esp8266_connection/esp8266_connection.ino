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


void setup() {

Serial.begin(9600);
espSerial.begin(9600);

while (!Serial) continue;

  ConnectToWiFi();

}

void ConnectToWiFi() {
  Serial.println("Încercăm să ne conectăm la o rețea WiFi...");
  
  for (int i = 0; i < numberOfSSID; i++) {
    Serial.print("Încercăm să ne conectăm la ");
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
      Serial.println("Conectat la rețeaua WiFi!");
      Serial.print("Adresa IP: ");
      Serial.println(WiFi.localIP());
      break;  // Ieșim din buclă dacă ne-am conectat cu succes
    } else {
      Serial.println("");
      Serial.println("Nu am reușit să ne conectăm la această rețea.");
      if (i == numberOfSSID - 1) {
        Serial.println("Nu am putut să ne conectăm la nicio rețea disponibilă.");
      }
    }
  }
  
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
    //    delay(1000);
      //  GetNameOfIDMySQL();
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

void GetNameOfIDMySQL()
{
    MySQL_Cursor *cur_mem = new MySQL_Cursor(&conn);
    char query[128];

    sprintf(query, "SELECT nume FROM biometrichubaccess.Angajati WHERE ID = '%d'", id);

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
                   // espSerial.print(String(row->values[i]));
                    Serial.print(String(row->values[i]));
                }
            }
        } while (row);
    }
    else
    {
        Serial.println("Nu s-au găsit coloane.");
    }

    // Eliberează resursele
    delete cur_mem;
}

void SendToDeleteIDMySQL()
{
    MySQL_Cursor *cur_mem = new MySQL_Cursor(&conn);
    char query[128];

    sprintf(query, "SELECT nume FROM biometrichubaccess.Angajati WHERE ID = '%d'", 1);

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
                    espSerial.print(String(row->values[i]));
                    Serial.print(String(row->values[i]));
                }
            }
        } while (row);
    }
    else
    {
        Serial.println("Nu s-au găsit coloane.");
    }

    // Eliberează resursele
    delete cur_mem;
}

