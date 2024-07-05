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
using AdministratorApplication.Interfaces;
using AdministratorApplication.Repositories;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AdministratorApplication.Models;
using ZstdSharp.Unsafe;


namespace AdministratorApplication.Employee_Status
{
    /// <summary>
    /// Interaction logic for Charts.xaml
    /// </summary>
    public partial class Charts : UserControl
    {
        private readonly List<RegistryChartModel> chart = new List<RegistryChartModel>();
        private readonly ICharts chartInfo = new ChartsRepository();
        private string? selectedName;
        private string? selectedMonth;
        private string? selectedYear;

        public Charts()
        {
            InitializeComponent();

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

            string time = "00.00";

            List<string?> totalOre = chart
                                        .Where(registryChart => registryChart.NumePrenume == name && registryChart.LunaCalendaristica == month && registryChart.Anul.ToString() == year)
                                        .Select(item => item.TotalOre).ToList();

            if (totalOre != null)
            {
                foreach (string ore in totalOre)
                {
                    time = chartInfo.GetTotalHours(ore, time);
                }
            }

            string[] _time = time.Split(".");

            totalHourscard1.Number = _time[0] + ":" + _time[1];

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

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private double GetHourValue(RegistryChartModel registryChart, string seriesName)
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
            for (int year = currentYear; year >= 2000; year--)
            {
                years.Add(year.ToString());
            }

            return years;
        }
    }
}
