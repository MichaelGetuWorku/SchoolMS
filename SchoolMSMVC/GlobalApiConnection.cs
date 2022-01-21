using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace SchoolMSMVC
{
    public class GlobalApiConnection
    {
        public static HttpClient WebApitClient = new HttpClient();

        static GlobalApiConnection()
        {
            WebApitClient.BaseAddress = new Uri("https://localhost:44389/api/");
            WebApitClient.DefaultRequestHeaders.Clear();
            WebApitClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}