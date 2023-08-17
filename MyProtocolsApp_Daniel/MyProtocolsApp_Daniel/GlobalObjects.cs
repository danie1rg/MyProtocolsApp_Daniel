using MyProtocolsApp_Daniel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProtocolsApp_Daniel
{
    public static class GlobalObjects
    {
        //definimos las propiedades de codifición del los json que usaremos en los modelos 

        public static string MimeType = "application/json";

        public static string ContentType = "Content-Type";

        //crear el objecto local/global de usuario
        public static UserDTO MyLocalUser = new UserDTO();



    }
}
