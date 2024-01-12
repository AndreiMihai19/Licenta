using AdministratorApplication.Classes;
using AdministratorApplication.Interfaces;
using MySql.Data.MySqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdministratorApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAuthentication authenticationManager;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           //   Authentication();
            
            MessageBox.Show("Autentificare reusita!");

            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();

            this.IsEnabled = false;
            this.Close();
            
        }

        private void Authentication()
        {
            authenticationManager = new AuthenticationRepository(txtboxEmail.Text, txtboxPassword.Password);

            switch (authenticationManager.Authenticate()) 
            {
                case AuthenticationStatus.Success:
                    MessageBox.Show("Autentificare reusita!");

                    MenuWindow menuWindow = new MenuWindow();
                    menuWindow.Show();

                    this.IsEnabled = false;
                    this.Close();

                    break;
                case AuthenticationStatus.InvalidCredentials: MessageBox.Show("Completati toate campurile!");
                    break;
                case AuthenticationStatus.Failure: MessageBox.Show("Autentificare esuata!");
                    break;
                case AuthenticationStatus.DataBaseConnectionProblem: MessageBox.Show("Conexiunea la baza de date nu se poate realiza!");
                    break;
                default:
                    break;
            }
}
    }

}
    
