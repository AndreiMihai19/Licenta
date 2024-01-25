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
using ZstdSharp.Unsafe;

namespace AdministratorApplication
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
      
        public MenuWindow()
        {
            InitializeComponent();
        }


        private void BtnEmployees_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new EmployeesPage();
        }

        private void BtnEmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new EmployeeRegistrationPage();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void BtnStatus_Click(object sender, RoutedEventArgs e)
        {

            await Task.Run(() =>
            {
                Dispatcher.Invoke(() => Main.Content = new StatusPage());
            });

            Dispatcher.Invoke(HidePageProgressBar);



        }
        private void ShowPageProgressBar()
        {
            PageProgressBar.Visibility = Visibility.Visible;
        }

        private void HidePageProgressBar()
        {
            PageProgressBar.Visibility = Visibility.Collapsed;
        }



    }
}
