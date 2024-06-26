﻿using AdministratorApplication.Interfaces;
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
using AdministratorApplication.Models;
using System.IO.Ports;

namespace AdministratorApplication.Repositories
{
    public class EmployeesListingRepository : IEmployeeslListing
    {
        private readonly MySqlConnection connection = new MySqlConnection("Server=35.195.166.77;Port=3306;database=biometrichubaccess;User Id=root;Password=parolalicenta");

        public void AddEmployees(List<EmployeeModel> employees)
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


                        EmployeeModel employee = new EmployeeModel()
                        {
                            Id = id,
                            Email = email,
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

        public void RemoveEmployee(EmployeeModel employee)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string delete = "DELETE FROM Angajati WHERE id=@id";

                    MySqlCommand commandDelete = new MySqlCommand(delete, connection);
                    commandDelete.Parameters.AddWithValue("@id", employee.Id);
                    commandDelete.ExecuteNonQuery();

                    string deleteRegister = "DELETE FROM Registru_ore_angajati WHERE id_angajat=@id";

                    MySqlCommand commandDeleteRegister = new MySqlCommand(deleteRegister, connection);
                    commandDeleteRegister.Parameters.AddWithValue("@id", employee.Id);
                    commandDeleteRegister.ExecuteNonQuery();


                    string deleteStatus = "DELETE FROM Status_angajati WHERE id=@id";

                    MySqlCommand commandDeleteFromStatus = new MySqlCommand(deleteStatus, connection);
                    commandDeleteFromStatus.Parameters.AddWithValue("@id", employee.Id);
                    commandDeleteFromStatus.ExecuteNonQuery();

                    string deleteTimeValue = "DELETE FROM Valoare_timp WHERE id=@id";

                    MySqlCommand commandDeleteValueTime = new MySqlCommand(deleteTimeValue, connection);
                    commandDeleteValueTime.Parameters.AddWithValue("@id", employee.Id);
                    commandDeleteValueTime.ExecuteNonQuery();

                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Stergerea nu s-a putut realiza!");
            }
            finally
            {
                connection.Close();
            }

        }



      
    }
}
