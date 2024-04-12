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
        private IDashboard employeeInfo = new DashboardRepository(DashboardModel.Email, DashboardModel.Id, DashboardModel.DailyHours);
        private string selectedMonth = "";
        private EmployeeModel employee;
        private int workingDays;

        public MenuView()
        {
            InitializeComponent();

        //    GetEmployeeInfo();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                lblDateTime.Text = DateTime.Now.ToString();

                return true;
            });

            SetCurrentMonth();

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
                workingDays = SetWorkingDays(GetIndexOfMonth(selectedMonth));
            }

            string[] _workedHours=lblHoursByMonth.Text.Split(':');
            int workedHours = Convert.ToInt32(_workedHours[0]);

            if (workedHours >= workingDays * DashboardModel.DailyHours)
            {
                frmHoursByMonth.BackgroundColor = Color.FromHex("#317773");
            }
            else
            {
                frmHoursByMonth.BackgroundColor = Color.FromHex("#ed3957");
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

        private int SetWorkingDays(int month)
        {
            int workingDays = 0;
            int daysInMonth = DateTime.DaysInMonth(DateTime.Today.Year, month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime date = new DateTime(DateTime.Today.Year, month, day);

                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
            }

            return workingDays;
        }

    }
}