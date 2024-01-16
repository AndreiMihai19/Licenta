using AdministratorApplication.Classes;
using AdministratorApplication.Interfaces;
using AdministratorApplication.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdministratorApplication.Pages
{
    /// <summary>
    /// Interaction logic for StatusPage.xaml
    /// </summary>
    public partial class StatusPage : Page
    {
        private IStatus? status;

        List<Employee> employees = new List<Employee>();
        public StatusPage()
        {
            InitializeComponent();

            status = new StatusRepository();

            status.AddEmployees(employees);

            UpdateNumberOfEmployees();
        }

        private void UpdateNumberOfEmployees()
        {
            nrOfEmployees.Text = status.GetNumberOfEmployees(employees).ToString();
        }
    }
}
