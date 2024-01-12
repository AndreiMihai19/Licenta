﻿using AdministratorApplication.Pages;
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
using System.Windows.Shapes;

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


        private void btnClickEmployees(object sender, RoutedEventArgs e)
        {
            Main.Content = new EmployeesPage();
        }

        private void btnClickEmployeeAdd(object sender, RoutedEventArgs e)
        {
            Main.Content = new EmployeeRegistrationPage();
        }
    }
}