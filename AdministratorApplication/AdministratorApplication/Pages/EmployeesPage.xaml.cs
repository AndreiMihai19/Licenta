using AdministratorApplication.Classes;
using AdministratorApplication.Interfaces;
using AdministratorApplication.Repositories;
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
using System.ComponentModel;
using System.Collections.ObjectModel;
using AdministratorApplication.Forms;

namespace AdministratorApplication.Pages
{
    /// <summary>
    /// Interaction logic for EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private IEmployeeslListing? employeesListing;

        List<Employee> employees = new List<Employee>();

        ModifierForm? modifierForm;
        public EmployeesPage()
        {
            InitializeComponent();

            employeesListing= new EmployeesListingRepository();

            employeesListing.AddEmployees(employees);

            ListViewEmployees.ItemsSource = employees;

            ListViewEmployees.HorizontalContentAlignment = HorizontalAlignment.Center;
            ListViewEmployees.HorizontalAlignment = HorizontalAlignment.Center;

            GroupBy.ItemsSource = new string[] { "None", "Functie", "Ore" };

        }

        public void GroupEmployeesList()
        {
            ListViewEmployees.Items.GroupDescriptions.Clear();
            var property = GroupBy.SelectedItem as string;

            if (property == "None" ) 
            {
                return;
            }

            ListViewEmployees.Items.GroupDescriptions.Add(new PropertyGroupDescription(property));
        }

        private void GroupBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GroupEmployeesList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            employeesListing = new EmployeesListingRepository();

            var button = sender as Button;

            if (button != null)
            {
                var employee = button.DataContext as Employee;

                if (employee != null)
                {
                    employees.Remove(employee);
                    employeesListing.RemoveEmployee(employee);

                    ListViewEmployees.Items.Refresh();
                }
            }
        }

        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int? id = 0;
            string jobPosition = "";

            if (button != null)
            {
                var employee = button.DataContext as Employee;

                if (employee != null)
                {
                    id = employee.Id;
                    jobPosition = employee.Functie;
                }
            }

            modifierForm = new ModifierForm(id, jobPosition);
            modifierForm.UpdateEmployeeList += (sender, args) => { ListViewEmployees.Items.Refresh(); };

            modifierForm.ShowDialog();

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double availableWidth = e.NewSize.Width;

            if (ListViewEmployees.View is GridView gridView)
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
