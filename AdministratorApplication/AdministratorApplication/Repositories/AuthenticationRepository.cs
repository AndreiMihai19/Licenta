﻿using AdministratorApplication.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Classes
{
    public class AuthenticationRepository : IAuthentication
    {
        private readonly MySqlConnection connection = new MySqlConnection("Server=34.78.19.175;Port=3306;database=biometrichubaccess;User Id=root;Password=parolalicenta");
        private string email;
        private string password;
        private IPasswordEncryptor? passwordEncryptor;

        public AuthenticationRepository(string email, string password)
        {
            this.email = email;
            this.password = password;

        }

        public AuthenticationStatus Authenticate()
        {
            if (string.IsNullOrEmpty(this.email) || string.IsNullOrEmpty(this.password))
            {
                return AuthenticationStatus.InvalidCredentials;
            }
            else
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();

                        passwordEncryptor = new PasswordEncryptor();
                        string encryptedPassword = passwordEncryptor.EncryptPassword(this.password);

                        MySqlCommand cmdValidate = new MySqlCommand("SELECT COUNT(*) FROM Angajati WHERE email = @email AND parola = @password", connection);
                        cmdValidate.Parameters.AddWithValue("@email", this.email);
                        cmdValidate.Parameters.AddWithValue("@password", encryptedPassword);

                        MySqlCommand cmdCheckAdmin = new MySqlCommand("SELECT admin FROM Angajati WHERE email = @email AND parola = @password", connection);
                        cmdCheckAdmin.Parameters.AddWithValue("@email", this.email);
                        cmdCheckAdmin.Parameters.AddWithValue("@password", encryptedPassword);

                        int count = Convert.ToInt32(cmdValidate.ExecuteScalar());
                        int adminValue = Convert.ToInt32(cmdCheckAdmin.ExecuteScalar());

                        if (count > 0 && adminValue == 1)
                        {
                            return AuthenticationStatus.Success;
                        }
                        else
                        {
                            return AuthenticationStatus.Failure;
                        }
                    }
                    else
                    {
                        return AuthenticationStatus.Failure;
                    }
                }
                catch
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
}
