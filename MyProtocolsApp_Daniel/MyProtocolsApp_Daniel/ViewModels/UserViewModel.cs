using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyProtocolsApp_Daniel.Models;
using Xamarin.Essentials;

namespace MyProtocolsApp_Daniel.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        //El VM funciona como puente entre el modelo y la vista

        public User MyUser { get; set; }

        public UserRole MyUserRole { get; set; }

        public UserDTO MiUserDTO { get; set; }

        public UserViewModel() 
        {
            MyUser = new User();
            MyUserRole = new UserRole();
            MiUserDTO = new UserDTO();
        }

        //funciones


        //función que carga los datos a usuaro global


        public async Task<UserDTO> GetUserDataAsync(string pEmail) 
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UserDTO userDTO = new UserDTO();

                userDTO = await MiUserDTO.GetUserInfo(pEmail);

                if (userDTO == null) return null; 

                return userDTO;
                
            }catch 
            (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }
        }


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



        //cargar la lista de roles en el picker

        public async Task<List<UserRole>> GetUserRolesAsync() 
        {
            try 
            { 
                List<UserRole> roles = new List<UserRole>();
                roles =await MyUserRole.GetAllUserRoles();

                if (roles == null) 
                {
                    return null;
                }

                return roles;
            }
            catch (Exception e)
            {
                string msg = e.Message;

                return null;

                throw;
            }
        }


        //función de creación de nuevo usuario

        public async Task<bool> AddUserAsync(string pEmail, string pPassword, string pName, string pBackUpEmail,string pPhone, string pAddress, int pUserRolID)
        {

            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MyUser.Email = pEmail;
                MyUser.Password = pPassword;
                MyUser.Name = pName;    
                MyUser.BackUpEmail = pBackUpEmail;
                MyUser.PhoneNumber = pPhone;
                MyUser.Address = pAddress;
                MyUser.UserRoleId = pUserRolID;


                bool R = await MyUser.AddUserAsync();

                return R;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }


        public async Task<bool> UpdateUser(UserDTO pUser)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {
                MiUserDTO = pUser;


                bool R = await MiUserDTO.UpdateUserAsync();

                return R;

            }
            catch
            (Exception)
            {
                return false;
                throw;
            }
            finally { IsBusy = false; }
        }



    }
}
