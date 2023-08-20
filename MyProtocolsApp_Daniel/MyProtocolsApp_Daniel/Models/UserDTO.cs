using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyProtocolsApp_Daniel.Models
{
    public class UserDTO
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }

        public int IDUsuario { get; set; }
        public string Correo { get; set; } = null!;
        public string Contrasennia { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string CorreoRespaldo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Direccion { get; set; }
        public bool? Activo { get; set; }
        public bool? EstaBloqueado { get; set; }
        public int IDRol { get; set; }

        public string? DescripcionRol { get; set; } = null!;

        public UserDTO() { }

        public async Task<UserDTO> GetUserInfo(string Pemail) 
        {
            try
            {

                string RouteSufix = string.Format("Users/GetUserInfoByEmail?Pemail={0}", Pemail);

                string URL = Services.APIConection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos la llave de seguridad, en este caso API KEY

                Request.AddHeader(Services.APIConection.ApiKeyName, Services.APIConection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //ejecutar la llamada al API

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);

                    var item = list[0];
                    return item;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }


        public async Task<bool> UpdateUserAsync()
        {
            try
            {


                string RouteSufix = string.Format("Users/{0}", this.IDUsuario);

                string URL = Services.APIConection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Put);

                //agregamos la llave de seguridad, en este caso API KEY

                Request.AddHeader(Services.APIConection.ApiKeyName, Services.APIConection.ApiKeyValue);


                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);


                //en el caso de una operación POSS debemos serializar el objecto para pasarlo como json al API

                string SerializedModelObject = JsonConvert.SerializeObject(this);

                //agregamos el objecto serializado en el cuerpo del request


                Request.AddBody(SerializedModelObject, GlobalObjects.MimeType);


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

        public async Task<bool> UpdateUserAsyncByPassword()
        {
            try
            {


                string RouteSufix = string.Format("Users/{0}", this.IDUsuario);

                string URL = Services.APIConection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Patch);

                //agregamos la llave de seguridad, en este caso API KEY

                Request.AddHeader(Services.APIConection.ApiKeyName, Services.APIConection.ApiKeyValue);


                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);


                //en el caso de una operación POSS debemos serializar el objecto para pasarlo como json al API

                string SerializedModelObject = JsonConvert.SerializeObject(this);

                //agregamos el objecto serializado en el cuerpo del request


                Request.AddBody(SerializedModelObject, GlobalObjects.MimeType);


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
