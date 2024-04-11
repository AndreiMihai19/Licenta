using MobileApp.Interfaces;
using MobileApp.Models;
using MobileApp.Repositories;
using Mysqlx.Notice;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private IDashboard employeeInfo = new DashboardRepository(DashboardModel.Email, DashboardModel.Id);
        private string selectedMonth = "";
        private EmployeeModel employee;

        public MenuView()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                lblDateTime.Text = DateTime.Now.ToString();

                return true;
            });

            SetCurrentMonth();

           // selectedMonth = monthPicker.SelectedItem.ToString();

            SetEmployeeInfo();

        }

        private async Task GetEmployeeInfo()
        {

            employee = await employeeInfo.GetEmployeeInfo();

         //   DashboardModel.Email = null;
          //  DashboardModel.Id = 0;
        }

        private async void SetEmployeeInfo()
        {
            await GetEmployeeInfo();

           // lblHoursByMonth.Text = (await employeeInfo.GetHoursByMonth(DashboardModel.Id,GetIndexOfMonth(monthPicker.SelectedItem.ToString()))).ToString();
          //  lblHoursByMonth.Text = (await employeeInfo.GetHoursByMonth(DashboardModel.Id,GetIndexOfMonth("Ianuarie"))).ToString();

            lblLastName.Text = employee.Nume;
            lblFirstName.Text = employee.Prenume;
            lblEmail.Text=employee.Email;
            lblJob.Text = employee.Functie;
            lblDailyHours.Text = employee.OreZi.ToString();
            lblClockIn.Text = employee.OraIn.ToString();
            lblStartBreak.Text = employee.PauzaIn.ToString();
            lblEndBreak.Text = employee.PauzaOut.ToString();
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

        private async void MonthPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (monthPicker.SelectedIndex != -1 ) 
            {
                selectedMonth = monthPicker.SelectedItem as string;
                lblMonth.Text = selectedMonth;
                lblHoursByMonth.Text = (await employeeInfo.GetHoursByMonth(DashboardModel.Id, GetIndexOfMonth(selectedMonth))).ToString();
            }
            
        }

        private int GetIndexOfMonth(string month)
        {
            CultureInfo culture = new CultureInfo("ro-RO");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            return DateTime.ParseExact(month, "MMMM", culture).Month;
        }
        private void SetCurrentMonth()
        {
            int currentMonthIndex = DateTime.Now.Month - 1;
            monthPicker.SelectedIndex = currentMonthIndex;
        }

    }
}