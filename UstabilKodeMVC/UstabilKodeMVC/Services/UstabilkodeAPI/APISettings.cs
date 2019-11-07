using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UstabilKodeMVC.Services.UstabilkodeAPI
{
    public static class APISettings
    {
        public static string APIUrl { get; set; } = "https://ustabilkode-api.azurewebsites.net/api";
        public static HttpClient Client { get; set; } = new HttpClient();
    }
}
