﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyProtocolsApp_Daniel.Models
{
    public class UserRole
    {
        public RestRequest Request { get; set; }

        public int UserRoleId { get; set; }
        public string Description { get; set; } = null!;

        //funciones
        public async Task<List<UserRole>> GetAllUserRoles()
        {
            try
            {
                
                string RouteSufix = string.Format("UserRoles");

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
                    var list = JsonConvert.DeserializeObject<List<UserRole>>(response.Content);
                    return list;
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

    }
}
