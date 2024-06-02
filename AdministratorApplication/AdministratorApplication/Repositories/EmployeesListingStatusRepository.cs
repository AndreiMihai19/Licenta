using AdministratorApplication.Interfaces;
using AdministratorApplication.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Repositories
{
    public class EmployeesListingStatusRepository : IEmployeesListingStatus
    {
        private readonly MySqlConnection connection = new MySqlConnection("Server=34.78.19.175;Port=3306;database=biometrichubaccess;User Id=root;Password=parolalicenta");

        public void AddStatus(List<StatusModel> status)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string query = "SELECT Angajati.id, Angajati.nume, Angajati.prenume, Status_angajati.ora_in, Status_angajati.ora_pauza_in," +
                        "Status_angajati.ora_pauza_out,Status_angajati.ora_out FROM Angajati INNER JOIN Status_angajati ON Angajati.id=Status_angajati.id;";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string lastName = reader.GetString(1);
                        string firstName = reader.GetString(2);
                        DateTime? hourIn = reader.IsDBNull(3) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(3), TimeZoneInfo.Local);

                        string _hourIn = "0";

                        if (hourIn.HasValue)
                        {
                            int hour = hourIn.Value.Hour;
                            int minutes = hourIn.Value.Minute;
                            _hourIn = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? breakHourIn = reader.IsDBNull(4) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(4), TimeZoneInfo.Local);
                        string _breakHourIn = "0";

                        if (breakHourIn.HasValue)
                        {
                            int hour = breakHourIn.Value.Hour;
                            int minutes = breakHourIn.Value.Minute;
                            _breakHourIn = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? breakHourOut = reader.IsDBNull(5) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(5), TimeZoneInfo.Local);
                        string _breakHourOut = "0";

                        if (breakHourOut.HasValue)
                        {
                            int hour = breakHourOut.Value.Hour;
                            int minutes = breakHourOut.Value.Minute;
                            _breakHourOut = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? hourOut = reader.IsDBNull(6) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(6), TimeZoneInfo.Local);
                        string _hourOut = "0";

                        if (hourOut.HasValue)
                        {
                            int hour = hourOut.Value.Hour;
                            int minutes = hourOut.Value.Minute;
                            _hourOut = $"{hour:D2}:{minutes:D2}";
                        }

                        StatusModel s= new StatusModel()
                        {
                            Id = id,
                            Prenume = firstName,
                            Nume = lastName,
                            ClockIn = _hourIn,
                            StartBreak = _breakHourIn,
                            EndBreak = _breakHourOut,
                            ClockOut = _hourOut,
                        };

                        status.Add(s);
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
    }
}
