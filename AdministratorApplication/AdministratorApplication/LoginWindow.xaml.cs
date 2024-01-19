using AdministratorApplication.Classes;
using AdministratorApplication.Interfaces;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
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
    public partial class LoginWindow : Window
    {
        private IAuthentication authenticationManager;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Authentication();
            
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

        private async Task SendEmail(string toEmail)
        {
            try
            {
                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential
                    {
                        UserName = "andrei.mihai190401@gmail.com",
                        Password = "bppq mjpz vziv aprr"
                    }
                };

                MailMessage message = new MailMessage("andrei.mihai190401@gmail.com", toEmail);
                message.Subject = "Inregistrare angajat";
                message.Body = "Ati fost adaugat in sistem! Bine ati venit in compania noastra!";
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.None;

                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }

}
    
