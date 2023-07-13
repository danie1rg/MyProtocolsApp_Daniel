using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyProtocolsApp_Daniel.Models
{
    public class User
    {
        public RestRequest Request { get; set; }

        // en este ejemplo usaré los mismos atributos que en el modelo del api posteriormente en otra clase usaré el DTO del usuario para simplificar el json que
        //se envía y recibe desde el API.

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }
        public int UserRoleId { get; set; }

        public virtual UserRole? UserRole { get; set; } = null!;

        public User() { }

        public async Task<bool> ValidateUserLogin() 
        {
            try 
            {
                //usaremos el prefijo de la ruta de URL del api que se indica en
                //services/APIConnections para agregar el sufijo y lograr la ruta
                //completa de consumo del end point que se quiere usar

                string RouteSufix = string.Format("Users/ValidateLogin?username={0}&password={1}", this.Email, this.Password);

                string URL = Services.APIConection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos la llave de seguridad, en este caso API KEY

                Request.AddHeader(Services.APIConection.ApiKeyName, Services.APIConection.ApiKeyValue);

                //ejecutar la llamada al API

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else 
                {
                    return false;
                }

            } 
            catch (Exception ex) 
            {
                string message = ex.Message;
                throw;
            }
        }

    }
}
