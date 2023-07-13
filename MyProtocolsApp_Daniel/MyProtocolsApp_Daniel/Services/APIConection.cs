using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace MyProtocolsApp_Daniel.Services
{
    public class APIConection
    {
        // acá definimos la dirección url (ya sea una ip o un nombre de domino) a la que la pp debe apuntar.
        //Por comidad la ruta de URl competa para consumir los recursos del API se hará
        // en formato "prefijo"+"sufijo"
        //donde el prefijo sera la part de la URL que nunca cambiará y el sufijo será la parte variable

        public static string ProductionPrefixURL = "http://192.168.100.238:45455/api/";
        

        public static string ApiKeyName = "Progra6ApiKey";

        public static string ApiKeyValue = "DanielApiKeyAz1234";

    }
}
