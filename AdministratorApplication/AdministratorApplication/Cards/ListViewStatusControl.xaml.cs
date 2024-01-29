using AdministratorApplication.Classes;
using AdministratorApplication.Forms;
using AdministratorApplication.Interfaces;
using AdministratorApplication.Pages;
using AdministratorApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace AdministratorApplication.Employee_Status
{
    /// <summary>
    /// Interaction logic for ListViewStatusControl.xaml
    /// </summary>
    public partial class ListViewStatusControl : UserControl
    {
        private IEmployeesListingStatus? status;
        private List<Status> statusList = new List<Status>();


        public ListViewStatusControl()
        {
            InitializeComponent();

            status = new EmployeesListingStatusRepository();

            status.AddStatus(statusList);

            ListViewStatus.ItemsSource = statusList;

            ListViewStatus.HorizontalContentAlignment = HorizontalAlignment.Center;
            ListViewStatus.VerticalContentAlignment = VerticalAlignment.Center;


        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double availableWidth = e.NewSize.Width;

            if (ListViewStatus.View is GridView gridView)
            {
                double columnWidth = availableWidth / gridView.Columns.Count;

                foreach (var column in gridView.Columns)
                {
                    column.Width = columnWidth;
                }
            }
        }

    }
}
