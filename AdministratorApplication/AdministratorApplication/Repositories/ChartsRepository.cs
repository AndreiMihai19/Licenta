using AdministratorApplication.Interfaces;
using AdministratorApplication.Models;
using Google.Protobuf.WellKnownTypes;
using LiveCharts.Wpf.Charts.Base;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Repositories
{
    public class ChartsRepository : ICharts
    {
        private readonly MySqlConnection connection = new MySqlConnection("Server=34.78.19.175;Port=3306;database=biometrichubaccess;User Id=root;Password=parolalicenta");
       
        public string[] GetNamesOfEmployees()
        {
            List<string> listNames=new List<string>();

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string query = "SELECT DISTINCT Angajati.nume, Angajati.prenume FROM Angajati JOIN Registru_ore_angajati ON Angajati.id=Registru_ore_angajati.id_angajat GROUP BY Angajati.nume, Angajati.prenume;";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        string lastName = reader.GetString(0);
                        string firstName = reader.GetString(1);

                        listNames.Add(lastName + " " + firstName);
                    }
                }
            }

            catch (MySqlException ex)
            {
            }
            finally
            {
                connection.Close();
            }

            string[] names = listNames.ToArray();

            return names;
        }
        
        public void AddRegistryValues(List<RegistryChartModel> chart)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string query = "SELECT Angajati.nume, Angajati.prenume, Registru_ore_angajati.data, Registru_ore_angajati.ora_in," +
                        " Registru_ore_angajati.ora_pauza_in, Registru_ore_angajati.ora_pauza_out,Registru_ore_angajati.ora_out FROM Angajati JOIN " +
                        "Registru_ore_angajati ON Angajati.id=Registru_ore_angajati.id_angajat;";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        string lastName = reader.GetString(0);
                        string firstName = reader.GetString(1);

                        DateTime date = reader.GetDateTime(2);

                        DateTime? hourIn = reader.GetDateTime(3);
                        string _hourIn = $"{hourIn.Value.Hour:D2}.{hourIn.Value.Minute:D2}";

                        DateTime? breakHourIn = reader.GetDateTime(4);
                        string _breakHourIn = $"{breakHourIn.Value.Hour:D2}.{breakHourIn.Value.Minute:D2}";

                        DateTime? breakHourOut = reader.GetDateTime(5);
                        string _breakHourOut = $"{breakHourOut.Value.Hour:D2}.{breakHourOut.Value.Minute:D2}";

                        DateTime? hourOut = reader.GetDateTime(6);
                        string _hourOut = $"{hourOut.Value.Hour:D2}.{hourOut.Value.Minute:D2}";

                        int _month = date.Month;
                        int year = date.Year;

                        string numePrenume = lastName + " " + firstName;
                        double oraProgram1 = GetTime(_hourIn, _breakHourIn);
                        double oraPauza = GetTime(_breakHourIn, _breakHourOut);
                        double oraProgram2 = GetTime(_breakHourOut, _hourOut);
                        double totalOre = GetTotalHours(oraProgram1.ToString(), oraProgram2.ToString());
                        string month = string.Empty;

                        switch (_month)
                        {
                            case 1:
                                month = "ianuarie";
                                break;
                            case 2:
                                month = "februarie";
                                break;
                            case 3:
                                month = "martie";
                                break;
                            case 4:
                                month = "aprilie";
                                break;
                            case 5:
                                month = "mai";
                                break;
                            case 6:
                                month = "iunie";
                                break;
                            case 7:
                                month = "iulie";
                                break;
                            case 8:
                                month = "august";
                                break;
                            case 9:
                                month = "septembrie";
                                break;
                            case 10:
                                month = "octombrie";
                                break;
                            case 11:
                                month = "noiembrie";
                                break;
                            case 12:
                                month = "decembrie";
                                break;
                            default:
                                month = "invalid";
                                break;
                        }

                        RegistryChartModel registryChart = new RegistryChartModel
                        { 
                            NumePrenume = numePrenume,
                            Data = date.ToString("dd-MM-yyyy"),
                            OraProgram1 = oraProgram1,
                            OraPauza = oraPauza,
                            OraProgram2 = oraProgram2,
                            TotalOre = totalOre,
                            LunaCalendaristica = month,
                            Anul = year
                        };

                        chart.Add(registryChart);
                    }
                }
            }

            catch (MySqlException ex)
            {
            }
            finally
            {
                connection.Close();
            }
        }

        public double GetTime(string time1, string time2)
        {
            string[] _time1 = time1.Split('.');
            string[] _time2 = time2.Split('.');

            int t1_hour = Convert.ToInt32(_time1[0]);
            int t1_min = Convert.ToInt32(_time1[1]);

            int t2_hour = Convert.ToInt32(_time2[0]);
            int t2_min = Convert.ToInt32(_time2[1]);

            int h = t2_hour - t1_hour;
            int m;

            if (t1_min > t2_min)
            {
                h--;
                m = 60 - t1_min + t2_min;

            }
            else
            {
                m = t2_min - t1_min;
            }

            if (m < 10)
            {
                return double.Parse(Math.Abs(h).ToString() + ".0" + m.ToString());
            }
            else
            {
                return double.Parse(Math.Abs(h).ToString() + "." + m.ToString());
            }
        }

        public double GetTotalHours(string time1, string time2)
        {
            int t1_hour, t1_min, t2_hour, t2_min;
            string t1_min_str, t2_min_str;

            if (time1.Contains('.'))
            {
                string[] _time1 = time1.Split('.');
                t1_hour = Convert.ToInt32(_time1[0]);
                t1_min_str = _time1[1];

                t1_min = Convert.ToInt32(_time1[1]);

                if (t1_min_str.Length==1)
                {
                    t1_min *= 10;
                }

            }
            else
            {
                t1_hour = Convert.ToInt32(time1);
                t1_min = 0;
            }

            if (time2.Contains('.'))
            {
                string[] _time2 = time2.Split('.');
                t2_hour = Convert.ToInt32(_time2[0]);
                t2_min_str = _time2[1];


                t2_min = Convert.ToInt32(_time2[1]);

                if (t2_min_str[0] != '0' && t2_min_str.Length == 1)
                {
                    t2_min *= 10;
                }

            }
            else
            {
                t2_hour = Convert.ToInt32(time2);
                t2_min = 0;
            }

            int m = t1_min + t2_min;
            int h = t1_hour + t2_hour;
            
            if (h != 0)
            {
                h += m / 60;
            }

            m %= 60;

            if (m < 10)
            {
                return double.Parse(h.ToString() + ".0" + m.ToString());
            }
            else
            {
                return double.Parse(h.ToString() + "." + m.ToString());
            }
        }
    }
}
