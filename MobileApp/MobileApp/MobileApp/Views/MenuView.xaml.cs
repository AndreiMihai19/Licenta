using Google.Protobuf;
using MobileApp.Interfaces;
using MobileApp.Models;
using MobileApp.Repositories;
using Mysqlx.Notice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string selectedYear = "";
        private string selectedWeek = "";
        private EmployeeModel employee;
        private int workingDaysOfMonth;
        private int workingDaysOfWeek;

        public MenuView()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                lblDate.Text = DateTime.Now.Date.ToShortDateString();
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");

                return true;
            });

            SetCurrentYear();

            SetCurrentMonth();

            SetCurrentWeek();

            GetYears();

            SetEmployeeInfo();

        }

        private void SetCurrentYear()
        {
            yearPicker.SelectedIndex = 0;
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
            lblEmail.Text = employee.Email;
            lblJob.Text = employee.Functie;
            lblDailyHours.Text = employee.OreZi.ToString();
            lblClockIn.Text = employee.OraIn.ToString();
            lblStartBreak.Text = employee.PauzaIn.ToString();
            lblEndBreak.Text = employee.PauzaOut.ToString();
            lblClockOut.Text = employee.OraOut.ToString();
            lblTotalHours.Text = employee.TotalOreLucrate.ToString();

        }

        private void YearFrameTapped(object sender, EventArgs e)
        {
            yearPicker.Focus();
        }

        private void MonthFrameTapped(object sender, EventArgs e)
        {
            monthPicker.Focus();
        }

        private void WeekFrameTapped(object sender, EventArgs e)
        {
            weeksPicker.Focus();
        }

        private async void YearPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string week, interval;

            if (yearPicker.SelectedIndex != -1)
            {
                selectedMonth = monthPicker.SelectedItem as string;
                selectedYear = yearPicker.SelectedItem as string;
                lblYear.Text = selectedYear;
                string workedHoursByMonth = (await employeeInfo.GetHoursByMonth(DashboardModel.Id, GetIndexOfMonth(selectedMonth), Convert.ToInt32(selectedYear))).ToString();
                lblHoursByMonth.Text = workedHoursByMonth;
                lblHoursByYear.Text = (await employeeInfo.GetHoursByYear(DashboardModel.Id, Convert.ToInt32(selectedYear))).ToString();
                workingDaysOfMonth = SetWorkingDaysOfMonth(Convert.ToInt32(selectedYear), GetIndexOfMonth(selectedMonth));
                AddWeeksToPicker(Convert.ToInt32(selectedYear), GetIndexOfMonth(selectedMonth));
                
                if (GetIndexOfMonth(selectedMonth) == DateTime.Now.Month && Convert.ToInt32(selectedYear) == DateTime.Now.Year)
                {
                    SetCurrentMonth();
                    SetCurrentWeek();
                    interval = lblWeek.Text;
                }
                else
                {
                    week = GetFirstWeekOfMonth(Convert.ToInt32(selectedYear), GetIndexOfMonth(selectedMonth));
                    interval = SetIntervalOfWeek(Convert.ToInt32(selectedYear), GetIndexOfMonth(selectedMonth), week);
                    lblWeek.Text = week;
                }

                lblHoursByWeek.Text = (await employeeInfo.GetHoursByWeek(DashboardModel.Id, GetIndexOfMonth(selectedMonth), Convert.ToInt32(selectedYear), interval)).ToString();
                workingDaysOfWeek = SetWorkingDaysOfWeek(Convert.ToInt32(selectedYear), GetIndexOfMonth(selectedMonth), interval);

                lblOvertime.Text = employeeInfo.SetOvertime(workedHoursByMonth, DashboardModel.DailyHours, workingDaysOfMonth);


                ChangeFieldColor(lblHoursByWeek, frmHoursByWeek, workingDaysOfWeek);
                ChangeFieldColor(lblHoursByMonth, frmHoursByMonth,workingDaysOfMonth);
            }

        }

        private async void MonthPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string week, interval;
            if (monthPicker.SelectedIndex != -1)
            {
                selectedMonth = monthPicker.SelectedItem as string;
                selectedYear = yearPicker.SelectedItem as string;
                lblMonth.Text = selectedMonth;
                string workedHoursByMonth = (await employeeInfo.GetHoursByMonth(DashboardModel.Id, GetIndexOfMonth(selectedMonth), Convert.ToInt32(selectedYear))).ToString();
                lblHoursByMonth.Text = workedHoursByMonth;
                workingDaysOfMonth = SetWorkingDaysOfMonth(Convert.ToInt32(selectedYear),GetIndexOfMonth(selectedMonth));
                AddWeeksToPicker(Convert.ToInt32(selectedYear), GetIndexOfMonth(selectedMonth));
                

                if (GetIndexOfMonth(selectedMonth) == DateTime.Now.Month && Convert.ToInt32(selectedYear) == DateTime.Now.Year)
                {
                    SetCurrentMonth();
                    SetCurrentWeek();
                    interval = lblWeek.Text;
                }
                else
                {
                    week = GetFirstWeekOfMonth(Convert.ToInt32(selectedYear), GetIndexOfMonth(selectedMonth));
                    interval = SetIntervalOfWeek(Convert.ToInt32(selectedYear), GetIndexOfMonth(selectedMonth), week);
                    lblWeek.Text = week;
                }

                lblHoursByWeek.Text = (await employeeInfo.GetHoursByWeek(DashboardModel.Id, GetIndexOfMonth(selectedMonth), Convert.ToInt32(selectedYear), interval)).ToString();
                

                workingDaysOfWeek = SetWorkingDaysOfWeek(Convert.ToInt32(selectedYear), GetIndexOfMonth(selectedMonth), interval);

                lblOvertime.Text = employeeInfo.SetOvertime(workedHoursByMonth, DashboardModel.DailyHours, workingDaysOfMonth);

                ChangeFieldColor(lblHoursByWeek, frmHoursByWeek, workingDaysOfWeek);
                ChangeFieldColor(lblHoursByMonth, frmHoursByMonth, workingDaysOfMonth);

            }
        }

        private async void WeekPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weeksPicker.SelectedIndex != -1)
            {
                selectedMonth = monthPicker.SelectedItem as string;
                selectedYear = yearPicker.SelectedItem as string;
                selectedWeek = weeksPicker.SelectedItem as string;

                string week = ConvertWeekFormat(selectedWeek);
                string interval = SetIntervalOfWeek(Convert.ToInt32(selectedYear), GetIndexOfMonth(selectedMonth),week);

                lblWeek.Text = week;
                lblHoursByWeek.Text = (await employeeInfo.GetHoursByWeek(DashboardModel.Id, GetIndexOfMonth(selectedMonth), Convert.ToInt32(selectedYear), interval)).ToString();

                workingDaysOfWeek = SetWorkingDaysOfWeek(Convert.ToInt32(selectedYear),GetIndexOfMonth(selectedMonth),interval);

                ChangeFieldColor(lblHoursByWeek, frmHoursByWeek,workingDaysOfWeek);
            }
        }

        private int GetIndexOfMonth(string month)
        {
            CultureInfo culture = new CultureInfo("ro-RO");

            return DateTime.ParseExact(month, "MMMM", culture).Month;
        }

        private void SetCurrentMonth()
        {
            int currentMonthIndex = DateTime.Now.Month - 1;
            monthPicker.SelectedIndex = currentMonthIndex;
        }

        private void SetCurrentWeek()
        {
            DateTime currentDate = DateTime.Now;

            DateTime firstDayOfCurrentWeek= currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday);

            DateTime lastDayOfCurrentWeek = firstDayOfCurrentWeek.AddDays(6);
 
            string week = $"{firstDayOfCurrentWeek.Day}-{lastDayOfCurrentWeek.Day}";

            lblWeek.Text = week;
        }

        private int SetWorkingDaysOfMonth(int year,int month)
        {
            int workingDays = 0;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime date = new DateTime(year, month, day);

                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
            }

            return workingDays;
        }

        private int SetWorkingDaysOfWeek(int year, int month,string week)
        {
            int workingDaysOfWeek = 0;
            string[] _week = week.Split('-');

            int firstDay = Convert.ToInt32(_week[0]);
            int lastDay = Convert.ToInt32(_week[1]);

            for (int day = firstDay; day <= lastDay; day++)
            {
                DateTime date = new DateTime(year, month, day);

                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDaysOfWeek++;
                }
            }

            return workingDaysOfWeek;
        }

        private void GetYears()
        {
            int currentYear = DateTime.Now.Year;
            int firstYear = 2000;

            for (int year = currentYear; year >= firstYear; year--)
            {
                yearPicker.Items.Add(year.ToString());
            }

            yearPicker.SelectedIndex = 0;
            lblYear.Text = currentYear.ToString();
        }

        private List<string> GetWeeksInMonth(int year, int month)
        {
            List<string> weeks = new List<string>();

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DateTime firstDayOfWeek = firstDayOfMonth.AddDays(-(int)firstDayOfMonth.DayOfWeek);
            if (firstDayOfWeek.DayOfWeek != DayOfWeek.Monday)
            {
                firstDayOfWeek = firstDayOfWeek.AddDays(1);
            }

            while (firstDayOfWeek.Month == month || firstDayOfWeek.Month == month - 1 || (firstDayOfWeek.Month == 12 && month == 1))
            {
                DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);

                weeks.Add($"{firstDayOfWeek.ToString("dd/MM/yyyy")}-{lastDayOfWeek.ToString("dd/MM/yyyy")}");

                firstDayOfWeek = lastDayOfWeek.AddDays(1);
            }

            return weeks;
        }

        private string ConvertWeekFormat(string week)
        {
            string[] _week = week.Split('-');

            DateTime firsDayOfWeek = DateTime.ParseExact(_week[0], "dd/MM/yyyy", new System.Globalization.CultureInfo("ro-RO"));
            DateTime lastDayOfWeek = DateTime.ParseExact(_week[1], "dd/MM/yyyy", new System.Globalization.CultureInfo("ro-RO"));

            return firsDayOfWeek.Day.ToString() + "-" + lastDayOfWeek.Day.ToString();
        }

        private string GetFirstWeekOfMonth(int year, int month)
        {

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DateTime firstDayOfWeek = firstDayOfMonth.AddDays(-(int)firstDayOfMonth.DayOfWeek);
            if (firstDayOfWeek.DayOfWeek != DayOfWeek.Monday)
            {
                firstDayOfWeek = firstDayOfWeek.AddDays(1);
            }

            DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);

            int _firstDayOfWeek = firstDayOfWeek.Day;
            int _lastDayOfWeek = lastDayOfWeek.Day;

            return _firstDayOfWeek.ToString() + "-" + _lastDayOfWeek.ToString();

        }

        private string SetIntervalOfWeek(int year, int month, string week)
        {
            string firstWeek = GetFirstWeekOfMonth(year, month);
            string[] _week = week.Split('-');
            int firstDayOfInterval = Convert.ToInt32(_week[0]); 
            int lastDayOfInterval = Convert.ToInt32(_week[1]);


            if (firstDayOfInterval > lastDayOfInterval)
            {
                if (week.CompareTo(firstWeek) == 0)
                {
                    firstDayOfInterval = 1;
                }
                else
                {
                    lastDayOfInterval = DateTime.DaysInMonth(year, month); ;
                }
            }

            return firstDayOfInterval + "-" + lastDayOfInterval;
        }

        private async void AddWeeksToPicker(int year, int month)
        {
            weeksPicker.Items.Clear();

            List<string> weeksInMonth = GetWeeksInMonth(year, month);

            // Add weeks to picker
            foreach (string week in weeksInMonth)
            {
               weeksPicker.Items.Add(week);
            }
        }

        private void ChangeFieldColor(Label label, Xamarin.Forms.Frame frame, int workingDays)
        {
            string[] _workedHours = label.Text.Split(':');
            int workedHours = Convert.ToInt32(_workedHours[0]);

            if (workedHours >= workingDays * DashboardModel.DailyHours && workedHours != 0)
            {
                frame.BackgroundColor = Color.FromHex("#317773");
            }
            else
            {
                frame.BackgroundColor = Color.FromHex("#ed3957");
            }
        }

        private async void OnLogOutClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}