using SOMOID.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
    }
}
