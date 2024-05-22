using AdministratorApplication.Employee_Status;
using AdministratorApplication.Interfaces;
using AdministratorApplication.Models;
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

            int[] numbersArray = status.GetNumberOfEmployees();

            card1.Number = numbersArray[0].ToString();
            card2.Number = numbersArray[1].ToString();
            card3.Number = numbersArray[2].ToString();

            tabStatus1.Content = new ListViewStatusControl();
            tabStatus2.Content = new Charts();
        }

        private void TabStatusControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
            // Afișează UserControl-ul corespunzător tab-ului selectat
            if (TabStatusControl.SelectedIndex == 0)
            {
                tabStatus1.Visibility = Visibility.Visible;
            }
            else if (TabStatusControl.SelectedIndex == 1)
            {
                tabStatus2.Visibility = Visibility.Visible;
            }
            //else if (myTabControl.SelectedIndex == 2)
            //{
            //    userControl3.Visibility = Visibility.Visible;
            //}
        }


    }
}
