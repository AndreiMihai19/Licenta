using AdministratorApplication.Services;
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
        private readonly MySqlConnection connection = new MySqlConnection("Server=35.195.166.77;Port=3306;database=biometrichubaccess;User Id=root;Password=parolalicenta");

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
