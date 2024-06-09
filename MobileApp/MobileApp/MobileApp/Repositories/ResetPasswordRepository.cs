using MobileApp.Interfaces;
using MobileApp.Services;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Repositories
{
    public class ResetPasswordRepository : IResetPassword
    {
        private readonly string connectionString = "Server=35.195.166.77;Database=biometrichubaccess;Uid=root;Pwd=parolalicenta;";
        private readonly string email;
        private readonly string newPassword;
        private readonly string confirmPassword;
        private string encryptedPassword;
        private IPasswordEncryptor passwordEncryptor;

        public ResetPasswordRepository(string email)
        {
            this.email = email;
        }

        public ResetPasswordRepository(string email, string newPassword, string confirmPassword)
        {
            this.email = email;
            this.newPassword = newPassword;
            this.confirmPassword = confirmPassword;
        }

        public async Task<SendMailStatus> CheckEmail()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                return SendMailStatus.InvalidCredentials;
            }
            else
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        await Task.Run(() => connection.Open());

                        MySqlCommand cmdValidate = new MySqlCommand("SELECT COUNT(*) FROM Angajati WHERE email = @email", connection);
                        cmdValidate.Parameters.AddWithValue("@email", this.email);

                        int count = Convert.ToInt32(cmdValidate.ExecuteScalar());

                        if (count > 0)
                        {
                            return SendMailStatus.Success;
                        }
                        else
                        {
                            return SendMailStatus.Failure;
                        }

                    }
                    catch
                    {
                        return SendMailStatus.DataBaseConnectionProblem;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }


        public async Task<ResetPasswordStatus> ResetPassword()
        {
            if (string.IsNullOrEmpty(this.newPassword) || string.IsNullOrEmpty(this.confirmPassword))
            {
                return ResetPasswordStatus.InvalidCredentials;
            }
            else
            {
                passwordEncryptor = new PasswordEncryptor();
                encryptedPassword = passwordEncryptor.EncryptPassword(this.newPassword);

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        await Task.Run(() => connection.Open());

                        MySqlCommand cmdValidate = new MySqlCommand("UPDATE Angajati SET parola = @newPassword WHERE email = @email", connection);
                        cmdValidate.Parameters.AddWithValue("@email", this.email);
                        cmdValidate.Parameters.AddWithValue("@newPassword", encryptedPassword);

                        int rowsAffected = await cmdValidate.ExecuteNonQueryAsync();

                        return ResetPasswordStatus.Success;
                    }
                    catch
                    {
                        return ResetPasswordStatus.DataBaseConnectionProblem;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public int GenerateResetCode()
        {
            Random rstCode=new Random();
            int resetCode = rstCode.Next(100000, 999999);
            return resetCode;
        }
    }
}
