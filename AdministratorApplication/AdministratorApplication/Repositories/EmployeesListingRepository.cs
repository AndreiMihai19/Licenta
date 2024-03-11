using AdministratorApplication.Classes;
using AdministratorApplication.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace AdministratorApplication.Repositories
{
    public class EmployeesListingRepository : IEmployeeslListing
    {
        private readonly MySqlConnection connection = new MySqlConnection("Server=34.78.19.175;Port=3306;database=biometrichubaccess;User Id=root;Password=parolalicenta");
        public void AddEmployees(List<Employee> employees)
        {

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string query = "SELECT id,email,nume,prenume,data_nasterii,telefon,cnp,functie,ore FROM Angajati";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string email = reader.GetString(1);
                        string lastName = reader.GetString(2);
                        string firstName = reader.GetString(3);
                        DateTime? dateOfBirth = reader.GetDateTime(4).Date;
                        string dataNastere = dateOfBirth.Value.ToString("dd-MM-yyyy");
                        string phoneNumber = reader.GetString(5);
                        string CNP = reader.GetString(6);
                        string jobPosition = reader.GetString(7);
                        int hours = reader.GetInt32(8);


                        Employee employee = new Employee()
                        {
                            Id = id,
                            Email = email,
                            //Parola = password,
                            Prenume = firstName,
                            Nume = lastName,
                            DataNasterii = dataNastere,
                            CNP = CNP,
                            Telefon = phoneNumber,
                            Functie = jobPosition,
                            Ore = hours
                        };

                        employees.Add(employee);

                    }
                }

            }
            catch(MySqlException ex) 
            {
            }
            finally
            {
                connection.Close();
            }

        }

        public void RemoveEmployee(Employee employee)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string insert = "INSERT INTO Angajati_stersi(id) VALUES (@id)";

                    MySqlCommand commandInsert = new MySqlCommand(insert, connection);
                    commandInsert.Parameters.AddWithValue("@id", employee.Id);
                    commandInsert.ExecuteNonQuery();


                    string query = "DELETE FROM Angajati WHERE id=@id";

                    MySqlCommand commandDelete = new MySqlCommand(query, connection);
                    commandDelete.Parameters.AddWithValue("@id", employee.Id);
                    commandDelete.ExecuteNonQuery();
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
