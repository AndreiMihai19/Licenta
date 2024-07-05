using AdministratorApplication.Services;
using AdministratorApplication.Interfaces;
using AdministratorApplication.Models;
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
        private readonly MySqlConnection connection = new MySqlConnection("Server=35.195.166.77;Port=3306;database=biometrichubaccess;User Id=root;Password=parolalicenta");
        private IPasswordEncryptor? passwordEncryptor;

        public RegistrationStatus Register(EmployeeModel e, string password)
        {
            DateTime currentTime = DateTime.Today;

            if (e.Id < 0 || string.IsNullOrEmpty(e.Email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(e.Prenume) || string.IsNullOrEmpty(e.Nume) || string.IsNullOrEmpty(e.DataNasterii) || string.IsNullOrEmpty(e.CNP) ||
                string.IsNullOrEmpty(e.Telefon) || string.IsNullOrEmpty(e.Functie) || e.Ore <= 0 || e.IsAdmin < 0)
            {
                return RegistrationStatus.InvalidCredentials;
            }
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string insertEmployee = "INSERT INTO Angajati(id,email,parola,nume,prenume,data_nasterii,telefon,cnp,functie,ore,admin) VALUES (@id,@email,@parola,@nume,@prenume,@data_nasterii,@telefon,@cnp,@functie,@ore,@admin)";
                    string insertEmployeeStatus = "INSERT INTO Status_angajati(id,ora_in,ora_pauza_in,ora_pauza_out,ora_out) VALUES (@id,@currentTime,@currentTime,@currentTime,@currentTime)";
                    MySqlCommand commandInsertEmployee = new MySqlCommand(insertEmployee, connection);
                    MySqlCommand commandInsertEmployeeStatus = new MySqlCommand(insertEmployeeStatus, connection);

                    passwordEncryptor = new PasswordEncryptor();
                    string encryptedPassword = passwordEncryptor.EncryptPassword(password);

                    commandInsertEmployee.Parameters.AddWithValue("@id", e.Id);
                    commandInsertEmployee.Parameters.AddWithValue("@email", e.Email);
                    commandInsertEmployee.Parameters.AddWithValue("@parola", encryptedPassword);
                    commandInsertEmployee.Parameters.AddWithValue("@nume", e.Nume);
                    commandInsertEmployee.Parameters.AddWithValue("@prenume", e.Prenume);
                    commandInsertEmployee.Parameters.AddWithValue("@data_nasterii", e.DataNasterii);
                    commandInsertEmployee.Parameters.AddWithValue("@telefon", e.Telefon);
                    commandInsertEmployee.Parameters.AddWithValue("@cnp", e.CNP);
                    commandInsertEmployee.Parameters.AddWithValue("@functie", e.Functie);
                    commandInsertEmployee.Parameters.AddWithValue("@ore", e.Ore);
                    commandInsertEmployee.Parameters.AddWithValue("@admin", e.IsAdmin);
                    commandInsertEmployee.ExecuteNonQuery();

                    commandInsertEmployeeStatus.Parameters.AddWithValue("@id", e.Id);
                    commandInsertEmployeeStatus.Parameters.AddWithValue("@currentTime", currentTime);
                    commandInsertEmployeeStatus.ExecuteNonQuery();

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
