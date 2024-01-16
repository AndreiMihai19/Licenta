using AdministratorApplication.Classes;
using AdministratorApplication.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Repositories
{
    public class ModifierRepository :  IModifier
    {
        private readonly MySqlConnection connection = new MySqlConnection("Server=34.118.79.104;Port=3306;database=licenta;User Id=root;Password=andreiandreiandrei191919");

        bool isModified = false;

        public ModifierStatus ModifyEmployeeInfo(int? id, string currentJobPosition, string email, string password, string phoneNumber, string newJobPosition, int hours)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password) && string.IsNullOrEmpty(phoneNumber) && string.IsNullOrEmpty(newJobPosition) && (hours != 4 || hours != 6 || hours != 8))
            {
                return ModifierStatus.Failure;
            }
            else
            {
                try
                {

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();

                        if (!string.IsNullOrEmpty(email)) 
                        {
                            string queryEmailUp = "UPDATE Angajati SET email=@email WHERE id=@id";
                            MySqlCommand command = new MySqlCommand(queryEmailUp, connection);
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@email", email);
                            command.ExecuteNonQuery();
                            isModified = true;
                        }

                        if (!string.IsNullOrEmpty(password))
                        {
                            string queryPasswordUp = "UPDATE Angajati SET parola=@parola WHERE id=@id";
                            MySqlCommand command = new MySqlCommand(queryPasswordUp, connection);
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@parola", password);
                            command.ExecuteNonQuery();
                            isModified = true;
                        }

                        if (!string.IsNullOrEmpty(phoneNumber))
                        {
                            string queryPhoneNumberUp = "UPDATE Angajati SET telefon=@telefon WHERE id=@id";
                            MySqlCommand command = new MySqlCommand(queryPhoneNumberUp, connection);
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@telefon", phoneNumber);
                            command.ExecuteNonQuery();
                            isModified = true;
                        }

                        if (!string.IsNullOrEmpty(newJobPosition) && (newJobPosition.CompareTo(currentJobPosition) != 0))
                        {
                            string queryJobPositionUp = "UPDATE Angajati SET functie=@functie WHERE id=@id";
                            MySqlCommand command = new MySqlCommand(queryJobPositionUp, connection);
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@functie", newJobPosition);
                            command.ExecuteNonQuery();
                            isModified = true;
                        }

                        if (hours == 4 || hours == 6 || hours == 8)
                        {
                            string queryHoursUp = "UPDATE Angajati SET ore=@ore WHERE id=@id";
                            MySqlCommand command = new MySqlCommand(queryHoursUp, connection);
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@ore", hours);
                            command.ExecuteNonQuery();
                            isModified = true;
                        }
                    }

                    if (isModified) 
                    {
                        return ModifierStatus.Success;
                    }
                    else
                    {
                        return ModifierStatus.Failure;
                    }

                }
                catch (MySqlException)
                {
                    return ModifierStatus.DataBaseConnectionProblem;
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
