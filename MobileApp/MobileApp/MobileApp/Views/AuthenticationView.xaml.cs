
using MobileApp.Interfaces;
using MobileApp.Models;
using MobileApp.Repositories;
using MobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticationView: ContentPage
    {

        private IAuthentication authenticationManager;

        public AuthenticationView()
        {
            InitializeComponent();
        }
        private async Task Authentication()
        {
            authenticationManager = new AuthenticationRepository(entryEmail.Text, entryPassword.Text);

            AuthenticationStatus authenticationStatus = await authenticationManager.Authenticate();

            switch (authenticationStatus)
            {
                case AuthenticationStatus.Success:
                    await DisplayAlert("Mesaj", "Autentificare reusita!", "OK");

                    DashboardModel.Email=entryEmail.Text;

                    string[] workDetails = (await authenticationManager.GetEmployeeWorkDetails()).Split('|');

                    DashboardModel.Id = Convert.ToInt32(workDetails[0]);
                    DashboardModel.DailyHours = Convert.ToInt32(workDetails[1]);

                    MenuView menuView = new MenuView();

                    await Navigation.PushAsync(menuView);
                    break;
                case AuthenticationStatus.InvalidCredentials:
                    await DisplayAlert("Mesaj", "Completati toate campurile!", "OK");
                    break;
                case AuthenticationStatus.Failure:
                    await DisplayAlert("Mesaj", "Autentificare esuata!", "OK");
                    break;
                case AuthenticationStatus.DataBaseConnectionProblem:
                    await DisplayAlert("Mesaj", "Conexiunea la baza de date nu se poate realiza!", "OK");
                    break;
                default:
                    break;
            }
        }

        private async void OnAuthenticationClicked(object sender, EventArgs e)
        {
            await Authentication();
        }

        private async void  OnForgotClick(object sender, EventArgs e)
        {
            ForgotPasswordView forgotPasswordView = new ForgotPasswordView();
            await Navigation.PushAsync(forgotPasswordView);
        }
    }
}