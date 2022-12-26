using SOMOID.core.Interfaces;
using SOMOID.core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SOMOID.core.Services
{
    public class SomoidHttpClient : ISomoidHttpClient
    {
        private readonly HttpClient httpClient; //For access methods get post from client...

        public SomoidHttpClient(HttpClient httpClient)
        {
            this.httpClient=httpClient;
        }

        /// <summary>
        /// //for troubleshout
        /// </summary>
        /// <returns>string</returns>
        public async Task<string> Ping() //task significa que é uma promisse
        {
            var result = await httpClient.GetAsync("ping");
            if (result.IsSuccessStatusCode)
            {
                return "ok!";
            }
            return "not ok!";
        }

        
        public async Task<string> PostApplication(Application model)
        {
            var content = SerializeObjectToContent(model);
            var result = await httpClient.PostAsync("api/application", content);
            if (result.IsSuccessStatusCode)
            {
                return "ok!";
            }
            return "not ok!";
        }

        public static StringContent SerializeObjectToContent(Application content)
        {
            return new StringContent(content.ToString(), Encoding.UTF8, "application/xml");
        }
    }
}
