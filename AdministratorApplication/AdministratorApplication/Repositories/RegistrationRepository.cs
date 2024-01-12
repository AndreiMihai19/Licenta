using AdministratorApplication.Classes;
using AdministratorApplication.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdministratorApplication.Repositories
{
    public class RegistrationRepository : IRegistration
    {
        private readonly MySqlConnection connection = new MySqlConnection("Server=34.118.79.104;Port=3306;database=licenta;User Id=root;Password=andreiandreiandrei191919");

        public RegistrationStatus Register(Employee e) 
        {
            if (e.Id < 0 || string.IsNullOrEmpty(e.Email) || string.IsNullOrEmpty(e.Password) || string.IsNullOrEmpty(e.FirstName) || string.IsNullOrEmpty(e.LastName) || string.IsNullOrEmpty(e.DateOfBirth) || string.IsNullOrEmpty(e.CNP) || string.IsNullOrEmpty(e.PhoneNumber) || string.IsNullOrEmpty(e.JobPosition) || e.Hours < 0)
            {
                return RegistrationStatus.InvalidCredentials;
            }


            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string query = "INSERT INTO Angajati(id,email,parola,nume,prenume,data_nasterii,telefon,cnp,functie,ore) VALUES (@id,@email,@parola,@nume,@prenume,@data_nasterii,@telefon,@cnp,@functie,@ore)";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("id", e.Id);
                    command.Parameters.AddWithValue("@email", e.Email);
                    command.Parameters.AddWithValue("@parola", e.Password);
                    command.Parameters.AddWithValue("@nume", e.LastName);
                    command.Parameters.AddWithValue("@prenume", e.FirstName);
                    command.Parameters.AddWithValue("@data_nasterii", e.DateOfBirth);
                    command.Parameters.AddWithValue("@telefon", e.PhoneNumber);
                    command.Parameters.AddWithValue("@cnp", e.CNP);
                    command.Parameters.AddWithValue("@functie", e.JobPosition);
                    command.Parameters.AddWithValue("@ore", e.Hours);
                    command.ExecuteNonQuery();

                    return RegistrationStatus.Success;
                }
             
                else
                {
                    return RegistrationStatus.Failure;
                }
            }
            catch
            {
                return RegistrationStatus.DataBaseConnectionProblem;
            }
            finally
            {
                connection.Close();
            }

        }

    }
}
