using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProtocolsApp_Daniel.ViewModels;

using Acr.UserDialogs;

namespace MyProtocolsApp_Daniel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
    {

        //se realiza el anclaje entre esta vista y el VM que le da la funcionalidad

        UserViewModel viewModel;

        public AppLoginPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new UserViewModel();
        }

        private void SwShowPassword_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwShowPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (TxtUserName.Text != null && !string.IsNullOrEmpty(TxtUserName.Text.Trim())
                && TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Loading...");

                    string username = TxtUserName.Text.Trim();
                    string password = TxtPassword.Text.Trim();

                    bool R = await viewModel.UserAccessValidation(username, password);

                    if (R)
                    {
                        await Navigation.PushAsync(new StartPage());
                        return;
                    }
                    else
                    {
                        await DisplayAlert("User Acess Denied", "Username or Password are incorrect", "OK");
                        return;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally 
                {
                    UserDialogs.Instance.HideLoading();
                    TxtPassword.Text = null;
                }
            }
            else 
            {
                await DisplayAlert("Data required", "Username and Password are required", "OK");
                return;
            }



        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserSignUp());
        }
    }
}