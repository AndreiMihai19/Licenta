using AdministratorApplication.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using ZstdSharp.Unsafe;

namespace AdministratorApplication
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private Type currentPageType;

        public MenuWindow()
        {
            InitializeComponent();

            currentPageType = typeof(StatusPage);
            Main.Content = new StatusPage();
        }

        private void BtnEmployees_Click(object sender, RoutedEventArgs e)
        {
            currentPageType = typeof(EmployeesPage);
            Main.Content = new EmployeesPage();
        }

        private void BtnEmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            currentPageType = typeof(EmployeeRegistrationPage);
            Main.Content = new EmployeeRegistrationPage();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnStatus_Click(object sender, RoutedEventArgs e)
        {
            currentPageType = typeof(StatusPage);

            Main.Content = new StatusPage();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageType == typeof(EmployeesPage))
            {
                Main.Content = new EmployeesPage();
            }
            else if (currentPageType == typeof(EmployeeRegistrationPage))
            {
                Main.Content = new EmployeeRegistrationPage();
            }
            else if (currentPageType == typeof(StatusPage))
            {
                Main.Content = new StatusPage();
            }
        }
    }
}
