using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyProtocolsApp_Daniel.Models;

namespace MyProtocolsApp_Daniel.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        //El VM funciona como puente entre el modelo y la vista

        public User MyUser { get; set; }

        public UserViewModel() 
        {
            MyUser = new User();
        }

        //funciones

        public async Task<bool> UserAccessValidation(string pEmail, string pPassword) 
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.Password = pPassword;

                bool R = await MyUser.ValidateUserLogin();

                return R;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                return false;

                throw;
            }
            finally 
            {
                IsBusy = false;
            }
        }




    }
}
