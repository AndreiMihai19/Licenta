using LiveCharts.Wpf;
using LiveCharts;
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
using AdministratorApplication.Classes;
using AdministratorApplication.Interfaces;
using AdministratorApplication.Repositories;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AdministratorApplication.Employee_Status
{
    /// <summary>
    /// Interaction logic for Charts.xaml
    /// </summary>
    public partial class Charts : UserControl
    {
        private List<RegistryChart> chart = new List<RegistryChart>();
        private ICharts chartInfo = new ChartsRepository();
        private string? selectedName;
        private string? selectedMonth;
        private string? selectedYear;

        public Charts()
        {
            InitializeComponent();

          //  EmployeeNames = new ObservableCollection<string>(chartInfo.GetNamesOfEmployees());

            chartInfo.AddRegistryValues(chart);

            CBNames.ItemsSource= chartInfo.GetNamesOfEmployees();

            CBMonths.ItemsSource = GetMonths();

            CBYears.ItemsSource = GetYears();

            selectedName = CBNames.SelectedItem.ToString();
            selectedMonth = CBMonths.SelectedItem.ToString();
            selectedYear = CBYears.SelectedItem.ToString();


        }

        public void RowChart(string name, string month, string year)
        {

            DataContext = null;

            double val = chart
                            .Where(registryChart => registryChart.NumePrenume == name && registryChart.LunaCalendaristica == month && registryChart.Anul.ToString()  == year)
                            .Select(registryChart => registryChart.TotalOre ?? 0)
                            .Sum();

            string[] time = val.ToString("F2").Split(".");

            if (time[1].Length == 1)
            {
                time[1] = time[1] + "0";
            }

            int minutes = Convert.ToInt32(time[1]);
            int hour = Convert.ToInt32(time[0]) + minutes / 60;
            minutes %= 60;

            string _time = $"{hour}:{minutes:D2}";

            totalHourscard1.Number = _time.ToString();

            List<string> seriesNames = new List<string> { "Program 1", "Pauza", "Program 2" };

            List<string?> distinctDates = chart
                         .Where(registryChart => registryChart.NumePrenume == name && registryChart.LunaCalendaristica == month && registryChart.Anul.ToString() == year)
                         .Select(registryChart => registryChart.Data)
                         .Distinct()
                         .ToList();


            SeriesCollection = new SeriesCollection();

            foreach (string seriesName in seriesNames)
            {
                List<double> times = chart
                                        .Where(registryChart => registryChart.NumePrenume == name && registryChart.LunaCalendaristica == month && registryChart.Anul.ToString() == year)
                                        .Select(registryChart => GetHourValue(registryChart, seriesName))
                                        .ToList();

                SeriesCollection.Add(new StackedColumnSeries
                {
                    Title = seriesName,
                    Values = new ChartValues<double>(times),
                    StackMode = StackMode.Values,
                    DataLabels = true,
                });
            }

            Labels = distinctDates.ToArray();
            Formatter = value => value + " h";

            DataContext = this;

        }

        private double GetHourValue(RegistryChart registryChart, string seriesName)
        {
            switch (seriesName)
            {
                case "Program 1":
                    return registryChart.OraProgram1 ?? 0;
                case "Pauza":
                    return registryChart.OraPauza ?? 0;
                case "Program 2":
                    return registryChart.OraProgram2 ?? 0;
                default:
                    return 0;
            }
        }


        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }


        private void CBNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBNames.SelectedItem != null )
            {
                selectedName = CBNames.SelectedItem.ToString();
                RowChart(selectedName, selectedMonth, selectedYear);
            }
        }

        private void CBMonths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBNames.SelectedItem != null)
            {
                selectedMonth = CBMonths.SelectedItem.ToString();
                RowChart(selectedName, selectedMonth, selectedYear);
            }
        }

        private void CBYears_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBNames.SelectedItem != null)
            {
                selectedYear = CBYears.SelectedItem.ToString();
                RowChart(selectedName, selectedMonth, selectedYear);
            }
        }

        private string[] GetMonths()
        {
            CultureInfo limbaRomana = new CultureInfo("ro-RO");

            string[] months = limbaRomana.DateTimeFormat.MonthNames;
            Array.Resize(ref months, months.Length - 1);

            return months;
        }

        private ObservableCollection<string> GetYears()
        {
            ObservableCollection<string> years = new ObservableCollection<string>();

            int currentYear = DateTime.Now.Year;
            for (int year = 2000; year <= currentYear; year++)
            {
                years.Add(year.ToString());
            }

            return years;
        }
    }
}
