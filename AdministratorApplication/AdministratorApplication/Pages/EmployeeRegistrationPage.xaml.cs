using AdministratorApplication.Classes;
using AdministratorApplication.Interfaces;
using AdministratorApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace AdministratorApplication.Pages
{
    /// <summary>
    /// Interaction logic for EmployeeRegistrationPage.xaml
    /// </summary>
    public partial class EmployeeRegistrationPage : Page
    {
        private IRegistration registration;
        public EmployeeRegistrationPage()
        {
            InitializeComponent();
        }

        private void BtnInregistrare_Click(object sender, RoutedEventArgs e)
        {
            registration = new RegistrationRepository();

            Random random = new Random();

            string stridAngajat = new string(Enumerable.Repeat("0123456789", 4).Select(s => s[random.Next(s.Length)]).ToArray());
            int idAngajat = int.Parse(stridAngajat);


            DateTime? selectedDate = dpDataNasterii.SelectedDate;
            string dataNastere = selectedDate.Value.ToString("yyyy-MM-dd");

            string jobPosition = (cmbFunctie.SelectedItem as ComboBoxItem)?.Content.ToString();

            int[] radioBtn = { 4, 6, 8 };
            int radioBtnSelected = 0;

            if (radioOre1.IsChecked == true)
            {
                radioBtnSelected = radioBtn[0];
            }
            if (radioOre2.IsChecked == true)
            {
                radioBtnSelected = radioBtn[1];
            }
            if (radioOre3.IsChecked == true)
            {
                radioBtnSelected = radioBtn[2];
             }

            

            Employee employee = new Employee()
            {
                Id = idAngajat,
                Email = txtEmail.Text,
                Password = txtParola.Password,
                FirstName = txtPrenume.Text,
                LastName = txtNume.Text,
                DateOfBirth= dataNastere,
                CNP = txtCNP.Text,
                PhoneNumber = txtTelefon.Text,
                JobPosition = jobPosition,
                Hours=radioBtnSelected
            };
            

            switch (registration.Register(employee))
            {
                case RegistrationStatus.Success: MessageBox.Show("Inregistrare reusita!");
                    break;
                case RegistrationStatus.InvalidCredentials: MessageBox.Show("Completati toate campurile!");
                    break;
                case RegistrationStatus.Failure: MessageBox.Show("Autentificare esuata!");
                    break;
                case RegistrationStatus.DataBaseConnectionProblem: MessageBox.Show("Conexiunea la baza de date nu se poate realiza!");
                    break;
                default:
                    break;
            }
        }
    }
}
