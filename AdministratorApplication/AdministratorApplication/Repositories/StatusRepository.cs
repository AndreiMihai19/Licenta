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

        /*
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
                     //   string password = reader.GetString(2);
                        string lastName = reader.GetString(2);
                        string firstName = reader.GetString(3);
                        string dateOfBirth = reader.GetString(4);
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
        */

        public int[] GetNumberOfEmployees()
        {
            int nrTotal = 0, nrActive= 0, nrInactive = 0;
            int[] numbersArray = new int[3];

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string queryTotal = "SELECT COUNT(*) FROM Angajati";
                    string queryActive = "SELECT COUNT(*) FROM  Valoare_timp WHERE valoare < 4";
                    string queryInactive = "SELECT COUNT(*) FROM Valoare_timp WHERE valoare = 4";

                    MySqlCommand commandTotal = new MySqlCommand(queryTotal, connection);
                    MySqlCommand commandActive = new MySqlCommand(queryActive, connection);
                    MySqlCommand commandInactive = new MySqlCommand(queryInactive, connection);

                    nrTotal = Convert.ToInt32(commandTotal.ExecuteScalar());
                    nrActive = Convert.ToInt32(commandActive.ExecuteScalar());
                    nrInactive = Convert.ToInt32(commandInactive.ExecuteScalar());

                    numbersArray[0]=nrTotal;
                    numbersArray[1]=nrActive;
                    numbersArray[2]=nrInactive;
                }

            }
            catch (MySqlException ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return numbersArray;
        }

       
    }
}
