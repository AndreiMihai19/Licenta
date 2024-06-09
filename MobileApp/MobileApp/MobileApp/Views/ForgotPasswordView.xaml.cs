using MobileApp.Interfaces;
using MobileApp.Models;
using MobileApp.Repositories;
using MobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPasswordView : ContentPage
	{
        private IResetPassword resetPassword;


		public ForgotPasswordView()
		{
			InitializeComponent();
		}

        private async void OnSendClicked(object sender, EventArgs e)
        {
            await SendEmail();
        }

        private async Task SendEmail()
        {
            resetPassword = new ResetPasswordRepository(entryEmail.Text);

            SendMailStatus sendEmailStatus = await resetPassword.CheckEmail();

            switch (sendEmailStatus)
            {
                case SendMailStatus.Success:
                    await DisplayAlert("Mesaj", "O sa primiti un cod pentru resetarea parolei. Verificati inbox-ul sau spam-ul!", "OK");

                    ResetPasswordModel.ResetCode = resetPassword.GenerateResetCode();
                    ResetPasswordModel.ExpirationTime = DateTime.Now.AddMinutes(5);
                    ResetPasswordModel.UserEmail = entryEmail.Text;

                    ISendMail sendMail = new SendMail();
                    await sendMail.SendResetCodeMethod(ResetPasswordModel.ResetCode, entryEmail.Text);

                    ResetPasswordView resetPasswordView = new ResetPasswordView();
                    await Navigation.PushAsync(resetPasswordView);
                    break;
                case SendMailStatus.InvalidCredentials:
                    await DisplayAlert("Mesaj", "Completati toate campurile!", "OK");
                    break;
                case SendMailStatus.Failure:
                    await DisplayAlert("Mesaj", "Nu sunteti inregistrat!", "OK");
                    break;
                case SendMailStatus.DataBaseConnectionProblem:
                    await DisplayAlert("Mesaj", "Conexiunea la baza de date nu se poate realiza!", "OK");
                    break;
                default:
                    break;
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}