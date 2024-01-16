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
    public class StatusRepository : IStatus
    {
        private readonly MySqlConnection connection = new MySqlConnection("Server=34.118.79.104;Port=3306;database=licenta;User Id=root;Password=andreiandreiandrei191919");

        public void AddEmployees(List<Employee> employees)
        {

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string query = "SELECT id,email,parola,nume,prenume,data_nasterii,telefon,cnp,functie,ore FROM Angajati";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string email = reader.GetString(1);
                        string password = reader.GetString(2);
                        string lastName = reader.GetString(3);
                        string firstName = reader.GetString(4);
                        string dateOfBirth = reader.GetString(5);
                        string phoneNumber = reader.GetString(6);
                        string CNP = reader.GetString(7);
                        string jobPosition = reader.GetString(8);
                        int hours = reader.GetInt32(9);


                        Employee employee = new Employee()
                        {
                            Id = id,
                            Email = email,
                            Parola = password,
                            Prenume = firstName,
                            Nume = lastName,
                            DataNasterii = dateOfBirth,
                            CNP = CNP,
                            Telefon = phoneNumber,
                            Functie = jobPosition,
                            Ore = hours
                        };

                        employees.Add(employee);

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
        public int GetNumberOfEmployees(List<Employee> employees)
        {
            return employees.Count();
        }

    }
}
