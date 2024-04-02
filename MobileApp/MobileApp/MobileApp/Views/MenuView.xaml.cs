using MobileApp.Interfaces;
using MobileApp.Models;
using MobileApp.Repositories;
using Mysqlx.Notice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        private IDashboard employeeInfo;
        EmployeeModel employee;

        public MenuView()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                lblDateTime.Text = DateTime.Now.ToString();

                return true;
            }); 

            SetEmployeeInfo();

        }

        private async Task GetEmployeeInfo()
        {
            employeeInfo = new DashboardRepository(DashboardModel.Email);

            employee = await employeeInfo.GetEmployeeInfo();
        }

        private async void SetEmployeeInfo()
        {
           await GetEmployeeInfo();

            lblLastName.Text = employee.Nume;
            lblFirstName.Text = employee.Prenume;
            lblEmail.Text=employee.Email;
            lblJob.Text = employee.Functie;
            lblDailyHours.Text = employee.OreZi.ToString();
            lblClockIn.Text = employee.OraIn.ToString();
            lblStartBreak.Text = employee.OraOut.ToString();
            lblEndBreak.Text = employee.PauzaIn.ToString();
            lblClockOut.Text = employee.OraOut.ToString(); 
            lblTotalHours.Text = employee.TotalOreLucrate.ToString();

        }

        private void FrameTapped(object sender, EventArgs e)
        {
            monthPicker.Focus();
        }

        private async void OnLogOutClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void MonthPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMonth = monthPicker.SelectedItem as string;
            lblMonth.Text = selectedMonth;  
        }
    }
}