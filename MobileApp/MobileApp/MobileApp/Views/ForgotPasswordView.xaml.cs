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

        private async Task SendEmail()
        {
            resetPassword = new ResetPasswordRepository(entryEmail.Text);

            SendEmailStatus sendEmailStatus = await resetPassword.SendPassword();

            switch (sendEmailStatus)
            {
                case SendEmailStatus.Success:
                    await DisplayAlert("Mesaj", "O sa primiti un cod pentru resetarea parolei. Verificati inbox-ul sau spam-ul!", "OK");

                    ResetCodeModel.ResetCode = resetPassword.GenerateResetCode();
                    ResetCodeModel.ExpirationTime = DateTime.Now.AddMinutes(5);

                    ISendMail sendMail = new SendMail();
                    await sendMail.SendResetCodeMethod(ResetCodeModel.ResetCode, entryEmail.Text);

                    ResetPasswordView resetPasswordView = new ResetPasswordView();
                    await Navigation.PushAsync(resetPasswordView);
                    break;
                case SendEmailStatus.InvalidCredentials:
                    await DisplayAlert("Mesaj", "Completati toate campurile!", "OK");
                    break;
                case SendEmailStatus.Failure:
                    await DisplayAlert("Mesaj", "Nu sunteti inregistrat!", "OK");
                    break;
                case SendEmailStatus.DataBaseConnectionProblem:
                    await DisplayAlert("Mesaj", "Conexiunea la baza de date nu se poate realiza!", "OK");
                    break;
                default:
                    break;
            }

        }

        private async void OnSendClicked(object sender, EventArgs e)
        {
            await SendEmail();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}