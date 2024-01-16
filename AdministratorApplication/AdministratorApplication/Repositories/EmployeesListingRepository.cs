using AdministratorApplication.Classes;
using AdministratorApplication.Interfaces;
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

namespace AdministratorApplication.Repositories
{
    public class EmployeesListingRepository : IEmployeeslListing
    {
        private readonly MySqlConnection connection = new MySqlConnection("Server=34.118.79.104;Port=3306;database=licenta;User Id=root;Password=andreiandreiandrei191919");
        private BackgroundWorker backgroundWorker;
        private ProgressBar progressBar;
        public void AddEmployees(List<Employee> employees)
        {

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string query = "SELECT id,email,parola,nume,prenume,data_nasterii,telefon,cnp,functie,ore FROM Angajati";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    MySqlDataReader reader = command.ExecuteReader();

                    backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += BackgroundWorker_DoWork;
                    backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;


                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string email = reader.GetString(1);
                        string password = reader.GetString(2);
                        string lastName = reader.GetString(3);
                        string firstName = reader.GetString(4);
                        string dateOfBirth = reader.GetString(5);
                        string phoneNumber = reader.GetString(6);
                        string CNP = reader.GetString(7);
                        string jobPosition = reader.GetString(8);
                        int hours = reader.GetInt32(9);


                        Employee employee = new Employee()
                        {
                            Id = id,
                            Email = email,
                            Parola = password,
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
            catch(MySqlException ex) 
            {
            }
            finally
            {
                connection.Close();
            }

        }

        public void RemoveEmployee(Employee employee)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                    string query = "DELETE FROM Angajati WHERE id=@id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", employee.Id);
                    command.ExecuteNonQuery();
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

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Operațiunea lungă (simulată prin așteptarea a 5 secunde)
            Thread.Sleep(5000);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Finalizarea operațiunii, actualizare UI sau alte acțiuni
            progressBar.Visibility = Visibility.Hidden;
            MessageBox.Show("Operațiune finalizată!", "Finalizat", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ButonInterogare_Click(object sender, RoutedEventArgs e)
        {
            progressBar = new ProgressBar
            {
                IsIndeterminate = true,
                Visibility = Visibility.Visible
            };

            // Adăugare ProgressBar la grid (asumând că grid-ul se numește "gridPrincipal")
            //gridPrincipal.Children.Add(progressBar);

            // Pornirea BackgroundWorker-ului pentru a executa operațiunea în fundal
            backgroundWorker.RunWorkerAsync();
        }

    }
}
