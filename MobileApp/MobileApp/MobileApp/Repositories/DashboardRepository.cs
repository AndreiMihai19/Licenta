using MobileApp.Interfaces;
using MobileApp.Models;
using MobileApp.Services;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Repositories
{
    public class DashboardRepository : IDashboard
    {
        private readonly string connectionString = "Server=34.78.19.175;Database=biometrichubaccess;Uid=root;Pwd=parolalicenta;";
        private readonly string email;
        private readonly int id;
        public EmployeeModel employee;

        public DashboardRepository(string email, int id) 
        {
            this.email = email;
            this.id = id;
        }

        public async Task<EmployeeModel> GetEmployeeInfo()
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    await Task.Run(() => connection.Open());

                    string query = "SELECT Angajati.nume, Angajati.prenume, Angajati.functie, Angajati.ore, Status_angajati.ora_in, Status_angajati.ora_pauza_in," +
                        "Status_angajati.ora_pauza_out,Status_angajati.ora_out FROM Angajati CROSS JOIN Status_angajati ON Angajati.id=Status_angajati.id WHERE Angajati.email = @email;";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@email", this.email);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string lastName = reader.GetString(0);
                        string firstName = reader.GetString(1);
                        string email = this.email;
                        string job = reader.GetString(2);
                        int dayHours = reader.GetInt32(3);

                        DateTime? hourIn = reader.IsDBNull(4) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(4), TimeZoneInfo.Local);

                        string _hourIn = "0";

                        if (hourIn.HasValue)
                        {
                            int hour = hourIn.Value.Hour;
                            int minutes = hourIn.Value.Minute;
                            _hourIn = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? breakHourIn = reader.IsDBNull(5) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(5), TimeZoneInfo.Local);
                        string _breakHourIn = "0";

                        if (breakHourIn.HasValue)
                        {
                            int hour = breakHourIn.Value.Hour;
                            int minutes = breakHourIn.Value.Minute;
                            _breakHourIn = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? breakHourOut = reader.IsDBNull(6) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(6), TimeZoneInfo.Local);
                        string _breakHourOut = "0";

                        if (breakHourOut.HasValue)
                        {
                            int hour = breakHourOut.Value.Hour;
                            int minutes = breakHourOut.Value.Minute;
                            _breakHourOut = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? hourOut = reader.IsDBNull(7) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(7), TimeZoneInfo.Local);
                        string _hourOut = "0";

                        if (hourOut.HasValue)
                        {
                            int hour = hourOut.Value.Hour;
                            int minutes = hourOut.Value.Minute;
                            _hourOut = $"{hour:D2}:{minutes:D2}";
                        }

                        string totalHours;

                        if (_hourIn != "0" && _breakHourIn != "0" && _breakHourOut != "0" && _hourOut != "0")
                            totalHours = GetTotalHours(GetTime(_hourIn.ToString(), _breakHourIn.ToString()), GetTime(_breakHourOut.ToString(), _hourOut.ToString()));
                        else
                            totalHours = "0";

                        if (totalHours == "0:0")
                            totalHours = "0";

                        employee = new EmployeeModel()
                        {
                            EmployeeId = this.id,
                            Prenume = firstName,
                            Nume = lastName,
                            Email = email,
                            Functie = job,
                            OreZi = dayHours,
                            OraIn = _hourIn,
                            PauzaIn = _breakHourIn,
                            PauzaOut = _breakHourOut,
                            OraOut = _hourOut,
                            TotalOreLucrate = totalHours,
                        };


                    }
                }
                catch (MySqlException ex)
                {
                    employee = new EmployeeModel()
                    {
                        EmployeeId = 0,
                        Prenume = "",
                        Nume = "",
                        Email = "",
                        Functie = "",
                        OreZi = 0,
                        OraIn = "",
                        PauzaIn = "",
                        PauzaOut = "",
                        OraOut = "",
                        TotalOreLucrate = "0",
                    };

                    return employee;
                }
                finally
                {
                    connection.Close();
                  
                }
                return employee;
            }
        }

        
        public string GetTime(string time1, string time2)
        {
            string[] _time1 = time1.Split(':');
            string[] _time2 = time2.Split(':');

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
                return Math.Abs(h).ToString() + ":0" + m.ToString();
            }
            else
            {
                return Math.Abs(h).ToString() + ":" + m.ToString();
            }

        }
        

        public string GetTotalHours(string time1, string time2)
        {
            int t1_hour, t1_min, t2_hour, t2_min;
            string t1_min_str, t2_min_str;

            if (time1.Contains(':'))
            {
                string[] _time1 = time1.Split(':');
                t1_hour = Convert.ToInt32(_time1[0]);
                t1_min_str = _time1[1];

                t1_min = Convert.ToInt32(_time1[1]);

                if (t1_min_str.Length == 1)
                {
                    t1_min *= 10;
                }

            }
            else
            {
                t1_hour = Convert.ToInt32(time1);
                t1_min = 0;
            }

            if (time2.Contains(':'))
            {
                string[] _time2 = time2.Split(':');
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
                t2_hour = Convert.ToInt32(time1);
                t2_min = 0;
            }




            int m = t1_min + t2_min;
            int h = t1_hour + t2_hour;

            if (h != 0)
            {
                h += m / 60;
            }

            m %= 60;

            if (m<10)
            {
                return h.ToString() + ":0" + m.ToString();
            }
            else
            {
                return h.ToString() + ":" + m.ToString();
            }

        }



        public async Task<string> GetHoursByMonth(int id, int month)
        {
            string _hoursByMonth = "", hoursByMonth = "00:00";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    await Task.Run(() => connection.Open());

                    string query = "SELECT ora_in,ora_pauza_in, ora_pauza_out,ora_out FROM Registru_ore_angajati WHERE id_angajat=@id AND MONTH(data) = @month;";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@month", month);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                    
                        DateTime? clockIn = reader.IsDBNull(0) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(0), TimeZoneInfo.Local);

                        string _clockIn = "0";

                        if (clockIn.HasValue)
                        {
                            int hour = clockIn.Value.Hour;
                            int minutes = clockIn.Value.Minute;
                            _clockIn = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? startBreak = reader.IsDBNull(1) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(1), TimeZoneInfo.Local);
                        string _startBreak = "0";

                        if (startBreak.HasValue)
                        {
                            int hour = startBreak.Value.Hour;
                            int minutes = startBreak.Value.Minute;
                            _startBreak = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? endBreak = reader.IsDBNull(2) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(2), TimeZoneInfo.Local);
                        string _endBreak = "0";

                        if (endBreak.HasValue)
                        {
                            int hour = endBreak.Value.Hour;
                            int minutes = endBreak.Value.Minute;
                            _endBreak = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? clockOut = reader.IsDBNull(3) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(3), TimeZoneInfo.Local);
                        string _clockOut = "0";

                        if (clockOut.HasValue)
                        {
                            int hour = clockOut.Value.Hour;
                            int minutes = clockOut.Value.Minute;
                            _clockOut = $"{hour:D2}:{minutes:D2}";
                        }


                        _hoursByMonth = GetTotalHours(GetTime(_clockIn, _startBreak), GetTime(_endBreak, _clockOut));
                        hoursByMonth = GetTotalHours(_hoursByMonth, hoursByMonth);
                    }
                }
                catch (MySqlException ex)
                {
                    hoursByMonth = "00:00";
                }
                finally
                {
                    connection.Close();
                }

                return hoursByMonth;
            }
        }
    }
}
