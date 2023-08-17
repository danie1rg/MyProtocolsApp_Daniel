using MyProtocolsApp_Daniel.ViewModels;
using MyProtocolsApp_Daniel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProtocolsApp_Daniel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSignUp : ContentPage
    {
        UserViewModel viewModel;
        public UserSignUp()
        {
            InitializeComponent();

            BindingContext = viewModel = new UserViewModel();

            LoadUserRolesAsync();
        }

        //función que permite la carga de los roles de usuario

        private async void LoadUserRolesAsync() 
        {
            PkrUserRole.ItemsSource = await viewModel.GetUserRolesAsync();
        }

        private  async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //capturar el rol que se haya seleccionado en el picker

            UserRole SelectedUserPole = PkrUserRole.SelectedItem as UserRole;

            bool R = await viewModel.AddUserAsync(TxtEmail.Text.Trim(),
                TxtPassword.Text.Trim(), 
                TxtName.Text.Trim(),
                TxtBackUp.Text.Trim(),
                TxtPhone.Text.Trim(), 
                TxtAddres.Text.Trim(), 
                SelectedUserPole.UserRoleId);

            if (R) 
            {
                await DisplayAlert(":)", "User created succesfully", "OK");
                await Navigation.PopAsync();
            } 
            else
            {
                await DisplayAlert(":(", "Something went wrong", "OK");
            }


        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}