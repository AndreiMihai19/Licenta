using AdministratorApplication.Classes;
using AdministratorApplication.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Repositories
{
    public class EmployeesListingStatusRepository : IEmployeesListingStatusRepository
    {
        private readonly MySqlConnection connection = new MySqlConnection("Server=34.118.79.104;Port=3306;database=licenta;User Id=root;Password=andreiandreiandrei191919");

        public void AddStatus(List<Status> status)
        {

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string query = "SELECT Angajati.id, Angajati.nume, Angajati.prenume, Status_angajati.ora_in, Status_angajati.ora_pauza_in," +
                        "Status_angajati.ora_pauza_out,Status_angajati.ora_out FROM Angajati CROSS JOIN Status_angajati ON Angajati.id=Status_angajati.id;";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string lastName = reader.GetString(1);
                        string firstName = reader.GetString(2);
                        DateTime? hourIn = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
                        string _hourIn = "0";

                        if (hourIn.HasValue)
                        {
                            int hour = hourIn.Value.Hour;
                            int minutes = hourIn.Value.Minute;
                            _hourIn = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? breakHourIn = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);
                        string _breakHourIn = "0";

                        if (breakHourIn.HasValue)
                        {
                            int hour = breakHourIn.Value.Hour;
                            int minutes = breakHourIn.Value.Minute;
                            _breakHourIn = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? breakHourOut = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5);
                        string _breakHourOut = "0";

                        if (breakHourOut.HasValue)
                        {
                            int hour = breakHourOut.Value.Hour;
                            int minutes = breakHourOut.Value.Minute;
                            _breakHourOut = $"{hour:D2}:{minutes:D2}";
                        }

                        DateTime? hourOut = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6);
                        string _hourOut = "0";

                        if (hourOut.HasValue)
                        {
                            int hour = hourOut.Value.Hour;
                            int minutes = hourOut.Value.Minute;
                            _hourOut = $"{hour:D2}:{minutes:D2}";
                        }

                        Status s= new Status()
                        {
                            Id = id,
                            Prenume = firstName,
                            Nume = lastName,
                            OraIn = _hourIn,
                            OraPauzaIn = _breakHourIn,
                            OraPauzaOut = _breakHourOut,
                            OraOut = _hourOut,
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
