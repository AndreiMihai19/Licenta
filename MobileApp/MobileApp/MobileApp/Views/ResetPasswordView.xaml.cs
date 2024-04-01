using MobileApp.Interfaces;
using MobileApp.Models;
using MobileApp.Repositories;
using MobileApp.Services;
using Mysqlx.Session;
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
    public partial class ResetPasswordView : ContentPage
    {
        private IResetPassword resetPassword;

        public ResetPasswordView()
        {
            InitializeComponent();
        }

        private async void OnCheckCodeClicked(object sender, EventArgs e)
        {
            if (Convert.ToInt32(entryResetCode.Text) == ResetPasswordModel.ResetCode && DateTime.Now < ResetPasswordModel.ExpirationTime)
            {
                await DisplayAlert("Mesaj", "Codul introdus este corect!", "OK");

                labelResetPassword.IsVisible = true;
                labelResetPassword.IsEnabled = true; 
                entryNewPassword.IsVisible = true;
                entryNewPassword.IsEnabled = true;
                entryConfirmPassword.IsVisible = true;
                entryConfirmPassword.IsEnabled = true;
                buttonResetPassword.IsVisible = true;
                buttonResetPassword.IsEnabled = true;
            }
            else
            {
                if (DateTime.Now >= ResetPasswordModel.ExpirationTime)
                {
                    await DisplayAlert("Mesaj", "Codul introdus a expirat!", "OK");
                }
                else
                {
                    await DisplayAlert("Mesaj", "Codul introdus nu este valabil!", "OK");
                }
            }
        }

        private async void OnResetClicked(object sender, EventArgs e)
        {
            if (entryNewPassword.Text.CompareTo(entryConfirmPassword.Text) != 0)
            {
                await DisplayAlert("Mesaj", "Parolele introduse nu se potrivesc!", "OK");
            }
            else
            {
                resetPassword = new ResetPasswordRepository(ResetPasswordModel.UserEmail,entryNewPassword.Text, entryConfirmPassword.Text);

                ResetPasswordStatus resetPasswordStatus = await resetPassword.ResetPassword();

                switch (resetPasswordStatus)
                {
                    case ResetPasswordStatus.Success:
                        await DisplayAlert("Mesaj", "Parola s-a resetat cu succes!", "OK");

                        await Navigation.PopToRootAsync();
                        break;
                    case ResetPasswordStatus.Failure:
                        await DisplayAlert("Mesaj", "Nu s-a putut realiza schimbarea parolei!", "OK");
                        break;
                    case ResetPasswordStatus.InvalidCredentials:
                        await DisplayAlert("Mesaj", "Completati toate campurile!", "OK");
                        break;
                    case ResetPasswordStatus.DataBaseConnectionProblem:
                        await DisplayAlert("Mesaj", "Conexiunea la baza de date nu se poate realiza!", "OK");
                        break;
                    default:
                        break;
                }
            }
        }


        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}