using MobileApp.Models;
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
        public ResetPasswordView()
        {
            InitializeComponent();
        }

        private async void OnCheckCodeClicked(object sender, EventArgs e)
        {
            if (Convert.ToInt32(entryResetCode.Text) == ResetCodeModel.ResetCode && DateTime.Now < ResetCodeModel.ExpirationTime)
            {
                await DisplayAlert("Mesaj", "Codul introdus este corect!", "OK");
            }
            else
            {
                 await DisplayAlert("Mesaj", "Codul introdus nu este valabil!", "OK");
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}