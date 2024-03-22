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
        private readonly string connectionString = "Server=34.78.19.175;Database=biometrichubaccess;Uid=root;Pwd=parolalicenta;";
        private readonly string email;

        public ResetPasswordRepository(string email)
        {
            this.email = email;
        }

        public async Task<SendEmailStatus> SendPassword()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                return SendEmailStatus.InvalidCredentials;
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
                            return SendEmailStatus.Success;
                        }
                        else
                        {
                            return SendEmailStatus.Failure;
                        }

                    }
                    catch
                    {
                        return SendEmailStatus.DataBaseConnectionProblem;
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
