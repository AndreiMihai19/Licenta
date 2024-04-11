using MobileApp.Interfaces;
using MobileApp.Models;
using MobileApp.Services;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Repositories
{
    public class AuthenticationRepository : IAuthentication
    {
        private readonly string connectionString = "Server=34.78.19.175;Database=biometrichubaccess;Uid=root;Pwd=parolalicenta;";
        private readonly string email;
        private readonly string password;
        private IPasswordEncryptor passwordEncryptor;

        public AuthenticationRepository(string email, string password)
        {
            this.email = email;
            this.password = password;

        }

        public async Task<AuthenticationStatus> Authenticate()
        {
            if (string.IsNullOrEmpty(this.email) || string.IsNullOrEmpty(this.password))
            {
                return AuthenticationStatus.InvalidCredentials;
            }
            else
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {

                        await Task.Run(() => connection.Open());

                        passwordEncryptor = new PasswordEncryptor();
                        string encryptedPassword = passwordEncryptor.EncryptPassword(this.password);

                        MySqlCommand cmdValidate = new MySqlCommand("SELECT COUNT(*) FROM Angajati WHERE email = @email AND parola = @password", connection);
                        cmdValidate.Parameters.AddWithValue("@email", this.email);
                        cmdValidate.Parameters.AddWithValue("@password", encryptedPassword);


                        int count = Convert.ToInt32(cmdValidate.ExecuteScalar());

                        if (count > 0)
                        {
                            return AuthenticationStatus.Success;
                        }
                        else
                        {
                            return AuthenticationStatus.Failure;
                        }

                    }
                    catch(Exception ex) 
                    {
                        return AuthenticationStatus.DataBaseConnectionProblem;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public async Task<int> GetEmployeeId()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    await Task.Run(() => connection.Open());

                    MySqlCommand cmdGetId = new MySqlCommand("SELECT id FROM Angajati where email = @email", connection);
                    cmdGetId.Parameters.AddWithValue("@email", this.email);

                    MySqlDataReader reader = cmdGetId.ExecuteReader();

                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        return 0;
                    }

                }
                catch (Exception ex)
                {
                    return 0;
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
