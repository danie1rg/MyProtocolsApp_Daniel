using MyProtocolsApp_Daniel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProtocolsApp_Daniel.Models;

namespace MyProtocolsApp_Daniel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserManagementPage : ContentPage
    {

        UserViewModel viewModel;

        public UserManagementPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new UserViewModel();

            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            TxtId.Text = GlobalObjects.MyLocalUser.IDUsuario.ToString();
            TxtEmail.Text = GlobalObjects.MyLocalUser.Correo.ToString();
            TxtName.Text = GlobalObjects.MyLocalUser.Nombre.ToString();
            TxtPhone.Text = GlobalObjects.MyLocalUser.Telefono.ToString();
            TxtBackUp.Text = GlobalObjects.MyLocalUser.CorreoRespaldo.ToString();
            TxtAddres.Text = GlobalObjects.MyLocalUser.Direccion.ToString();

        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {

            if (ValidateFields()) 
            {  

                UserDTO BackUPLocalUser = new UserDTO();
                BackUPLocalUser = GlobalObjects.MyLocalUser;

                try 
                {
                    GlobalObjects.MyLocalUser.Nombre = TxtName.Text.Trim();
                    GlobalObjects.MyLocalUser.CorreoRespaldo = TxtBackUp.Text.Trim();
                    GlobalObjects.MyLocalUser.Telefono = TxtPhone.Text.Trim();
                    GlobalObjects.MyLocalUser.Direccion = TxtAddres.Text.Trim();

                    var answer = await DisplayAlert("???", "Are you sure to continue updating user info?", "Yes", "No");

                    if (answer) 
                    {
                        bool R = await viewModel.UpdateUser(GlobalObjects.MyLocalUser);

                        if (R)
                        {
                            await DisplayAlert(":)", "User Updated", "OK!");
                            await Navigation.PopAsync();
                        }
                        else 
                        {
                            await DisplayAlert(":(", "Something went wrong!", "OK!");
                            await Navigation.PopAsync();
                        }

                    }

                } 
                catch (Exception) 
                {
                    GlobalObjects.MyLocalUser = BackUPLocalUser;

                }

            }
        }

        private bool ValidateFields() 
        {
            bool R = false;

            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
                TxtBackUp.Text != null && !string.IsNullOrEmpty(TxtBackUp.Text.Trim()) &&
                TxtPhone.Text != null && !string.IsNullOrEmpty(TxtPhone.Text.Trim()))
            {
                R = true;

            }
            else 
            {
                if (TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim())) 
                {
                    DisplayAlert("Validation Failed", "The Name is requeired", "OK");
                    TxtName.Focus();
                    return false;
                }

                if (TxtBackUp.Text == null || string.IsNullOrEmpty(TxtBackUp.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The Back-up email is requeired", "OK");
                    TxtBackUp.Focus();
                    return false;
                }
                if (TxtPhone.Text == null || string.IsNullOrEmpty(TxtPhone.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The phone number is requeired", "OK");
                    TxtPhone.Focus();
                    return false;
                }
            }
            return R;

        }

        

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}